using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KASSASYSTEM2
{
    public class AllProducts
    {




        public  static List<Product> LoadProducts()
        {
            string[] premadeProducts = new string[]
            {
                "Banan:10:100:kg",
                "Mjölk:20:200:styckpris",
                "General XR:45:300:styckpris",
                "Pågenlimpa:30:400:styckpris",
                "Cola nappar:15:500:styckpris",
                "Billys pizza:15:600:styckpris"

            };

            List<Product> products = new List<Product>();

            foreach(string product in premadeProducts)
            {
                string [] productLine = product.Split(':');
                string name = productLine[0];
                decimal price = decimal.Parse(productLine[1]);
                int productId = Convert.ToInt32(productLine[2]);
                string priceType = productLine[3];
                Product item = new Product(name, price, productId, priceType);
                products.Add(item);
            }

            return products;
        }



    }
}


//List <AllProducts> list = new List <AllProducts>();
//{
//    list.Add (new AllProducts(banan));
//    list.Add(new AllProducts());  
//    list.Add (new AllProducts ());
//    list.Add(new AllProducts ());
//    list.Add (new AllProducts ());
//    list.Add(new AllProducts ());
//}

//while (true)
//{
//    Console.WriteLine("Välkommen till menyn! Välj ett av alternativen.");
//    Console.WriteLine("========================");
//    Console.WriteLine("1. Ny kund");
//    Console.WriteLine("2. Avsluta");
//    Console.ReadLine();

//    string val = Console.ReadLine();

//    switch (val)
//    {
//        case 1

//                }









