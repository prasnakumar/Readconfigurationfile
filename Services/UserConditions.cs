using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Read_configuration_file.Services
{
    public class UserConditions
    {
        public const string valueSection = "UserCondition";
      
        public bool error { get; set; }
        public bool warning { get; set; }
        public bool debug { get; set; }
    }

   
}
