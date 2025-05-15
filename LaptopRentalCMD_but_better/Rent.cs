using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopRentalCMD_but_better
{
    internal class Rent
    {
        public Client Client { get; set; }
        public Laptop Laptop { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool UseDeposit { get; set; }
        public double Uptime { get; set; }

        public Rent(Client client, Laptop laptop, DateTime startdate, DateTime enddate, bool usedeposit, double uptime)
        {
            this.Client = client;
            this.Laptop = laptop;
            this.StartDate = startdate;
            this.EndDate = enddate;
            this.UseDeposit = usedeposit;
            this.Uptime = uptime;
        }

        public Rent(string sor)
        {
            string[] soradatok = sor.Split(";");

            Client szemely = new Client(soradatok[0], soradatok[1], Convert.ToDateTime(soradatok[2]), Convert.ToInt32(soradatok[3]), soradatok[4], soradatok[5]);

            Laptop eszkoz = new Laptop(soradatok[6], soradatok[7], soradatok[8], Convert.ToInt32(soradatok[9]), soradatok[10], Convert.ToInt32(soradatok[11]), Convert.ToInt32(soradatok[12]));

            this.Client = szemely;
            this.Laptop = eszkoz;
            this.StartDate = Convert.ToDateTime(soradatok[13]);
            this.EndDate = Convert.ToDateTime(soradatok[14]);
            if (Convert.ToInt32(soradatok[15]) == 0) this.UseDeposit = false;
            else this.UseDeposit = true;
            this.Uptime = Convert.ToDouble(soradatok[16]);
        }

        public double AvgUpTime(List<Rent> forraslista)
        {
            List<Rent> elofordulasok = new List<Rent>();

            foreach (Rent adat in forraslista)
            {
                if (this.Laptop.InvNumber == adat.Laptop.InvNumber)
                {
                    elofordulasok.Add(adat);
                }
            }

            double ossz = 0;

            foreach (Rent adat in elofordulasok)
            {
                ossz += adat.Uptime;
            }

            return Math.Round(ossz / elofordulasok.Count(), 2);
        }
    }
}
