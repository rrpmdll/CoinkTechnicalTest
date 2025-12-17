using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Coink.Microservice.Infrastructure.EntityFramework
{
    [ExcludeFromCodeCoverage]
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.HasDefaultSchema(_configuration.GetConnectionString("BaseSchema"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
