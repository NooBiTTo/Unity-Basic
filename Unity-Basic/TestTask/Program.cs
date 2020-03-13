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
            Goverment goverment = new Goverment("Arstotzka");
            goverment.addChild("Masha");
            goverment.addChild("Dasha");
            goverment.addApplesToChild(goverment.Children[0]);
            goverment.addApplesToChild(goverment.Children[0]);
            goverment.addApplesToChild(goverment.Children[0]);
            goverment.addApplesToChild(goverment.Children[1]);
            goverment.addApplesToChild(goverment.Children[1]);
          

        }
    }
}
