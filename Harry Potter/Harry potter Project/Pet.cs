using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_potter_Project
{
    public class Pet : Item
    {
        public string PetType { get; set; }

        public Pet(string pettype) : base(pettype)
        {
            PetType = pettype;
        }

    }
}
