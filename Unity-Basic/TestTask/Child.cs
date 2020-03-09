using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Child
    {
        public string _name;
        public List<int> Bill { get; set; }
        
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

        public Child(string name)

        {
            Name = name;
            Bill = new List<int>();
        }

        public List<int> addApples (int numberOfApples)
        {
            if (Bill.Count == 0)
                Bill.Add(numberOfApples);
            else
                Bill.Add(Bill[Bill.Count - 1] + numberOfApples);
            return Bill;
        }

    }
}
