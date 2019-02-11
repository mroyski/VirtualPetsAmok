using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPetsAmok
{
    public class Organic : VirtualPet
    {
        public int Hunger { get; private set; }
        public int Fatigue { get; private set; }
        public int Thirst { get; private set; }
        public int Boredom { get; private set; }
        public int Potty { get; private set; }

        public Organic()
        {
            Random rnd = new Random();
            Type = "Organic";
            Hunger = rnd.Next(20, 50);
            Fatigue = rnd.Next(20, 50);
            Thirst = rnd.Next(20, 50);
            Boredom = rnd.Next(20, 50);
            Potty = rnd.Next(20, 50);
        }

        public void Feed()
        {
            Random rnd = new Random();

            Hunger -= rnd.Next(5, 10);
            
            if (Hunger < 0)
            {
                Hunger = 0;
            }
        }

        public void Rest()
        {
            Fatigue = 0;
        }

        public void Drink()
        {
            Random rnd = new Random();

            Thirst -= rnd.Next(5, 10);

            if (Thirst < 0) { Thirst = 0; }
        }

        public void Play()
        {
            Random rnd = new Random();

            Boredom -= rnd.Next(5, 10);
            if (Boredom < 0) { Boredom = 0; }
        }

        public void Poop()
        {
            Potty = 0;
        }

        public override void Decay()
        {
            Random random = new Random();
            
            Hunger += random.Next(1, 5);
            Thirst += random.Next(1, 5);
            Boredom += random.Next(1, 5);
            Potty += random.Next(1, 5);
            Fatigue += random.Next(1, 5);

            if (Hunger > 100)
            {
                Hunger = 100;
            }
            if (Thirst > 100)
            {
                Thirst = 100;
            }
            if (Potty > 100)
            {
                Potty = 100;
            }
            if (Boredom > 100)
            {
                Boredom = 100;
            }
            if (Fatigue > 100)
            {
                Fatigue = 100;
            }
        }

        public override void ShowStatus()
        {
            Console.Clear();
            DrawPicture();
            Console.WriteLine("Boredom: " + Boredom);
            Console.WriteLine("Hunger: " + Hunger);
            Console.WriteLine("Fatigue: " + Fatigue);
            Console.WriteLine("Potty: " + Potty);
            Console.WriteLine("Thirst: " + Thirst);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to the Main Menu.");
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

        public override void PetInteractions(PetShelter shelter)
        {
            Console.Clear();

            Decay();
            Console.WriteLine("What would you like to do with " + Name + "?");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Feed");
            Console.WriteLine("3. Sleep");
            Console.WriteLine("4. Take to Bathroom");
            Console.WriteLine("5. Give Water");
            Console.WriteLine("0. Go Back to Main Menu");

            string interactionSelection = Console.ReadLine();

            switch (interactionSelection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You took " + Name + " out to the park!");
                    Console.WriteLine(Name + " had a great time!");
                    Play();
                    Console.WriteLine();
                    Console.WriteLine(Name + "'s Boredom is now: " + Boredom);
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(Name + " devoured its food!");
                    Feed();
                    Console.WriteLine();
                    Console.WriteLine(Name + "'s Hunger is now: " + Hunger);
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Zzzzzzzzzzzzzzzzzzz. " + Name + " is taking a nap...");
                    Rest();
                    Console.WriteLine();
                    Console.WriteLine(Name + " is now fully rested!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine(Name + " sniffs around...");
                    Console.WriteLine(Name + " left a mess!");
                    Poop();
                    shelter.CageDecay();
                    Console.WriteLine();
                    Console.WriteLine(Name + " successfully relieved itself!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    PetInteractions(shelter);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine(Name + " drinks some water!");
                    Drink();
                    Console.WriteLine(Name + " looks pleased!");
                    Console.WriteLine();
                    Console.WriteLine(Name + "'s thirst is now: " + Thirst);
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
