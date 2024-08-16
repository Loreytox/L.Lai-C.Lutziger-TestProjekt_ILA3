using System;
using System.Threading;

namespace Autorennen
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] autos = { "Auto 1", "Auto 2", "Auto 3", "Auto 4" };
            int[] streckenPositionen = { 0, 0, 0, 0 };

            Console.WriteLine("Willkommen beim Autorennen!");
            Console.WriteLine("Auf welches Auto möchten Sie wetten? (1-4): ");
            int wettAuto = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine($"\nSie haben auf {autos[wettAuto]} gewettet.\nDrücken Sie eine Taste, um das Rennen zu starten!");
            Console.ReadKey();

            bool rennenLäuft = true;
            int ziel = 50;

            while (rennenLäuft)
            {
                Console.Clear();

                for (int i = 0; i < autos.Length; i++)
                {
                    streckenPositionen[i] += random.Next(1, 4);
                    Console.WriteLine($"{autos[i]}: {new string('-', streckenPositionen[i])}>");

                    if (streckenPositionen[i] >= ziel)
                    {
                        Console.WriteLine($"\n{autos[i]} hat das Rennen gewonnen!");
                        if (i == wettAuto)
                        {
                            Console.WriteLine("Herzlichen Glückwunsch! Sie haben Ihre Wette gewonnen.");
                        }
                        else
                        {
                            Console.WriteLine("Leider haben Sie Ihre Wette verloren.");
                        }
                        rennenLäuft = false;
                        break;
                    }
                }

                Thread.Sleep(200);
            }

            Console.WriteLine("Vielen Dank für's Spielen!");
            Console.ReadKey();
        }
    }
}
