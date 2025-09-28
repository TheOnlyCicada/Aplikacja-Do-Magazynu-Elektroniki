using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoMagazynu.Models
{
    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public ItemTypes Type { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Type}) - Ilość: {Quantity}, Lokalizacja: {Location}";
        }
    }
}
