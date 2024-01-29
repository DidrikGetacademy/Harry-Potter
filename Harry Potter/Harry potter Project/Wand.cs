using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Wand : Item
    {
   
        public string Wandtype { get; set; }
        public int Damage { get; set; }

        public Wand(string wandtype,int damage) : base(wandtype)
        {
            Wandtype = wandtype;
            Damage = damage;
        }
    }
}
