using Coink.Microservice.Domain.Entities.Base;
using Coink.Microservice.Domain.Entities.Location;

namespace Coink.Microservice.Domain.Entities.User
{
    public class UserEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Guid MunicipalityId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual MunicipalityEntity Municipality { get; set; } = null!;
    }
}
