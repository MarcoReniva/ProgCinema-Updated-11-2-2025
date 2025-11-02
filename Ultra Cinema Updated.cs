using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] seat = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };// these seats are just place holders for the command that replaces the chosen seats with an X
            string[] seat2 = { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10" };
            string[] seat3 = { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
            // Time slots for gorge 
            // Gorge 8am
            string[] gorge8a = { "X", "A2", "A3", "A4", "A5", "A6", "X", "A8", "A9", "A10" };
            string[] gorge8b = { "B1", "X", "B3", "X", "B5", "B6", "B7", "X", "B9", "B10" };
            string[] gorge8c = { "C1", "C2", "C3", "C4", "X", "C6", "X", "C8", "C9", "C10" };
            // Gorge 12pm
            string[] gorge12a = { "X", "X", "X", "A4", "X", "A6", "A7", "A8", "A9", "A10" };
            string[] gorge12b = { "X", "X", "X", "B4", "B5", "X", "X", "X", "X", "X" };
            string[] gorge12c = { "X", "C2", "C3", "X", "C5", "C6", "X", "X", "C9", "C10" };
            // Gorge 4pm
            string[] gorge4a = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            string[] gorge4b = { "B1", "B2", "B3", "X", "X", "X", "B7", "B8", "B9", "B10" };
            string[] gorge4c = { "C1", "C2", "X", "X", "C5", "X", "X", "X", "C9", "C10" };
            //Time slots for violet
            // Violet 9am
            string[] violet9a = { "A1", "A2", "A3", "X", "X", "X", "X", "X", "A9", "A10" };
            string[] violet9b = { "B1", "B2", "X", "X", "X", "B6", "B7", "X", "X", "B10" };
            string[] violet9c = { "C1", "C2", "C3", "C4", "C5", "C6", "X", "X", "X", "X" };
            // Violet 11am
            string[] violet11a = { "X", "X", "X", "X", "X", "X", "X", "X", "A9", "A10" };
            string[] violet11b = { "B1", "X", "X", "X", "B5", "X", "B7", "B8", "X", "B10" };
            string[] violet11c = { "C1", "C2", "C3", "C4", "X", "C6", "X", "X", "C9", "C10" };
            // timeslots for silent
            // 4am Timeslot
            string[] silent4a = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };
            string[] silent4b = { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10" };
            string[] silent4c = { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
            // 6am Timeslot 
            string[] silent6a = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };
            string[] silent6b = { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10" };
            string[] silent6c= { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };
            // 10am Timeslot
            string[] silent10a = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };
            string[] silent10b = { "B1", "B2", "B3", "B4", "X", "B6", "B7", "B8", "B9", "B10" };
            string[] silent10c = { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "X" };
            // Timeslot for Tunnel
            //7am Timeslot
            string[] tunnel7a = { "A1", "A2", "A3", "A4", "X", "X", "A7", "A8", "A9", "A10" };
            string[] tunnel7b = { "B1", "B2", "B3", "B4", "X", "X", "B7", "B8", "B9", "B10" };
            string[] tunnel7c = { "C1", "C2", "C3", "C4", "X", "X", "C7", "C8", "C9", "C10" };
            // 9am timeslot
            string[] tunnel9a = { "X", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10" };
            string[] tunnel9b = { "B1", "X", "X", "X", "B5", "B6", "B7", "B8", "B9", "B10" };
            string[] tunnel9c = { "C1", "C2", "C3", "C4", "X", "X", "X", "X", "C9", "C10" };
            // 12am timeslot
            string[] tunnel12a = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            string[] tunnel12b = { "X", "X", "X", "X", "B5", "B6", "B7", "B8", "B9", "B10" };
            string[] tunnel12c = { "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10" };

            int menu = 0;
            string seats = "";
            int ticketprice = 12;
            int seatCount = 0;
            string moviename = "";
            string movietime = "";
            int timeselect = 0;
            bool validseat = false;
            bool bookmovie = false;
            bool pickseat = false;
            int movieselected = 0;
            string chosenseat = "";
            Console.WriteLine("============================");
            Console.WriteLine("       NAZERICK THEATERS       ");           
            Console.WriteLine("============================");

            Console.WriteLine("Are you a customer?");
            Console.WriteLine("If not get out!");
            Console.WriteLine("[1] Customer:");
            Console.WriteLine("[2] Exit: ");


            while (!bookmovie)
            {

                Console.Write("\nEnter Choice: ");
                menu = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (menu)
                {
                    case 1:

                        while (true)
                        {
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("[1] The Gorge");
                            Console.WriteLine("[2] Violet Evergarden The Movie");
                            Console.WriteLine("[3] A Silent Voice");
                            Console.WriteLine("[4] The Tunnel to Summer, the Exit of Goodbyes (2022)");
                            Console.WriteLine("==========================================================");

                            Console.Write("Choose a Movie: ");
                            movieselected = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if (movieselected == 1)
                            {
                                Console.WriteLine("Showing Time for: [The Gorge] ");
                                Console.WriteLine("1. 8:00am - $100");
                                Console.WriteLine("2. 12:00pm - $9");
                                Console.WriteLine("3. 4:00pm - $7");

                            }
                            else if (movieselected == 2)
                            {
                                Console.WriteLine("Showing Time: Violet Evergarden The Movie");
                                Console.WriteLine("1. 9:00am - $15");
                                Console.WriteLine("2. 11:00am - $12");
                            }
                            else if (movieselected == 3)
                            {
                                Console.WriteLine("Showing Time: A Silent Voice");
                                Console.WriteLine("1. 4:00am - $10");
                                Console.WriteLine("2. 6:00am - $9");
                                Console.WriteLine("3. 10:00am - $11");
                            }
                            else if (movieselected == 4)
                            {
                                Console.WriteLine("Showing Time: The Tunnel to Summer, the Exit of Goodbyes (2022)");
                                Console.WriteLine("1. 7:30am - $11");
                                Console.WriteLine("2. 9:00am - $12");
                                Console.WriteLine("3. 12:00pm - $15");
                            }
                            else
                            {
                                Console.WriteLine("Enter valid Number (1 - 4) only: ");
                                continue; //asks the user again
                            }
                            bookmovie = true;// an exit for when the user enters a valid movie 
                            pickseat = true;
                            break;
                        }
                        break; // ends case 1 when the user enters a valid movie 
                    case 2:
                        Console.WriteLine("You have exited!");
                        return;
                    default:
                        Console.Write("Invalid Number Pls enter either 1 for customer or 2 to exit: ");
                        continue;


                }
                Console.WriteLine();
                Console.Write("Enter Selected Time e.g (1 or 2 or 3):");
                timeselect = Convert.ToInt32(Console.ReadLine());
                if (movieselected == 1 && timeselect == 1)
                {
                    moviename = "The Gorge";
                    ticketprice = 100;
                    movietime = "8:00am";
                    seat = gorge8a; // it is equated to the timeslots of the movies to as a pointer to the right seat arrays for when a user enters a timeslot or movie 
                    seat2 = gorge8b; // it is also important because it makes the X replacement possible
                    seat3 = gorge8c;

                }
                else if (movieselected == 1 && timeselect == 2)
                {
                    moviename = "The Gorge";
                    ticketprice = 9;
                    movietime = "12:00pm";
                    seat = gorge12a;
                    seat2 = gorge12b;
                    seat3 = gorge12c;
                }
                else if (movieselected == 1 && timeselect == 3)
                {
                    moviename = "The Gorge";
                    ticketprice = 7;
                    movietime = "4:00pm";
                    seat = gorge4a;
                    seat2 = gorge4b;
                    seat3 = gorge4c;
                }
                if (movieselected == 2 && timeselect == 1)
                {
                    moviename = "Violet Evergarden The Movie";
                    ticketprice = 15;
                    movietime = "9:00am";
                    seat = violet9a;
                    seat2 = violet9b;
                    seat3 = violet9c;

                }
                else if (movieselected == 2 && timeselect == 2)
                {
                    moviename = "Violet Evergarden The Movie";
                    ticketprice = 12;
                    movietime = "11:00am";
                    seat = violet11a;
                    seat2 = violet11b;
                    seat3 = violet11c;
                }
                if (movieselected == 3 && timeselect == 1)
                {
                    moviename = "A Silent Voice";
                    ticketprice = 10;
                    movietime = "4:00am";
                    seat = silent4a;
                    seat2 = silent4b;
                    seat3 = silent4c;

                }
                else if (movieselected == 3 && timeselect == 2)
                {
                    moviename = "A Silent Voice";
                    ticketprice = 9;
                    movietime = "6:00am";
                    seat = silent6a;
                    seat2 = silent6b;
                    seat3 = silent6c;
                }
                else if (movieselected == 3 && timeselect == 3)
                {
                    moviename = "A Silent Voice";
                    ticketprice = 11;
                    movietime = "10:00am";
                    seat = silent10a;
                    seat2 = silent10b;
                    seat3 = silent10c;
                }
                if (movieselected == 4 && timeselect == 1)
                {
                    moviename = "The Tunnel to Summer, the Exit of Goodbyes (2022)";
                    ticketprice = 11;
                    movietime = "7:00am";
                    seat = tunnel7a;
                    seat2 = tunnel7b;
                    seat3 = tunnel7c;
                }
                else if (movieselected == 4 && timeselect == 2)
                {
                    moviename = "The Tunnel to Summer, the Exit of Goodbyes (2022)";
                    ticketprice = 12;
                    movietime = "9:00am";
                    seat = tunnel9a;
                    seat2 = tunnel9b;
                    seat3 = tunnel9c;
                }
                else if (movieselected == 4 && timeselect == 3)
                {
                    moviename = " The Tunnel to Summer, the Exit of Goodbyes (2022)";
                    ticketprice = 15;
                    movietime = "12:00pm";
                    seat = tunnel12a;
                    seat2 = tunnel12b;
                    seat3 = tunnel12c;
                }
                while (pickseat)
                {
                    validseat = false; // reset before each new seat choice

                    Console.WriteLine("=======================Screen=========================");
                    Console.WriteLine();
                    for (int i = 0; i < 10; i++)
                        Console.Write("[" + seat[i] + "] ");
                    Console.WriteLine("\n");
                    for (int i = 0; i < 10; i++)
                        Console.Write("[" + seat2[i] + "] ");
                    Console.WriteLine("\n");
                    for (int i = 0; i < 10; i++)
                        Console.Write("[" + seat3[i] + "] ");
                    Console.WriteLine();
                    Console.WriteLine("==============Door=================Door=================");
                    Console.Write("Choose a seat: ");
                    chosenseat = Console.ReadLine();

                    // Check and replace seat
                    for (int i = 0; i < 10; i++)
                    {
                        if (chosenseat == seat[i])
                        {
                            seat[i] = "X";// marks the seat taken by the user with an X
                            validseat = true; // tells the program that the user entered a valid seat
                            seatCount++; // adds 1 and makes it possible for the user to book more than 1 seat 
                            break; // stops the loop immedietly once the user has found a seat
                        }
                        else if (chosenseat == seat2[i])
                        {
                            seat2[i] = "X";// marks the seat taken by the user with an X
                            validseat = true; // tells the program that the user entered a valid seat
                            seatCount++; // adds 1 and makes it possible for the user to book more than 1 seat
                            break; // stops the loop immedietly once the user has found a seat 
                        }
                        else if (chosenseat == seat3[i])
                        {
                            seat3[i] = "X"; // marks the seat taken by the user with an X
                            validseat = true; // tells the program that the user entered a valid seat
                            seatCount++; // adds 1 and makes it possible for the user to book more than 1 seat
                            break; // stops the loop immedietly once the user has found a seat
                        }
                        if (chosenseat == "X") // checks if the seats are taken or available
                        {
                            Console.WriteLine("Seat is already taken. Pls enter an available seat number: "); // if user enters a seat that is already taken
                            validseat = false; // checks if seat is available if not it proceeds to ask the user to enter a valid number.
                            break;
                        }
                    }
                    if (!validseat)
                    {

                        Console.WriteLine("This seat is either currently unavailable or \n you have entered a seat that does not exist.");
                        continue; // Asks the user again if seat was invalid
                    }
                    else if (chosenseat == "X" || chosenseat == "x")
                    {
                        Console.WriteLine("This seat is currently unavailable. Pls enter a seat that is not chosen: ");
                        continue;

                    }
                    else
                    {
                        Console.WriteLine($"Chosen Seat: {chosenseat}");
                    }
                    if (seats == "")
                    {
                        seats = chosenseat; // if seats <2 it prints just that seat
                    }
                    else
                    {
                        seats += ", " + chosenseat; // Combines or group the seats that was chosen by the user if its 2 or more
                    }

                    Console.Clear();
                    Console.Write("Will you choose another seat? (y/n): ");
                    string decide = Console.ReadLine().ToLower();

                    if (decide == "n")
                    {
                        Console.WriteLine("\nFinal Seat Plan:");
                        Console.WriteLine("=======================Screen===========================");
                        for (int i = 0; i < 10; i++)
                            Console.Write("[" + seat[i] + "] ");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 10; i++)
                            Console.Write("[" + seat2[i] + "] ");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 10; i++)
                            Console.Write("[" + seat3[i] + "] ");
                        Console.WriteLine();
                        Console.WriteLine("===============Door===============Door====================");

                        pickseat = false; // exits loop n
                    }
                }
                Console.WriteLine();
                double total = ticketprice * seatCount;
                Console.WriteLine("======================Booking Confirmation==========================");
                Console.WriteLine($"Movie Selected: {moviename}");
                Console.WriteLine($"Movie Time: {movietime}");
                Console.WriteLine($"Price: ${ticketprice} ");
                Console.WriteLine($"Seats Booked: {seats} ");
                Console.WriteLine($"Total Price: ${total} ");
                Console.Write("Confirm Booking? y/n: ");
                string confirm = Console.ReadLine();
                Console.Clear();
                if (confirm == "y" || confirm == "Y")
                {
                    Console.WriteLine("===================Receipt===============================");
                    Console.WriteLine($"Movie Selected: {moviename}");
                    Console.WriteLine($"Movie Time: {movietime}");
                    Console.WriteLine($"Price: ${ticketprice} ");
                    Console.WriteLine($"Seats Booked: {seats} ");
                    Console.WriteLine($"Total Price: ${total} ");
                    Console.WriteLine("Thank you for Choosing Nazerick Theaters ENJOY THE SHOW!!");
                    Console.WriteLine("===========================================================");
                }
                else if (confirm == "n" || confirm == "N")
                {
                    Console.WriteLine("Thank you, you may now get out");
                }
                
                
            }

        }
    }
}
