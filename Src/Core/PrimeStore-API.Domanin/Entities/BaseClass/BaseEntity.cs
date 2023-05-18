namespace PrimeStore_API.Domanin.Entities.BaseClass
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; } 
        public bool IsEnabled { get; set; }
        public string ModifiedUserId { get; set; }
        public string CreatedUserId { get; set; }
    }
}
