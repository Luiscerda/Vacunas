using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public string Identification { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
