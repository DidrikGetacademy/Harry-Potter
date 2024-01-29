using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Voldemort
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        private  Random rand = new Random();
        public Voldemort(int health,string name)
        {
            Name = name;
            Health = health;
            Damage = rand.Next(30, 50);
        }

        public void VoldemortFight(character Character,Galtvort galtvort)
        {
            var Usercharacter = galtvort.characters.FirstOrDefault();
            Character.Health -= Damage;
            Console.WriteLine($"{Name} hit {Usercharacter.Name} with {Damage}");
            Console.WriteLine($"{Usercharacter.Name} has {Character.Health} Health");
            Console.WriteLine();

        }
    }
}












