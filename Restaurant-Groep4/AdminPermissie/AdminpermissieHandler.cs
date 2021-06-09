using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.IO;

namespace Restaurant_Groep4.AdminPermissie
{
    public class AdminpermissieHandler
    {
        public static void Admin(string[] args)
        {
            string naam, wachtwoord, nummer;


            Console.WriteLine("\n Vul uw naam in: ");
            naam = Console.ReadLine();

            Console.Write("\n Voer uw wachtwoord in: ");
            wachtwoord = Console.ReadLine();

            Console.WriteLine("\n\n************** Info over u ************** ");


            if (naam == "Admin" && wachtwoord == "Admin123!")
            {
                Console.WriteLine("U bent een beheerder, dus u heeft meer toegang!");
                Console.WriteLine("Kies een nummer om te kiezen wat je wilt doen");
                Console.WriteLine("[1]prijzen aanpassen\n[2]Reserveringen bekijken\n");
                nummer = Console.ReadLine();
                /*if (nummer == "1")
                {
                    Menus();
                }
                else if (nummer == "2")
                {
                    Reserveren();
                }
                else if (nummer == "3")
                {
                    ContactInfo();
                }
                else if (nummer == "4")
                {
                    ReviewViewer();
                }
                else
                {
                    Console.WriteLine("Uw ingevoerde keuze is niet juist");
                }*/

            }
            else
            {
                Console.WriteLine("U bent geen beheerder vervolgens kunt u geen veranderingen toevoegen");
            }

        }
    }
}
