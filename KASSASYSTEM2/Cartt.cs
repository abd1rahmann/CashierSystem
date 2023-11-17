using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSASYSTEM2
{
    public class Cartt
    {
        public required string Name { get; set; }
       
        public int Quantity { get; set; }
    }

   // Skapa en enkel klass för produkter
   public class CustomCart
    {
        public readonly List<Cartt> cartts = new List<Cartt>(); 
        // Skapa en enkel korgklass för att lagra produkter
        public  CustomCart() 
        {
            

        }

        // Metod för att hämta och lägga till produkter i korgen
        public void AddProduct(Cartt cartt)
        { 
            cartts.Add(cartt);
            
        }
        //public void RemoveProduct(Product product) 
        //{
        //    cartts.Remove(Cartt);
        //}

        // Metod för att visa innehållet i korgen

        public List<Cartt> GetCartts()
        {
            return cartts;
        }
        
    }
}
