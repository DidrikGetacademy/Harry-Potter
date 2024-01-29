using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Net.Mime.MediaTypeNames;

namespace Harry_potter_Project
{
    public class character
    {


        public string Name { get; set; }

        public string House { get; set; }
        public string Role { get; set; }

        public List<Pet> pets { get; set; }

        public List<Wand> wands { get; set; }

        public int Score { get; set; }
        public List<Brooms> broom { get; set; }

        public List<string> message { get; set; }

        public int Health { get; set; }

        public Voldemort voldemort { get; set; }



        public character(string name, string house, string role)
        {
            Score = 0;
            Role = role;
            Name = name;
            House = house;
            pets = new List<Pet>();
            wands = new List<Wand>();
            broom = new List<Brooms>();
            message = new List<string>();
            Health = 100;
            voldemort = new Voldemort(100, "Voldemort");
          

        }

        public void introduction()
        {
            Console.WriteLine($"Name: {Name}, Member: {House}");
        }

        public void leavehogwart(Magicshop shop, Galtvort galtvort, Wand wand, character Character)
        {
            EnterMagicshop(shop, galtvort, wand, Character);
        }

        public void leavestore(Magicshop shop, Galtvort galtvort, Wand wand, character Character)
        {
            gotohogwarts(shop, galtvort, wand, Character);
        }

        public void gotohogwarts(Magicshop shop, Galtvort galtvort, Wand wand, character Character)
        {
            Console.WriteLine("Welcome to hogwarts");
            Console.WriteLine("1.Change Character");
            Console.WriteLine("2.Enter menu");
            Console.WriteLine("3.Exit Hogwarts");
            var userinput = Console.ReadLine();
            if (userinput == "1")
            {
                galtvort.Menu(shop, galtvort, wand, Character);
            }
            else if (userinput == "2")
            {
                galtvort.enterProgram();
            }
            else if (userinput == "3")
            {
                galtvort.leaveProgram();
            }
        }



        public void EnterMagicshop(Magicshop shop, Galtvort galtvort, Wand wand, character Character)
        {
            var item = shop.shopdisplay();
            BuyItem(item, shop, galtvort, wand, Character);
        }


        public void BuyItem(Item item, Magicshop shop, Galtvort galtvort, Wand wand, character Character)
        {
            if (item is Pet)
            {
                Pet Soldpet = (Pet)item;
                pets.Add(Soldpet);
                Console.WriteLine();
                Console.WriteLine($"Congratz you bought: {Soldpet.PetType} ");
            }
            else if (item is Wand)
            {
                Wand soldWand = (Wand)item;
                wands.Add(soldWand);
                Console.WriteLine();
                Console.WriteLine($"Congratz you bought: {soldWand.Wandtype} ");
            }
            else if (item is Brooms)
            {
                Brooms soldbroom = (Brooms)item;
                broom.Add(soldbroom);
                Console.WriteLine();
                Console.WriteLine($"Congratz you bought: {soldbroom.BroomType}");
            }
            else
            {
                Console.WriteLine("this item is not in the store");
            }

            leavestore(shop, galtvort, wand, Character);
        }


        public void PerformMagic()
        {
            Console.WriteLine("What is your MagicSpell?");
            var input = Console.ReadLine();
            if (input == "vingardium leviosa")
            {
                VingardiumLeviosa();
            }
            else if (input == "hokus pokus")
            {
                HokusPokus();
            }
            else
            {
                Console.WriteLine("Wrong Spell, try again");
                PerformMagic();
            }
        }

        void VingardiumLeviosa()
        {
            Console.WriteLine("Magicspell: Feather is flying");
        }


        void HokusPokus()
        {
            Console.WriteLine("Magicspell: ignited Fireworks to the sky ");
        }


        void CheckPetListUgle(Galtvort galtvort)
        {
            if (pets.Contains(pets.Find(x => x.PetType == "Ugle")))
            {
                SendLetterToCharacter(galtvort);
            }
            else
            {
                Console.WriteLine("you don't have a owl, you can't send a message");
            }
        }

        void SendLetterToCharacter(Galtvort galtvort)
        {
            Console.WriteLine("Write the name of the character that will receive the message");
            var Choosencaracter = Console.ReadLine();
            if (galtvort.characters.Any(x => x.Name == Choosencaracter))
            {
                SendMessage(Choosencaracter, galtvort);
            }
            else
            {
                Console.WriteLine("The member you wrote does not exist at galtvort");
            }
        }

        void SendMessage(string Choosencaracter, Galtvort galtvort)
        {
            Console.WriteLine("Write the message you want too send");
            var Sendingmessage = Console.ReadLine();
            var messagereciver = galtvort.characters.Find(x => x.Name == Choosencaracter);
            messagereciver.message.Add(Sendingmessage);
        }



        void Message()
        {
            Console.WriteLine("messages:");
            foreach (var message in message)
            {
                Console.WriteLine($"-{message}");
            }
        }


        public void checkorSendMessages(Galtvort galtvort)
        {
            Console.WriteLine("1.check messages");
            Console.WriteLine("2.send message");
            var userinput = Console.ReadLine();
            if (userinput == "1")
            {
                if (message.Count >= 1)
                {
                    Message();
                }
                else
                {
                    Console.WriteLine("You have 0 message");
                }
            }
            else if (userinput == "2")
            {
                CheckPetListUgle(galtvort);
            }
            else
            {
                Console.WriteLine("Wrong Input, try again");
            }
        }


        public void InventoryList()
        {
            printpets();
            PrintWands();
            printBrooms();

        }

        void printpets()
        {
            Console.WriteLine($"Number of pets in inventory: {pets.Count}");
            foreach (var pet in pets)
            {
                Console.WriteLine("Pet: " + pet.PetType);
            }

            if (pets.Count <= 0)
            {
                Console.WriteLine("You don't have any pets, You can buy pets in MagicShop");
            }
        }

        void PrintWands()
        {
            Console.WriteLine();
            Console.WriteLine($"Number of wands in inventory: {wands.Count}");
            foreach (var wand in wands)
            {
                Console.WriteLine($"Wand: {wand.Wandtype}, Damage: {wand.Damage} ");
            }

            if (wands.Count <= 0)
            {
                Console.WriteLine("You don't have any wands, You can buy wands in MagicShop");
            }
        }

        void printBrooms()
        {
            Console.WriteLine();
            Console.WriteLine($"Number of brooms in inventory {broom.Count}");
            foreach (var brooms in broom)
            {
                Console.WriteLine($"broom: {brooms.BroomType}, Damage: {brooms.Speed}");
            }

            if (broom.Count <= 0)
            {
                Console.WriteLine("You dont have any brooms, you can buy in MagicShop");
            }
        }




        public void fightVoldemort(Wand wand, character Character,Galtvort galtvort)
        {
            if (wands.Count > 0)
            {
                IncreaseDamage(wand, Character,galtvort);
            }
        }

        public void IncreaseDamage(Wand wand, character Character,Galtvort galtvort)
        {
            while (!undefeated())
            {
                    IncreaseeDamage(wand, Character,galtvort);
                    voldemort.VoldemortFight(Character, galtvort);
                    if (undefeated())
                    {
                        Console.WriteLine($"Game over");
                        if (voldemort.Health < 0)
                        {
                            Console.WriteLine($"{Name} wins the fight!");
                        }
                        else
                        {
                            Console.WriteLine($"{voldemort.Name} wins the fight!");
                        }
                    }
            }
        }

        bool undefeated()
        {
            return voldemort.Health < 0 || Health < 0;
        }

        void IncreaseeDamage(Wand wand, character Character, Galtvort galtvort)
        {
            Console.WriteLine("1. Hit Voldemort");
            var userattack = Console.ReadLine();
            if (userattack == "1")
            {
                var CharacterWand = wands.FirstOrDefault();
                voldemort.Health -= CharacterWand.Damage;
                Console.WriteLine($"{Name} hit {voldemort.Name} with {CharacterWand.Damage}");
                Console.WriteLine($"{voldemort.Name} has {voldemort.Health} Health");
                Console.WriteLine();
           
            }
        }

        public void checkforBrooms(QuidDitch quid)
        {
            if (broom.Count > 0)
            {
               quid.PlayGame();
            }
            else
            {
                Console.WriteLine("You don't have any brooms. Buy one in the MagicShop to play in Quidditch.");
            }
        }

    }
}



