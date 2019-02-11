using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualPetsAmok
{
    public abstract class VirtualPet
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }

        public abstract void Decay();

        public abstract void ShowStatus();

        public abstract void ShowInfo();

        public abstract void PetInteractions(PetShelter shelter);

        public void DrawPicture()
        {
            if (Species == "Dog")
            {
                //Print dog
                Console.WriteLine(@"    ___");
                Console.WriteLine(@" __/_  `.  .-''' -.");
                Console.WriteLine(@" \_,` | \-'  /   )`-')");
                Console.WriteLine(@"  '') `'`    \  ((`'`");
                Console.WriteLine(@" ___Y  ,    .'7 /|");
                Console.WriteLine(@"(_,___/...-` (_/_/");
                Console.WriteLine();
                Console.WriteLine();

            }
            else if (Species == "Cat")
            {
                //Print cat
                Console.WriteLine(@"   |\---/|");
                Console.WriteLine(@"   | ,_, |");
                Console.WriteLine(@"    \_`_/-..----.");
                Console.WriteLine(@" ___/ `   ' ,''+ \ ");
                Console.WriteLine(@"(__...'   __\    |`.___.';");
                Console.WriteLine(@"  (_,...'(_,.`__)/'.....+");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}
