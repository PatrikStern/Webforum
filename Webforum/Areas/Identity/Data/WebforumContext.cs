using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webforum.Areas.Identity.Data;
using Webforum.Areas.Identity.Data.Entites;

namespace Webforum.Data
{
    public class WebforumContext : IdentityDbContext<WebforumUser>
    {
        public WebforumContext(DbContextOptions<WebforumContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string adminId = "admin-c0-aa65-4af8-bd17-00bd9344e575";
            const string roleId = "root-0c0-aa65-4af8-bd17-00bd9344e575";
            const string userRoleId = "user-2c0-aa65-4af8-bd17-00bd9344e575";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "root",
                NormalizedName = "ROOT"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "user",
                NormalizedName = "USER"
            });

            var hasher = new PasswordHasher<WebforumUser>();

            builder.Entity<WebforumUser>().HasData(new WebforumUser
            {
                Id = adminId,
                UserName = "AdminCore123",
                NormalizedUserName = "ADMINCORE123",
                Email = "admin@core.api",
                NormalizedEmail = "ADMIN@CORE.API",
                ImageUrl = "DefaultProfileImg.jpg",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminPass1!"),
                SecurityStamp = Guid.NewGuid().ToString(),
            }); ;

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
       public DbSet<Subject> Subjects { get; set; }
       public DbSet <Category> Categories { get; set; }
       public DbSet <HeadLines> HeadLines { get; set; }
       public DbSet <Posts> Posts { get; set; }
       public DbSet<Comments> Comments { get; set; }
       public DbSet<Chat> Chats { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }
       public DbSet<PostThread> Threads { get; set; }
    }
}
