using Coink.Microservice.Domain.Entities.Base;

namespace Coink.Microservice.Domain.Entities.Location
{
    public class CountryEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();
    }
}
