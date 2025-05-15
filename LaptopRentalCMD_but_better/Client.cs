using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalCMD_but_better
{
    internal class Client
    {
        public string PersonalID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Postalcode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Client (string personalid, string name, DateTime dateofbirth, int postalcode, string city, string address)
        {
            this.PersonalID = personalid;
            this.Name = name;
            this.DateOfBirth = dateofbirth;
            this.Postalcode = postalcode;
            this.City = city;
            this.Address = address;
        }
    }
}
