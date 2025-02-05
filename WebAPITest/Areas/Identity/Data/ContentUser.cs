using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAPITest.Models;

namespace WebAPITest.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ContentUser class
public class ContentUser : IdentityUser
{
    public ICollection<Content> Posts { get; set; }
}

