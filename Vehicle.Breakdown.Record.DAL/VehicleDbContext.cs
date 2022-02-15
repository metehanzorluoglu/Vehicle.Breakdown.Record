using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecord.DAL
{
    public class VehicleDbContext: IdentityDbContext<UserApp,IdentityRole,string>
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options):base(options)
        {

        }

        public VehicleDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7HRD6FM;Initial Catalog=VehicleRecorDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<BreakdownList> BreakdownLists { get; set; }
        public DbSet<VehicleComment> VehicleComments { get; set; }
        public DbSet<VehicleBreakdownList> VehicleBreakdownLists { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


    }

    
}
