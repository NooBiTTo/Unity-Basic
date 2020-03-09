using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Child
    {
        private string _name;
        private List<int> Bill { get; set; }

        private int ChildrenCount { get; set; } = 0;
        private static List<int> GovermentTaxes { get; set; }
        private static List<int> ApplesCount { get; set; }


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "")
                    throw new Exception("Имя не может быть пустым");
                else
                    _name = value;
            }
        }

        static Child()
        {
            GovermentTaxes = new List<int>();
            ApplesCount = new List<int>();
        }
        public Child(string name)

        {
            Name = name;
            Bill = new List<int>();
            ChildrenCount++;
        }

        public List<int> addApples (int numberOfApples)
        {
            this.increaseApplesCount(numberOfApples);
            this.govermentTaxes();
            if (Bill.Count == 0)
            {
                Bill.Add(numberOfApples);
            }
            else
            {
                Bill.Add(Bill[Bill.Count - 1] + numberOfApples);
            }

            return Bill;
        }

        private List<int> increaseApplesCount (int numberOfApples)
        {
            if (ApplesCount.Count == 0)
            {
                ApplesCount.Add(numberOfApples);
            }
            else
            {
                ApplesCount.Add(ApplesCount[ApplesCount.Count - 1] + numberOfApples);
            }

            return ApplesCount;
        }
        
        private List<int> govermentTaxes ()
        {
            GovermentTaxes.Add(ApplesCount[ApplesCount.Count - 1] / 3);
            return GovermentTaxes;           
        }

    }
}
