using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySite.Domain.Entities;

namespace MySite.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "cbd0901e-2ba1-45a2-be4f-42428dac8572",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "6156d615-8917-40b0-9945-5152cd974992",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "ontonowskey1@gmail.com",
                NormalizedEmail = "ONTONOWSKEY1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "adminpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "cbd0901e-2ba1-45a2-be4f-42428dac8572",
                UserId = "6156d615-8917-40b0-9945-5152cd974992"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("6e10f728-49f8-423b-b4c2-e11828ec9594"),
                CodeWord = "PageIndex",
                Title = "Main"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("fd7b1b4a-cb96-463d-b455-619657451a87"),
                CodeWord = "PageServices",
                Title = "My services"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("c476f33d-7916-4566-aa60-c9094b3596f4"),
                CodeWord = "PageContacts",
                Title = "Contacts"
            });
        }

    }
}
