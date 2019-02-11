using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPetsAmok
{
    public class Robotic : VirtualPet
    {
        public int OilLevel { get; private set; }
        public int BatteryLevel { get; private set; }
        public int Temperature { get; private set; }

        public Robotic()
        {
            Random rnd = new Random();
            Type = "Robotic";
            OilLevel = rnd.Next(20, 50);
            BatteryLevel = rnd.Next(20, 50);
            Temperature = rnd.Next(20, 50);
        }

        public void OilChange()
        {
            OilLevel = 100;

        }
        
        public void ChargeBattery()
        {
            BatteryLevel = 100;
        }

        public void CoolDown()
        {
            Temperature = 0;
        }

        public override void ShowStatus()
        {
            Console.Clear();
            DrawPicture();
            Console.WriteLine("Oil Level: " + OilLevel);
            Console.WriteLine("Battery Level: " + BatteryLevel);
            Console.WriteLine("Temperature: " + Temperature);
            Console.WriteLine("Press Enter to return to the Main Menu");
            Console.ReadKey();
        }

        public override void ShowInfo()
        {
            Console.Clear();
            DrawPicture();
            Console.WriteLine("Pet Name: " + Name);
            Console.WriteLine("Pet Type: " + Type);
            Console.WriteLine("Pet Species: " + Species);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the Main Menu.");
            Console.ReadKey();
        }

        public override void Decay()
        {
            Random random = new Random();

            OilLevel -= random.Next(1, 5);
            BatteryLevel -= random.Next(1, 5);
            Temperature += random.Next(1, 5);

            if (Temperature > 100)
            {
                Temperature = 100;
            }
            if (OilLevel < 0)
            {
                OilLevel = 0;
            }
            if (BatteryLevel < 0)
            {
                BatteryLevel = 0;
            }
        }

        public override void PetInteractions(PetShelter shelter)
        {
            
            Console.Clear();
            
            Decay();
            Console.WriteLine("What would you like to do with " + Name + "?");
            Console.WriteLine("1. Oil Pet");
            Console.WriteLine("2. Charge Battery");
            Console.WriteLine("3. Cooldown");
            Console.WriteLine("0. Go Back to Main Menu");

            string interactionSelection = Console.ReadLine();

            switch (interactionSelection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You gave " + Name + " some oil.");
                    Console.WriteLine(Name + " is functioning properly.");
                    OilChange();
                    shelter.CageDecay();
                    Console.WriteLine();
                    Console.WriteLine(Name + "'s Oil Level is now " + OilLevel);
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You plugged " + Name + " in for a charge.");
                    ChargeBattery();
                    Console.WriteLine();
                    Console.WriteLine(Name + "'s Battery Level is now: " + BatteryLevel);
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("You cooled off " + Name);
                    CoolDown();
                    Console.WriteLine();
                    Console.WriteLine(Name + " is now cooled off!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "0":
                    Menu.MainMenu(shelter);
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection. Press ENTER to try again.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;

            }

        }
    }
}