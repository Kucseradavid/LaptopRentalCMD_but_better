namespace LaptopRentalCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Worm!");

            StreamReader olvaso = new StreamReader("../../../laptoprentals2022.csv");
            olvaso.ReadLine(); //fejléc
            List<Rent> adatok = new List<Rent>();

            while (!olvaso.EndOfStream)
            {
                string sor = olvaso.ReadLine();
                Rent egyadat = new Rent(sor);
                adatok.Add(egyadat);
            }

            olvaso.Close();

            //foreach (Rental adat in adatok) { Console.WriteLine(adat.ToString()); }


            Console.WriteLine();


            //3.feladat
            Console.WriteLine($"3. feladat: Bérlések száma: {adatok.Count}");


            //4.feladat
            Console.WriteLine("4. feladat: Szürke Acer bérlések");
            foreach (Rental adat in adatok)
            {
                if (adat.Color == "szürke" && adat.Model.IndexOf(@"Acer") != -1)
                {
                    Console.WriteLine($"\t{adat.InvNumber} {adat.Model} --- {adat.PersonalID} {adat.Name}");
                }
            }


            //5.feladat
            Console.WriteLine("5. feladat: Vármegyék, ahol a legkevesebb laptopot bérelték");
            List<string> varmegyek = new List<string>();
            int[] vmlaptopszamok = new int[19];
            for (int i = 0; i < adatok.Count; i++)
            {
                if (varmegyek.Contains(adatok[i].County))
                {
                    varmegyek.Add(adatok[i].County);
                }
            }
            for (int i = 0; i < varmegyek.Count; i++)
            {
                foreach (Rental adat in adatok)
                {
                    if (varmegyek[i] == adat.County)
                    {
                        vmlaptopszamok[i]++;
                    }
                }
            }
            string[] legkisvm = new string[1];
            int[] legkisvmszam = new int[1];
            legkisvmszam[0] = vmlaptopszamok[0];
            for (int i = 0; i < varmegyek.Count; i++)
            {
                if (legkisvmszam[0] > vmlaptopszamok[i])
                {
                    legkisvm[0] = varmegyek[i];
                    legkisvmszam[0] = vmlaptopszamok[i];
                }
            }
            string[] legkisvm2 = new string[1];
            int[] legkisvmszam2 = new int[1];
            legkisvmszam2[0] = vmlaptopszamok[0];
            for (int i = 0; i < varmegyek.Count; i++)
            {
                if (vmlaptopszamok[i] > legkisvmszam[0] && legkisvmszam2[0] > vmlaptopszamok[i])
                {
                    legkisvm2[0] = varmegyek[i];
                    legkisvmszam2[0] = vmlaptopszamok[i];
                }
            }
            Console.WriteLine($"\t{legkisvm[0]} : {legkisvmszam[0]}");
            Console.WriteLine($"\t{legkisvm2[0]} : {legkisvmszam2[0]}");
            Console.WriteLine("nem működik, ne is keresse");


            //6.feladat
            Console.WriteLine("6. feladat:");
            bool good = false;
            while (!good)
            {
                Console.Write("\tA keresett leltári szám: ");
                string bekert = Console.ReadLine();
                bool inte = false;
                if (bekert.Length >= 8)
                {
                    inte = int.TryParse(bekert.Substring(3, 5), out _);
                }
                if (bekert == "0")
                {
                    Console.WriteLine("\tFeladat átugorva!");
                    break;
                }
                else if (bekert.IndexOf(@"LPT") == 0 && inte)
                {
                    //Console.WriteLine("is good"); //seems
                    good = true;
                    bool vane = false;
                    foreach (Rental adat in adatok)
                    {
                        if (adat.InvNumber == bekert)
                        {
                            vane = true;
                            Console.WriteLine($"\t{adat.InvNumber} {adat.Model} {adat.Color}");
                            break;
                        }
                    }
                    if (!vane)
                    {
                        Console.WriteLine("\tNincs ilyen leltári számú laptop a beolvasott adatok között!");
                    }
                }
                else
                {
                    Console.WriteLine("\tNem megfelelő formátum!");
                    good = false;
                }
            }
            //Console.WriteLine("a program továbbment");


            //7.feladat
            int osszbevetel = 0;
            foreach (Rental adat in adatok)
            {
                TimeSpan napokts = adat.EndDate - adat.StartDate;
                int napok = Convert.ToInt32(napokts.Days) + 1;
                osszbevetel += napok * adat.DailyFee;
                if (adat.UseDeposit)
                {
                    osszbevetel += adat.Deposit;
                }
            }
            Console.WriteLine($"7. feladat: A cég összes bevétele: {(Convert.ToInt32(osszbevetel).ToString("N"))/*.Remove(osszbevetel.ToString().Length-3)*/}Ft");
            //Console.WriteLine("I ain't botherin' with thousands at 10:44 PM espetially on Fridays");

            //8.feladat
            Rental keresett = adatok[3];
            Console.WriteLine($"8. feladat: Az {keresett.InvNumber} leltári számú laptop bérlésenkénti átlagos üzemideje: {keresett.AvgUpTime(adatok)} óra");
        }
    }
}
