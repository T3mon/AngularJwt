using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Models
{
    public class Settings
    {
        public EnvironmentSettings EnvironmentSettings { get; set; }
        public AutentificationSettings AutentificationSettings { get; set; }
    }
    public class EnvironmentSettings
    {
        public string Name { get; set; }
    }
    public class AutentificationSettings
    {
        public bool ValidateIssuer = true;
        public bool ValidateAudience = true;
        public bool ValidateLifetime = true;
        public string ValidIssuer = "https://localhost:7796";
        public string ValidAudience = "https://localhost:7796";
        public SymmetricSecurityKey IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
    }
}
