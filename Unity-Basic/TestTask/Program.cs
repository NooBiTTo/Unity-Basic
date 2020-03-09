using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Child masha = new Child("Masha");
            masha.addApples(5);
            masha.addApples(10);
            masha.addApples(20);
        }
    }
}
