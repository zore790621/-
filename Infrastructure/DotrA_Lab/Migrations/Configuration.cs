using DotrA_Lab.Business.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DotrA_Lab.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DotrA_Lab.ORM.Context.DotrADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotrA_Lab.ORM.Context.DotrADbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.MemberRole.AddRange(
                new List<MemberRole>() {
                    new MemberRole(){RoleID = 1 , RoleName = "admin"},
                    new MemberRole(){RoleID = 2 , RoleName = "customer"},
                    new MemberRole(){RoleID = 3 , RoleName = "member"},
                    new MemberRole(){RoleID = 4 , RoleName = "guest"},
                });
            context.Member.Add(new Member()
            {
                MemberID = 1,
                MemberAccount = "admin",
                Password = "bg1ro4pMF0i3iA1oU4XaZnOzjXCziNRnUZyTs3k3lUs=",
                Name = "admin",
                Email = "DotrA@gmail.com",
                Address = "DotrA",
                Phone = "0900-000-000",
                RoleID = 1,
                HashCode = "UjL6sJixyF",
                EmailVerified = true,
                ActivationCode = new Guid("feed2e92-67ff-42a9-9664-acaecdb0f1df")
            });

        }
    }
}
