using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Provider Provider { get; set; }
        public List<Category> Categories { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }


        public Product(bool FromConsole)
        {
            if (FromConsole)
            {
                Console.WriteLine("Input Product ID");
                ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Product Name");
                Name = Console.ReadLine();
                Console.WriteLine("Input Product Weight");
                Weight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input Product Provider ID");
                Provider.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Product Category IDs");
                if (Console.ReadLine() == "/n")
                Provider.ID = Convert.ToInt32(Console.ReadLine());

            }
                    else
            { }
        }
    }
}
