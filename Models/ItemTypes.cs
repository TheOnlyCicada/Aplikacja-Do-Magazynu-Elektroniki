using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoMagazynu.Models
{
    public enum ItemTypes
    {
        Transistor, Resistor, Diod, Other
    }
    public static class ItemTypesHelper
    {
        public static string ToLable(ItemTypes type)
        {
            switch (type)
            {
                case ItemTypes.Transistor:
                    return "tranzystor";
                case ItemTypes.Resistor:
                    return "rezystor";
                case ItemTypes.Diod:
                    return "dioda";
                case ItemTypes.Other:
                    return "inny";
                default: return "-";

            }
        }
    }
    public class ItemType
    {
        public string DisplayName { get; set; }
        public ItemTypes Value { get; set; }
    }
}