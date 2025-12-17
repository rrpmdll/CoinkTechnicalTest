using System.Data;
using NpgsqlTypes;

namespace Coink.Microservice.Infrastructure.EntityFramework.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    internal sealed class NpgsqlParameterAttribute : Attribute
    {
        public string Name { get; }

        public NpgsqlDbType? Type { get; }

        public ParameterDirection Direction { get; set; } = ParameterDirection.Input;

        public NpgsqlParameterAttribute(string name)
        {
            Name = name;
        }

        public NpgsqlParameterAttribute(string name, NpgsqlDbType type)
        {
            Name = name;
            Type = type;
        }
    }
}
