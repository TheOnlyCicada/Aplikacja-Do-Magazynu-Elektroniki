using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoMagazynu.Models
{
    public class ItemsCollection
    {

        public List<Item> Items = new List<Item>();

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

        public void Remove(Guid id)
        {
            var itemToRemove = Items.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public Item? Get(Guid id)
        {
            return Items.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Item> FindByName(string name)
        {
            return Items.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
