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
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
