using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Galtvort
    {
        public List<character> characters { get; set; }
        public Magicshop magicshop { get; set; }
        public Galtvort(Magicshop shop)
        {
            //3 av de må være type chaser,
            //2 av de må være type beater
            //1 keeper
            //1 seeker
            magicshop = shop;
            characters = new List<character>()
            {
                new character("Harry Potter", "Gryffindor","Seeker"),
                new character("Hermoine Granger", "Gryffindor","Keeper"),
                new character("Ron weasly", "Gryffindor","chaser"),
                new character("Ginny Weasley", "Gryiffindor","chaser"),
                new character("Neville Longbottom","Gryffindor","chaser"),

                new character("Michael Corner", "ravenclaw","beater"),
                new character("Cho Chang", "ravenclaw","beater"),
                new character("Xenofilius Lovegood", "ravenclaw","Seeker"),


                new character("Severus Snape", "smygard","Keeper"),
                new character("Tom Riddle", "smygard","chaser"),
                new character("Bellatrix LeStrange", "smygard","chaser"),


                new character("Hannah Abbott", "Håsblås","chaser"),
                new character("Justin Finch-Fletchley", "Håsblås","beater"),
                new character("Zacharias Smith", "Håsblås","beater"),
               
        };
        }

   

        private bool program = true;
        public void Menu(Magicshop shop,Galtvort galtvort,Wand wand,character Character)
        {
            galtvortIntroduction();
            Console.WriteLine();
            Console.WriteLine($"What member do you want too play as?");
            var member = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Welcome to Galtvort MagicSchool {member}");
            if (characters.Any(x => x.Name == member))
            {

                var ingameuser = characters.Find(x => x.Name == (member));
                
                while (program)
                {
                    Console.WriteLine();
                    Console.WriteLine("1.EnterMagic shop");
                    Console.WriteLine("2.Inventory");
                    Console.WriteLine("3.send message/check messages");
                    Console.WriteLine("4.Go to hogwarts");
                    Console.WriteLine("5.Fight Voldemort");
                    Console.WriteLine("6.Perform Magic");
                    Console.WriteLine("7.Quidditch");
                    var Userinput = Console.ReadLine();

                    switch (Userinput)
                    {
                        case "1":
                           ingameuser.leavehogwart(shop, galtvort,wand,Character);
                            break;

                        case "2":
                            ingameuser.InventoryList();
                            break;

                        case "3":
                            ingameuser.checkorSendMessages(galtvort);
                            break;
                        case "4":
                            ingameuser.gotohogwarts(shop, galtvort, wand, Character);
                            break;
                        case "5":
                            ingameuser.fightVoldemort(wand, Character, galtvort);
                            break;
                        case "6":
                            ingameuser.PerformMagic();
                            break;
                        case "7":
                            ingameuser.checkforBrooms(new QuidDitch(galtvort));
                                break;
                }
                }
            }
        }

        public bool enterProgram()
        {
            return program = true;
        }
        public bool leaveProgram()
        {
            return program = false;
        }

        public void galtvortIntroduction()
        {
            Console.WriteLine("Welcome to Galtvort");
            House();

       
        }

        void House()
        {
            foreach (var Character in characters)
            {
                Character.introduction();
            }
        }
    }
}
