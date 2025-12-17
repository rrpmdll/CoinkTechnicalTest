using Coink.Microservice.Domain.Entities.Base;

namespace Coink.Microservice.Domain.Entities.Location
{
    public class DepartmentEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public virtual CountryEntity Country { get; set; } = null!;
        public virtual ICollection<MunicipalityEntity> Municipalities { get; set; } = new List<MunicipalityEntity>();
    }
}
