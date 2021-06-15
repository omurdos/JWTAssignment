using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAssignment.Models
{
    public class User : IdentityUser
    {
        public string Photo { get; set; }
        public double DonationTotal { get; set; }
        public double PointsTotal { get; set; }
    }
}
