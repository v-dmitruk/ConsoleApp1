using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask
{
    class Front
    {
        static void Main(string[] args)
        {
            Application_Start();
            //ProductDBContext ProductDb = new ProductDBContext();
            EFProductRepository db = new EFProductRepository(new ProductDBContext());
            
            Product product1 = new Product();
            product1.ID = 1;
            product1.Name = "Car";
            product1.Price = 10;
            Provider provider1 = new Provider();
            provider1.ID = 2;
            provider1.Name = "Ford";

            product1.Provider = provider1;

            Category cat1 = new Category();
            cat1.ID = 3;
            cat1.Name = "Cars";

            product1.Categories = new List<Category>();
            cat1.Products = new List<Product>();



            product1.Categories.Add(cat1);
            cat1.Products.Add(product1);

            Category cat2 = new Category();
            cat2.ID = 4;
            cat2.Name = "Vehicles";

            cat2.Products = new List<Product>();
            provider1.Products = new List<Product>();

            product1.Categories.Add(cat2);
            cat2.Products.Add(product1);

            provider1.Products.Add(product1);

            //var db = ProductDb.Products;
            //foreach (Product prod in db)
            //{
            //    //База создалась только на этом моменте
            //    Console.WriteLine("{0} - {1}", prod.Name, prod.Price);
            //}
            db.Create(product1);
            Product pr = db.Get(1);
            Console.WriteLine("{0}({2}) - {1}", pr.Name, pr.Price, pr.Provider.Name);

            Console.ReadLine();
        }
        
        protected static void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new DbInitializer());
        }

        protected void Pending()
        {
            Console.WriteLine("Awaiting for your commends...");
            Console.WriteLine(@"Type 'help' or command");
            string command = Console.ReadLine();
            switch (command)
            {
                case "help":
                    
                        Console.WriteLine("");
                        break;
                    
                case "AddProduct":
                   
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("Incorrect command, try again");
                    Pending();
                    break;

            }
                    



        }
    }
}
