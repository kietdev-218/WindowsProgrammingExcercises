using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.Models
{
    public class StudentSearchCriteria
    {
        public string SearchText { get; set; }

        public string ClassName { get; set; }
    }
}
