using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelanceAssessment.Models
{
    public class Freelance
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string skillsets { get; set; }
        public string hobby { get; set; }
    }
}