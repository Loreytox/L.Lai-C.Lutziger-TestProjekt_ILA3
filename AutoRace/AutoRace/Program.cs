using System;
using System.Threading;

namespace Autorennen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Random object to simulate random movements of the cars
            Random random = new Random();

            // Array representing the names of the cars
            string[] autos = { "Auto 1", "Auto 2", "Auto 3", "Auto 4" };

            // Array representing the current positions of the cars on the track
            int[] streckenPositionen = { 0, 0, 0, 0 };

            // Welcome message
            Console.WriteLine("Willkommen beim Autorennen!");

            // Prompt the user to place a bet on one of the cars
            Console.WriteLine("Auf welches Auto möchten Sie wetten? (1-4): ");
            int wettAuto = int.Parse(Console.ReadLine()) - 1;

            // Confirm the user's bet and wait for them to start the race
            Console.WriteLine($"\nSie haben auf {autos[wettAuto]} gewettet.\nDrücken Sie eine Taste, um das Rennen zu starten!");
            Console.ReadKey();

            // Variable to track whether the race is ongoing
            bool rennenLäuft = true;

            // Set the finish line distance
            int ziel = 50;

            // Main loop for the race
            while (rennenLäuft)
            {
                // Clear the console to redraw the race
                Console.Clear();

                // Loop through each car
                for (int i = 0; i < autos.Length; i++)
                {
                    // Move the car a random distance between 1 and 3 units
                    streckenPositionen[i] += random.Next(1, 4);

                    // Draw the car's current position on the track
                    Console.WriteLine($"{autos[i]}: {new string('-', streckenPositionen[i])}>");

                    // Check if the car has reached or passed the finish line
                    if (streckenPositionen[i] >= ziel)
                    {
                        // Announce the winner
                        Console.WriteLine($"\n{autos[i]} hat das Rennen gewonnen!");

                        // Check if the user's bet was on the winning car
                        if (i == wettAuto)
                        {
                            Console.WriteLine("Herzlichen Glückwunsch! Sie haben Ihre Wette gewonnen.");
                        }
                        else
                        {
                            Console.WriteLine("Leider haben Sie Ihre Wette verloren.");
                        }

                        // End the race
                        rennenLäuft = false;
                        break;
                    }
                }

                // Pause briefly before the next iteration to simulate real-time movement
                Thread.Sleep(200);
            }

            // Thank the user for playing
            Console.WriteLine("Vielen Dank für's Spielen!");
            Console.ReadKey(); // Wait for user input before closing the console
        }
    }
}
