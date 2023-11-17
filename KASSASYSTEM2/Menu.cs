using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KASSASYSTEM2
{
    public class Menu
    {
        string filePath = "C:\\Users\\Admin\\source\\repos\\KASSASYSTEM2\\KASSASYSTEM2\\Produkter.txt";
        private readonly List<Product> products = new List<Product>();
        public void MainMenu()
        {
            LoadProducts();
            int run = 1;
            
            while (run == 1)
            {
                Console.WriteLine("Välkommen till menyn!\n--------------------------------\nVälj ett av alternativen\n1. NyKund \n0. Avsluta\n");
                string choice = Console.ReadLine();



                switch (choice)
                {
                    case "0":
                        EndProgram();
                        run = 0;
                        break;
                    case "1":
                        NewCustom();
                        break;
                    case "3":
                        LoadProducts();
                        break;
                    default:
                        Console.WriteLine("\nFel informat! Vänligen välj ett av alternativen\n.");
                        break;
                }
            }
        }

        public void LoadProducts()
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] columns = line.Split(':');

                if (columns.Length == 4)
                {
                    string name = columns[0];
                    decimal price = int.Parse(columns[1]);
                    int productId = int.Parse(columns[2]);
                    string priceType = columns[3];

                    var product = new Product
                    {
                        Name = name,
                        Price = price,
                        ProductID = productId,
                        PriceType = priceType,
                    };

                    products.Add(product);

                }
            }
        }

        public void NewCustom()
        {


            int produktID = 0;
            int antal = 0;
            int run = 1;
            CustomCart cart = new CustomCart();
            while (run == 1)
            {

                Console.WriteLine("Kommando: ");
                string kommando = Console.ReadLine();

               

                if (kommando.ToLower() == "pay")
                {
                    var cartts = cart.GetCartts();
                     
                    WriteReceipt(cartts);
                    run = 0;    
                }

                else
                {

                    string[] delar = kommando.Split(' ');
                    if (delar.Length == 2 && int.TryParse(delar[0], out produktID) && int.TryParse(delar[1], out antal))
                    {

                        //I listan products som innehåller alla produkter från textfilen vill vi fiska upp det första produkten med produktid som stämmer in med kommandot
                        var product = products.FirstOrDefault(x => x.ProductID == produktID);

                        if (product != null) // Om produkten finns
                        {
                            var cartt = new Cartt
                            {
                                Name = product.Name,
                                Quantity = antal
                            };

                            cart.AddProduct(cartt);

                        }

                        else
                        {
                            Console.WriteLine("Produkten finns INTE!");
                        }

                    }

                    else
                    {
                        Console.WriteLine("Fel informat! Följ instruktionerna som ges.");
                    }

                }
                


            }

        }

        public void EndProgram()
        {
            Console.WriteLine("\nAvslutar programmet.");
            Environment.Exit(0);
        }

        public void WriteReceipt(List<Cartt> cartts)
        {
            var date = DateTime.Now;

            string dateString = date.ToString("yyyy-MM-dd-");
            string timeString = date.ToString("HHmmss");

            // Concatenate the date and time strings
            string resultString = dateString + timeString;

            // Remove ":" from the time part
            resultString = resultString.Replace(":", "");

            var fileName = "kvitto" + resultString + ".txt";
            string path = @"C:\Users\Admin\source\repos\KASSASYSTEM2\KASSASYSTEM2\" + fileName;

            string kvitto = "KVITTO " + date.ToString("yyyy-MM-dd hh:mm:ss") + "\n";
            decimal total = 0;
            foreach (var cartt in cartts) 
            {
                
                var product = products.FirstOrDefault (x => x.Name == cartt.Name);
                if(product!=null)
                {
                    var sum = cartt.Quantity * product.Price;
                    kvitto += $"{cartt.Name} {cartt.Quantity} * {product.Price} = {sum} \n";
                    total += sum;
                }
            }
            kvitto+= $"Total: {total}";
            File.WriteAllText(path, kvitto);
            Console.WriteLine(kvitto);
            
        }
         
        
    }

}























