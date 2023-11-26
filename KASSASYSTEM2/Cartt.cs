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

   
   public class CustomCart
    {
        public readonly List<Cartt> cartts = new List<Cartt>(); 
        
        public  CustomCart() 
        {
            

        }

        
        public void AddProduct(Cartt cartt)
        { 
            cartts.Add(cartt);
            
        }
       

        public List<Cartt> GetCartts()
        {
            return cartts;
        }
        
    }
}
