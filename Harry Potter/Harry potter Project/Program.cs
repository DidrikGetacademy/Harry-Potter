using Harry_potter_Project;

namespace Harry_potter_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wand wand = new Wand(" ", 0);
            character character = new character("", "", "");
            Magicshop shop = new Magicshop();
            Galtvort galtvort  = new Galtvort(shop);

            galtvort.Menu(shop, galtvort, wand, character);
        }
    }
}





 












































