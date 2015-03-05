using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using EFRelationshipSample.Models;

namespace EFRelationshipSample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.MobileServiceContext context)
        {
            // this can occours more that once
            //var user1 = GetUser("User1");
            //var user2= GetUser("User2");
            //var user3 = GetUser("User3");

            //if (user2.Friends == null)
            //{
            //    user2.Friends= new List<User>();
            //}
            //if (user3.Friends == null)
            //{
            //    user3.Friends = new List<User>();
            //}
            //if (user3.UnFriends == null)
            //{
            //    user3.UnFriends = new List<User>();
            //}

            //user1 = context.Set<User>().Add(user1);
            //user2.Friends.Add(user1);
            //user2 = context.Set<User>().Add(user2);
            //user3.Friends.Add(user2);
            //user3.UnFriends.Add(user1);
            //user3 = context.Set<User>().Add(user3);
        }

        private User GetUser(string name)
        {
            return new User
            {
                Id= Guid.NewGuid().ToString(),
                MyPropertyForDbOnly ="Secret property in database.",
                Name = name
            };
        }
    }
}
