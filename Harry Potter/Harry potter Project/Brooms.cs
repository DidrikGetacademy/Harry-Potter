using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Brooms : Item
    {
        public string BroomType { get; set; }

        public int Speed { get; set; }
        public Brooms(string itemName, int speed) : base(itemName)
        {
            BroomType = itemName;
            Speed = speed;
        }
    }
}
