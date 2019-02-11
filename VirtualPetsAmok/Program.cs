using System;
using System.Collections.Generic;

namespace VirtualPetsAmok
{
    class Program
    {
        public static PetShelter shelter = new PetShelter();

        static void Main(string[] args)
        {
            shelter.GameStart(shelter);
            Menu.MainMenu(shelter);
        }

    }
}
