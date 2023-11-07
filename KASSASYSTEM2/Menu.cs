using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KASSASYSTEM2
{
    public class Menu
    {
        string filePath = "C:\\Users\\Admin\\source\\repos\\KASSASYSTEM2\\KASSASYSTEM2\\Produkter.txt";
        public void MainMenu()
        {
            int run = 1;
            while (run == 1)
            {
                Console.WriteLine("----------------------------------------------\nVälkommen till menyn! Välj ett av alternativen\n1. NyKund \n0. Avsluta\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                List<Product> allProducts = AllProducts.LoadProducts();

                switch (choice)
                {
                    case 0:
                        Avsluta();
                        run = 0;
                        break;
                    case 1:
                        NyKund();
                        break;
                    case 3:
                        ListItems();
                        break;
                    default:
                        Console.WriteLine("\nFel menu val\n.");
                        break;
                }
            }
        }

        public void ListItems()
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] columns = line.Split(':');

                if (columns.Length == 4)
                {
                    string name = columns[0];
                    int price = int.Parse(columns[1]);
                    int productId = int.Parse(columns[2]);
                    string priceType = columns[3];

                    Console.WriteLine($"Item: {name}");
                    Console.WriteLine($"Price: {price}");
                    Console.WriteLine($"Produkt: {productId}");
                    Console.WriteLine($"Price Type: {priceType}\n");

                }
            }
        }

        public void NyKund()
        {
            
            Console.WriteLine("\nNY KUND MENU VAL");
            int produktID = 0;
            int antal = 0;
            
            

            Console.WriteLine("Kommando: ");
            string kommando = Console.ReadLine();

            string[] delar = kommando.Split(' ');

            if (delar.Length == 2 && int.TryParse(delar[0], out produktID) && int.TryParse(delar[1], out antal)) 
            {
                Console.WriteLine($"ProduktID: {produktID} Antal: {antal}");
            }







        }

        public void Avsluta()
        {
            Console.WriteLine("\nAvslutar programmet.");
        }

    }
}
