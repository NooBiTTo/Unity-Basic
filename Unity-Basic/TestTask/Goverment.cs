using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Goverment
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
        }


        private string _name;

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

        private List<int> GovermentTaxes { get; set; }
        private List<int> ApplesTotal { get; set; }
        public List<Child> Children { get; private set; }
        private int Offset { get; set; } = 0;
        private int LastApplesIncreace { get; set; } = 0;

        private int LastTax { get; set; } = 0;

        public Goverment(string name)

        {
            Name = name;
            GovermentTaxes = new List<int>();
            ApplesTotal = new List<int>();
            Children = new List<Child>();
            Console.WriteLine($"Создано государство {name}!");
        }

        public void addChild(string name)
        {
            Child newChild = new Child(name);
            Children.Add(newChild);
            Console.WriteLine($"Ребенок {newChild.Name} добавлен в государство {Name}.");
        }



        public void addApplesToChild(Child child, int numberOfApples)
        {
            
            int lastBill;
            if (child.Bill.Count == 0)
            {
                lastBill = 0;
                child.Bill.Add(numberOfApples - LastTax);
            }
            else
            {
                lastBill = child.Bill.Last();
                child.Bill.Add(child.Bill.Last() + numberOfApples - LastTax);
            }
            Console.WriteLine($"Ребенок {child.Name} добавил себе {numberOfApples} яблок и у него их стало {child.Bill.Last()}, однако государство {Name} их изъяло.");
            increaseApplesCount(numberOfApples);
            govermentTaxes();
            memberPartCalc(numberOfApples - LastTax, child, lastBill);
        }


        public void addApplesToChild(Child child)
        {
            Console.WriteLine($"ВВедите сколько яблок добыл ребенок {child.Name}.");
            int numberOfApples = Convert.ToInt32(Console.ReadLine());
            addApplesToChild(child, numberOfApples);

        }
        private void increaseApplesCount(int numberOfApples)
        {
            if (ApplesTotal.Count == 0)
            {
                ApplesTotal.Add(numberOfApples);
            }
            else
            {
                ApplesTotal.Add(ApplesTotal.Last() + numberOfApples);
            }
            LastApplesIncreace = numberOfApples;
            Console.WriteLine($"Эти {LastApplesIncreace} яблок поступили в оборот государства {Name}. Теперь их в обороте {ApplesTotal.Last()}.");
        }
        private void govermentTaxes()
        {
            int lastTax = Convert.ToInt32(LastApplesIncreace * 0.3);
            {
                if (GovermentTaxes.Count == 0)
                {
                    GovermentTaxes.Add(lastTax);
                }
                else
                {
                    GovermentTaxes.Add(GovermentTaxes.Last() + lastTax);
                }
            }
            LastTax = lastTax;
            Console.WriteLine($"Из поступивших в оборот яблок, государство {Name} изъяло {LastTax} яблок в качестве налога. Теперь в казне {GovermentTaxes.Last()} яблок.");
        }

        private void memberPartCalc(int lastApples, Child child, int lastBill)
        {
            int residual = lastApples % Children.Count;
            int[] memberBallance = new int[Children.Count];
            
            for (int j = residual; j > 0; j--)
            {
                Console.WriteLine($"Поступившие для распределения {lastApples} яблок невозможно равномерно распределить между {Children.Count} детьми.");
                int f = Offset;
                if (f >= Children.Count)
                {
                    Offset = 0;
                    f = 0;
                }
                memberBallance[f] = 1;
                Offset++;
            }

            for (int i = 0; i < Children.Count; i++)
            {
                memberBallance[i] += ((lastApples - residual) / Children.Count);
                int tempBill;
                if (Children[i] == child)
                {
                    Children[i].Bill.Add(lastBill + memberBallance[i]);
                }
                else
                {
                    if (Children[i].Bill.Count != 0)
                    {
                        tempBill = Children[i].Bill.Last();
                        Children[i].Bill.Add(tempBill + memberBallance[i]);
                    }
                    else
                    {
                        Children[i].Bill.Add(memberBallance[i]);
                    }
                }
                Console.WriteLine($"После перераспределения яблок поровну между всеми детьми, у {Children[i].Name} - {Children[i].Bill.Last()} яблок.");
            }
        }
    }
}

