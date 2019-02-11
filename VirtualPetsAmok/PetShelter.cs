using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VirtualPetsAmok
{
    public class PetShelter
    {
        public List<VirtualPet> Pets { get; set; }
        public int CurrentPet { get; set; }
        public int DirtinessLevel { get; set; }

        public VirtualPet firstPet;
        public VirtualPet pet;
        static Animations animation = new Animations();

        public PetShelter()
        {
            firstPet = new Organic();
            Pets = new List<VirtualPet>();
            Pets.Add(firstPet);
            CurrentPet = 0;
            pet = Pets[CurrentPet];
            DirtinessLevel = 0;
        }

        public void Add(VirtualPet pet)
        {
            Pets.Add(pet);
        }

        public void AllPets()
        {
            Console.Clear();
            int position = 0;
            foreach (VirtualPet pet in Pets)
            {
                Console.WriteLine((position += 1) + ". Name: " + pet.Name + "     Species: " + pet.Species + "      Type: " + pet.Type);
            }
            Console.WriteLine("Press any key to go to Main Menu.");
            Console.ReadKey();
            //MainMenu();
        }

        public void AllStatus()
        {
            AllOrganicStatus();
            AllRoboticStatus();
            Console.WriteLine("Press ENTER to go to the Main Menu");
            Console.ReadKey();

        }

        public void AllOrganicStatus()
        {
            var organicStatus = Pets.OfType<Organic>();
            foreach (Organic pet in organicStatus)
            {
                pet.DrawPicture();
                Console.WriteLine("Name: " + pet.Name);
                Console.WriteLine("Type: " + pet.Type);
                Console.WriteLine("Boredom: " + pet.Boredom);
                Console.WriteLine("Hunger: " + pet.Hunger);
                Console.WriteLine("Fatigue: " + pet.Fatigue);
                Console.WriteLine("Potty: " + pet.Potty);
                Console.WriteLine("Thirst: " + pet.Thirst);
                Console.WriteLine();
            }

        }

        public void AllRoboticStatus()
        {
            var robotStatus = Pets.OfType<Robotic>();
            foreach (Robotic pet in robotStatus)
            {
                pet.DrawPicture();
                Console.WriteLine("Name: " + pet.Name);
                Console.WriteLine("Type: " + pet.Type);
                Console.WriteLine("Oil Level: " + pet.OilLevel);
                Console.WriteLine("Battery Level: " + pet.BatteryLevel);
                Console.WriteLine("Temperature: " + pet.Temperature);
                Console.WriteLine();
            }
        }

        public void AllInteract()
        {
            Console.Clear();

            Console.WriteLine("Which type of pet would you like to interact with?");
            Console.WriteLine("1. Interact with All Organic Pets.");
            Console.WriteLine("2. Interact with All Robotic Pets.");
            switch (Console.ReadLine())
            {
                case "1":
                    AllOrganicInteract();
                    break;
                case "2":
                    AllRoboticInteract();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice. Press ENTER to try again.");
                    Console.ReadKey();
                    AllInteract();
                    break;
            }
        }

        public void AllOrganicInteract()
        {
            pet.Decay();
            Console.Clear();
            Console.WriteLine("What would you like to do with all your organic pets?");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Feed");
            Console.WriteLine("3. Sleep");
            Console.WriteLine("4. Take to Bathroom");
            Console.WriteLine("5. Give Water");
            Console.WriteLine("0. Go Back to Main Menu");

            string interactionSelection = Console.ReadLine();
            var organicPet = Pets.OfType<Organic>();

            switch (interactionSelection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You took your pets out to the park!");
                    Console.WriteLine("They had a great time!");
                    foreach (Organic pet in organicPet)
                    {
                        pet.Play();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All Organic pets are less bored.");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllOrganicInteract();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You fed all your pets!");
                    foreach (Organic pet in organicPet)
                    {
                        pet.Feed();

                    }
                    Console.WriteLine();
                    Console.WriteLine("All your pets are full!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllOrganicInteract();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Time to go night-night! You put your pets to bed!");
                    foreach (Organic pet in organicPet)
                    {
                        pet.Rest();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All Organic pets are well rested!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllOrganicInteract();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("You took your pets to the bathroom!");
                    foreach (Organic pet in organicPet)
                    {
                        pet.Poop();
                        CageDecay();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All your pets relieved themselves nicely");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllOrganicInteract();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("You gave all your pets water!");
                    foreach (Organic pet in organicPet)
                    {
                        pet.Drink();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All pets are much less thirsty!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllOrganicInteract();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection. Press ENTER to try again.");
                    Console.ReadKey();
                    AllRoboticInteract();
                    break;
            }
        }

        public void AllRoboticInteract()
        {
            pet.Decay();
            Console.Clear();
            Console.WriteLine("What would you like to do with your Robots?");
            Console.WriteLine("1. Oil Pet");
            Console.WriteLine("2. Charge Battery");
            Console.WriteLine("3. Cooldown");
            Console.WriteLine("0. Go check all pet status");

            var roboticType = Pets.OfType<Robotic>();
            string interactionSelection = Console.ReadLine();

            switch (interactionSelection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You gave your Robots some oil.");
                    Console.WriteLine("Robots are functioning properly.");
                    foreach (Robotic pet in roboticType)
                    {
                        pet.OilChange();
                        CageDecay();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All Robots are full of oil!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllRoboticInteract();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You plugged Robots in for a charge.");
                    foreach (Robotic pet in roboticType)
                    {
                        pet.ChargeBattery();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All Robots are fully charged!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllRoboticInteract();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("You cooled off your Robots.");
                    foreach (Robotic pet in roboticType)
                    {
                        pet.CoolDown();
                    }
                    Console.WriteLine();
                    Console.WriteLine("All Robots is are at optimal temperature!");
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadKey();
                    AllRoboticInteract();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection. Press ENTER to try again.");
                    Console.ReadKey();
                    AllRoboticInteract();
                    break;
            }
        }

        public void SwitchCurrentPet()
        {
            Console.Clear();
            Console.WriteLine("Which pet would you like to look after?");
            Console.WriteLine();

            int position = 0;
            foreach (VirtualPet line in Pets)
            {
                Console.WriteLine((position += 1) + ". Name: " + line.Name + "    Species: " + line.Species + "    Type: " + line.Type);
            }

            CurrentPet = Int32.Parse(Console.ReadLine());
            CurrentPet--;

            pet = Pets[CurrentPet];

            Console.Clear();
            Console.WriteLine("Your current pet is now " + pet.Name + "!");
            Console.WriteLine("Press ENTER to continue.");
            Console.ReadKey();
        }

        public void CreatePet()
        {
            Console.Clear();
            Console.WriteLine("What kind of pet would you like to make?");
            Console.WriteLine("1. Organic Pet");
            Console.WriteLine("2. Robotic Pet");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateOrganicPet();
                    break;
                case "2":
                    CreateRoboticPet();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice. Press ENTER to try again");
                    Console.ReadKey();
                    CreatePet();
                    break;
            }
        }

        public void CreateOrganicPet()
        {
            Organic newPet = new Organic();
            bool namePet = true;
            while (namePet)
            {
                Console.Clear();
                Console.WriteLine("Please name your new pet: ");
                newPet.Name = Console.ReadLine();
                if (newPet.Name.Length < 1)
                {
                    continue;
                }
                else
                {
                    namePet = false;
                }
            }
            Console.Clear();
            bool runNew = true;
            do
            {
                Console.WriteLine("What species is your new pet?");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine();
                string speciesChoice = Console.ReadLine();

                switch (speciesChoice)
                {
                    case "1":
                        newPet.Species = "Dog";
                        runNew = false;
                        break;
                    case "2":
                        newPet.Species = "Cat";
                        runNew = false;
                        break;
                    default:
                        Console.WriteLine("Please choose either a dog or cat. Press ENTER to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (runNew);

            Pets.Add(newPet);

            Console.Clear();
            Console.WriteLine("Congratulations! Your new pet " + newPet.Species + ", " + newPet.Name + ", is ready to go!");
            Console.WriteLine("Press ENTER to go to the main menu.");
            Console.ReadKey();
        }

        public void CreateRoboticPet()
        {
            Robotic newPet = new Robotic();
            bool namePet = true;
            while (namePet)
            {
                Console.Clear();
                Console.WriteLine("Please name your new pet: ");
                newPet.Name = Console.ReadLine();
                if (newPet.Name.Length < 1)
                {
                    continue;
                }
                else
                {
                    namePet = false;
                }
            }
            Console.Clear();
            bool runNew = true;
            do
            {
                Console.WriteLine("What species is your new pet?");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine();
                string speciesChoice = Console.ReadLine();

                switch (speciesChoice)
                {
                    case "1":
                        newPet.Species = "Dog";
                        runNew = false;
                        break;
                    case "2":
                        newPet.Species = "Cat";
                        runNew = false;
                        break;
                    default:
                        Console.WriteLine("Please choose either a dog or cat. Press ENTER to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (runNew);

            Pets.Add(newPet);

            Console.Clear();
            Console.WriteLine("Congratulations! Your new pet " + newPet.Species + ", " + newPet.Name + ", is ready to go!");
            Console.WriteLine("Press ENTER to go to the main menu.");
            Console.ReadKey();
        }

        public void GameStart(PetShelter shelter)
        {

            pet = shelter.Pets[shelter.CurrentPet];
            Console.ReadKey();
            animation.Lights();
            animation.Lights();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome to");
            animation.Title();
            Console.WriteLine("Press ENTER to create your first pet.");
            Console.ReadKey();
            Console.Clear();

            bool run = true;
            do
            {
                Console.WriteLine("Please name your new pet.");
                pet.Name = Console.ReadLine();
                if (pet.Name.Length < 1)
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                Console.WriteLine("What species is your new pet?");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine();
                string speciesChoice = Console.ReadLine();

                switch (speciesChoice)
                {
                    case "1":
                        pet.Species = "Dog";
                        run = false;
                        break;
                    case "2":
                        pet.Species = "Cat";
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Please choose either a dog or cat. Press ENTER to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (run);

            Console.Clear();
            Console.WriteLine("Congratulations! Your new pet " + pet.Species + ", " + pet.Name + ", is ready to go!");
            Console.WriteLine("Press ENTER to go to the main menu.");
            Console.ReadKey();
        }

        public void RemovePet()
        {
            Console.Clear();
            Console.WriteLine("Which pet would you like to remove?");
            Console.WriteLine();

            int position = 0;
            foreach (VirtualPet line in Pets)
            {
                Console.WriteLine((position += 1) + ". Name: " + line.Name + "     Species: " + line.Species);
            }

            CurrentPet = Int32.Parse(Console.ReadLine());
            CurrentPet--;

            if (Pets.Count > 1)
            {
                Console.Clear();
                Console.WriteLine("You removed " + pet.Name + " from the shelter.");
                Pets.Remove(Pets[CurrentPet]);
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Can't remove the last pet from the shelter.");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadKey();
            }
        }


        public void CleanCages()
        {
            DirtinessLevel = 0;
        }

        public void CageDecay()
        {
            Random random = new Random();

            DirtinessLevel += random.Next(5, 10);
            if (DirtinessLevel > 100)
            {
                DirtinessLevel = 100;
            }
        }

        public string ShelterCleanStatus()
        {
            if (DirtinessLevel > 90)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                return "SHELTER TOO DIRTY. PLEASE CLEAN IMMEDIATELY";


            }
            else if (DirtinessLevel > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "Shelter need cleaning.";
            }
            else
            {
                return "Clean";
            }


        }
    }
}
