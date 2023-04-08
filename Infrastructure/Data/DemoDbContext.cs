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

        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>()
                .HasKey(x => x.Id);

            builder.Entity<UserEntity>()
                .Property(x => x.FirstName)
                .HasMaxLength(DbConstants.NameLength);

            builder.Entity<UserEntity>()
                .Property(x => x.LastName)
                .HasMaxLength(DbConstants.NameLength);

            builder.Entity<UserEntity>()
                .Property(x => x.UserEmail)
                .HasMaxLength(DbConstants.EmailLength);

            builder.Entity<UserEntity>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<RoleEntity>()
               .HasKey(x => x.Id);

            builder.Entity<RoleEntity>()
                .Property(x => x.RoleName)
                .HasMaxLength(DbConstants.NameLength);
            

        }


    }
}
