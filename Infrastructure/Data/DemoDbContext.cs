using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>()
                .HasKey(x => x.Id);

            builder.Entity<UserEntity>()
                .Property(x => x.FirstName)
                .HasMaxLength(DbPropertyLengths.NameLength);

            builder.Entity<UserEntity>()
                .Property(x => x.LastName)
                .HasMaxLength(DbPropertyLengths.NameLength);
        }

    }
}
