﻿using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Application.Repositorys.Write;
using PrimeStore_API.Application.UnitOfWork;
using PrimeStore_API.Persistence.Context;
using PrimeStore_API.Persistence.Repositorys.Read;
using PrimeStore_API.Persistence.Repositorys.Write;

namespace PrimeStore_API.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IColorReadRepository _colorReadRepository;
        private readonly IColorWriteRepository _colorWriteRepository;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            _brandReadRepository=new BrandReadRepository(context);
            _brandWriteRepository=new BrandWriteRepository(context);
            _colorReadRepository=new ColorReadRepository(context);
            _colorWriteRepository=new ColorWriteRepository(context);
        }

        public IBrandReadRepository BrandReadRepository => _brandReadRepository;

        public IBrandWriteRepository BrandWriteRepository => _brandWriteRepository;

        public IColorReadRepository ColorReadRepository => _colorReadRepository;

        public IColorWriteRepository ColorWriteRepository => _colorWriteRepository;

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
