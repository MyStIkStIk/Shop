using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClothesShop HiM = new ClothesShop();
            HiM.veshci = new Tovar[6];
            HiM.veshci[0] = new Shorti("Льон", "S", 50.9, "Шорты");
            HiM.veshci[1] = new Jeansi("Джинс", "M", 50.9, "Джинсы");
            HiM.veshci[2] = new Krosovki("Ткань", "43", 50.9, "Кроссовки");
            HiM.veshci[3] = new Tufli("Кожа", "38", 50.9, "Туфли");
            HiM.veshci[4] = new Futbolki("Хлопок", "L", 50.9, "Футболка");
            HiM.veshci[5] = new Kengurushki("Синтетическая ткань", "XL", 50.9, "Кенгурушка");
            HiM.OstatokNaSklade();
            HiM.veshci[3].Koupit();
            HiM.OstatokNaSklade();

        }
    }
    class ClothesShop
    {
        public Tovar[] veshci { get; set; }
        Tovar[] veshci1 { get; set; }
        public void OstatokNaSklade()
        {
            for(int i = 0; i < veshci.Length; i++)
            {
                veshci[i].ClothInfo();
            }
        }
    }
    class Tovar : ClothesShop
    {
        protected double cena { get; set; }
        protected string material { get; set; }
        protected string razmer { get; set; }
        public string name { get; }
        protected Tovar(double cena, string material, string razmer, string name)
        {
            this.cena = cena;
            this.material = material;
            this.razmer = razmer;
            this.name = name;
        }
        public virtual void ClothInfo()
        {
            Console.WriteLine(name);
            Console.WriteLine(razmer);
            Console.WriteLine(material);
            Console.WriteLine(cena);
                
        }
        public void Koupit()
        {
            Console.WriteLine($"У нас купили {name}");
            if (this is Shorti || this is Krosovki)
                Console.WriteLine($"Стоимость с учетом скидки - {cena * 0.7}");
            else
                Console.WriteLine($"Стоимость - {cena}");
        }
        public virtual void Nadet() { }
    }
    class Shtani : Tovar
    {
        public string dlinaShtaniny { get; set; }
        protected Shtani(string dlinaShtaniny, string material, string razmer, double cena, string name) :base(cena, razmer, material, name)
        {
            this.dlinaShtaniny = dlinaShtaniny;
        }
        public override void Nadet()
        {
            if (this is Shorti)
            {
                Console.WriteLine("Жара...надеть шорты");
            }
            else if (this is Jeansi)
            {
                Console.WriteLine("Надеть джинсы и быть самым модным");
            }
        }
        public override void ClothInfo()
        {
            base.ClothInfo();
            Console.WriteLine(dlinaShtaniny);
            Console.WriteLine();
        }
    }
    class Shorti : Shtani
    {
        static string dlinaShtaniny { get { return "короткая штанина"; } }
        public Shorti(string material, string razmer, double cena, string name) : base (dlinaShtaniny, material, razmer, cena, name) { }
    }
    class Jeansi : Shtani
    {
        static string dlinaShtaniny { get { return "длинная штанина"; } }
        public Jeansi(string material, string razmer, double cena, string name) : base(dlinaShtaniny, material, razmer, cena, name) { }
    }
    class Obuv : Tovar
    {
        string vidobuvi { get; set; }
        protected Obuv( string material, string razmer, double cena, string vidobuvi, string name) : base(cena, razmer, material, name)
        {
            this.vidobuvi = vidobuvi;
        }
        public override void Nadet()
        {
            if (this is Krosovki)
            {
                Console.WriteLine("Обуть кроссовки, а дальше и напробежечку можно))");
            }
            else if (this is Tufli)
            {
                Console.WriteLine("Обуть туфли и в офис(((");
            }
        }
        public override void ClothInfo()
        {
            base.ClothInfo();
            Console.WriteLine(vidobuvi);
            Console.WriteLine();
        }
    }
    class Krosovki : Obuv
    {
        static string vidobuvi { get { return "спортивная обувь"; } }
        public Krosovki(string material, string razmer, double cena, string name) : base(material, razmer, cena, vidobuvi, name) { }
    }
    class Tufli : Obuv
    {
        static string vidobuvi { get { return "офисная обувь"; } }
        public Tufli(string material, string razmer, double cena, string name) : base(material, razmer, cena, vidobuvi, name) { }
    }
    class Kofti : Tovar
    {
        string dlinaRukava { get; set; }
        protected Kofti( string material, string razmer, double cena, string dlinaRukava, string name) : base(cena, razmer, material, name)
        {
            this.dlinaRukava = dlinaRukava;
        }
        public override void Nadet()
        {
            if(this is Futbolki)
            {
                Console.WriteLine("Надеть футболку");
            }
            else if (this is Kengurushki)
            {
                Console.WriteLine("Надеть кенгурушку");
            }
        }
        public override void ClothInfo()
        {
            base.ClothInfo();
            Console.WriteLine(dlinaRukava);
            Console.WriteLine();
        }
    }
    class Futbolki : Kofti
    {
        static string dlinaRukava { get { return "короткий рукав"; } }
        public Futbolki(string material, string razmer, double cena, string name) : base(material, razmer, cena, dlinaRukava, name) { }
    }
    class Kengurushki : Kofti
    {
        static string dlinaRukava { get { return "длинный рукав"; } }
        public Kengurushki(string material, string razmer, double cena, string name) : base(material, razmer, cena, dlinaRukava, name) { }
    }
}
