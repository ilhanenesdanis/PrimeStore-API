using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PrimeStore_API.Application.Repositorys.Dapper;
using PrimeStore_API.Application.RequestParameters;
using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Persistence.Models;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace PrimeStore_API.Persistence.Repositorys.Dapper
{
    public class DapperRepository<T> : IDapperRepository<T> where T : BaseEntity, new()
    {
        private readonly string _connectionString = string.Empty;
        public DapperRepository(IOptions<ConnectionStringsOptions> options)
        {
            _connectionString = options.Value.SqlConnection;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> selectColumns = null, string orderByColumn = null, bool ascending = true, Pagination Pagination = null)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                string query = $"SELECT {GetSelectClause(selectColumns)} FROM {GetTableName()}";

                if (!string.IsNullOrEmpty(orderByColumn))
                    query = ToOrderBy(orderByColumn, ascending, query);

                if (Pagination != null)
                    query = ToPaged(Pagination, query);






                return await connection.QueryAsync<T>(query);
            }
        }
        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> selectColumns = null, string orderByColumn = null, bool ascending = true, Pagination Pagination = null)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var query = $"SELECT {GetSelectClause(selectColumns)} FROM {GetTableName()} WHERE {GetSqlWhereClause(predicate)}";
                if (Pagination != null)
                    query = ToPaged(Pagination, query);

                if (!string.IsNullOrEmpty(orderByColumn))
                    query = ToOrderBy(orderByColumn, ascending, query);

                return await conn.QueryAsync<T>(query);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var query = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
                var parameters = new { Id = id };
                return await conn.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        public async Task InsertAsync(T entity)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var query = $"INSERT INTO {GetTableName()} ({GetColumns()}) VALUES ({GetParamColums()})";
                await conn.ExecuteAsync(query, entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var query = $"UPDATE {GetTableName()} SET {GetColumnsWithParameters()} WHERE Id = @Id";
                await conn.ExecuteAsync(query, entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var query = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
                var parameters = new { Id = id };
                await conn.ExecuteAsync(query, parameters);
            }
        }
        #region Configuration
        public IDbConnection Connection { get { return new SqlConnection(_connectionString); } }

        private string GetTableName()
        {
            return typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name + "s";
        }
        private string GetColumns()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => p.Name));
        }
        private string GetParamColums()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => "@" + p.Name));
        }
        private string GetColumnsWithParameters()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        }

        private string GetSqlWhereClause(Expression<Func<T, bool>> predicate)
        {
            var binaryExpression = predicate.Body as BinaryExpression;
            var left = VisitMemberExpression(binaryExpression?.Left as MemberExpression);
            var right = VisitConstantExpression(binaryExpression?.Right as ConstantExpression);
            var @operator = GetSqlOperator(binaryExpression?.NodeType);

            return $"{left} {@operator} {right}";
        }

        private string VisitMemberExpression(MemberExpression expression)
        {
            return expression != null ? expression.Member.Name : string.Empty;
        }

        private string VisitConstantExpression(ConstantExpression expression)
        {
            return expression != null ? $"'{expression.Value}'" : string.Empty;
        }

        private string GetSqlOperator(ExpressionType? expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                default:
                    return string.Empty;
            }
        }
        private string GetSelectClause(Expression<Func<T, object>> selectColumns)
        {
            if (selectColumns == null)
                return "*";

            var columnNames = ((NewExpression)selectColumns.Body).Arguments
                .Select(arg => (arg as MemberExpression)?.Member.Name)
                .Where(name => name != null);

            return string.Join(", ", columnNames);
        }
        private static string ToOrderBy(string orderByColumn, bool ascending, string query)
        {
            string orderDirection = ascending ? "ASC" : "DESC";
            query += $" ORDER BY {orderByColumn} {orderDirection}";
            return query;
        }

        private static string ToPaged(Pagination Pagination, string query)
        {
            int offset = (Pagination.Page - 1) * Pagination.Size;
            query += $" OFFSET {offset} ROWS FETCH NEXT {Pagination.Size} ROWS ONLY";
            return query;
        }
        #endregion
    }
}
