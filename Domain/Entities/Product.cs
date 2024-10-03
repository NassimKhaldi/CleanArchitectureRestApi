using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class Product : Entity
    {
        
        public string Name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}