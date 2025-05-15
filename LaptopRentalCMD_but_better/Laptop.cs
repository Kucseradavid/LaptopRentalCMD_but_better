using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalCMD_but_better
{
    internal class Laptop
    {
        public string InvNumber { get; set; }
        public string Model { get; set; }
        public string County { get; set; }
        public int RAM { get; set; }
        public string Color { get; set; }
        public int DailyFee { get; set; }
        public int Deposit { get; set; }

        public Laptop (string invnumber, string model, string country, int ram, string color, int dailyfee, int deposit)
        {
            this.InvNumber = invnumber;
            this.Model = model;
            this.County = country;
            this.RAM = ram;
            this.Color = color;
            this.DailyFee = dailyfee;
            this.Deposit = deposit;
        }
    }
}
