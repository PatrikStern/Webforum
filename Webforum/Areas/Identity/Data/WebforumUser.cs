using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Webforum.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebforumUser class
    public class WebforumUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public int AmountOfPosts { get; set; }
        public int AmountOfComments { get; set; }

        public WebforumUser()
        {
            CreationDate = DateTime.Now;
        }
    }
}
