using System.ComponentModel.DataAnnotations;
using Coink.Microservice.Domain.DTOs.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Commands
{
    public record UserUpdateCommand : IRequest<UserDto>
    {
        [Required(ErrorMessage = "El Id es requerido")]
        public Guid Id { get; init; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 150 caracteres")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 caracteres")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Phone { get; init; } = string.Empty;

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 250 caracteres")]
        public string Address { get; init; } = string.Empty;

        [Required(ErrorMessage = "El municipio es requerido")]
        public Guid MunicipalityId { get; init; }
    }
}
