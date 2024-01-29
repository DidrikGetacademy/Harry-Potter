using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Magicshop
    {
     public  List<Pet> shopPets { get; set; }

     public  List<Wand> shopWands { get; set; }

     public List<Brooms> brooms { get; set; }

     
     
        public Magicshop()
        {
            shopPets = new List<Pet>() {new Pet("Ugle"), new Pet("Rotte"), new Pet("katt")};
            shopWands = new List<Wand>(){new Wand("Føniksstav",30),new Wand("UnikornStav",40),new Wand("Trollstav",50)};
            brooms = new List<Brooms>(){ new Brooms("Nimbus 2000", 1000), new Brooms("Firebolt", 2000), new Brooms("Turbo XXX", 500) };
        }
    

        public Item shopdisplay()
        {
            Console.WriteLine("Welcome to olivanders: select pets (p), wands (w), Brooms (b)");
            var input = Console.ReadLine();
            if (input == "p")
            {
                printpetsMenu();
                Console.WriteLine("what pet do you want too buy? ");

                var petselection  = Console.ReadLine();
                return shopPets.Find(x=> x.ItemName == petselection);

            } 
            if(input == "w")
            {
                printwandsMenu();
                Console.WriteLine("what wand do you want too buy?");
                var wandselection = Console.ReadLine();
                return shopWands.Find(x=> x.ItemName == wandselection) ;

            }

            if (input == "b")
            {
                PrintBroomsMenu();
                Console.WriteLine("What broom do you want too buy?");
                var broomselection = Console.ReadLine();
                return brooms.Find(x => x.ItemName == broomselection);
            }
            else
            {
                Console.WriteLine("Incorrect Choice");
                return shopdisplay();
            }
        }



    public void printpetsMenu()
       {
           Console.WriteLine();
           foreach (var pet in shopPets)
           {
                Console.WriteLine("Name: "+ pet.PetType );
           }
        }

       public void printwandsMenu()
       {
           Console.WriteLine();
            foreach (var wands in shopWands) 
            {
               Console.WriteLine("Wand: " + wands.ItemName + " Damage: " + wands.Damage);
            }
        }

       public void PrintBroomsMenu()
       {
           Console.WriteLine();
           foreach (var broom in brooms)
           {
               Console.WriteLine("Broom " + broom.ItemName + " Speed: " + broom.Speed);
           }
       }
    }
   
}


