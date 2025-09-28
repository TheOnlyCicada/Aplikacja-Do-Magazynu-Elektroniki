using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoMagazynu.Models
{
    public class LogEntry
    {
        public LogEntry()
        {
            Id = Guid.NewGuid();
            EventDate = DateTime.Now;
        }
        public LogEntry(LogTypes Type, Guid ItemId, Item OldItem, Item NewItem)
        {
            Id = Guid.NewGuid();
            EventDate = DateTime.Now;
            this.Type = Type;
            this.ItemId = ItemId;
            this.OldItem = OldItem;
            this.NewItem = NewItem;
        }
        public LogTypes Type { get; set; }
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public DateTime EventDate { get; set; }
        public Item OldItem { get; set; }
        public Item NewItem { get; set; }
    }
}
