using AplikacjaDoMagazynu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplikacjaDoMagazynu
{
    class ItemsValidator
    {
        public static bool Validate(string name, string quantity, string location)
        {
            var valid = true;
            if (ValidateNewItemName(name))
            {
                MessageBox.Show("Nazwa musi być wypełniona");
                valid = false;
            }
            if (ValidateNewItemAmountIsNotEmpty(quantity))
            {
                MessageBox.Show("Ilość musi być wypełniona");
                valid = false;
            }
            else if (ValidateNewItemAmount(quantity))
            {
                MessageBox.Show("Ilość musi być liczbą");
                valid = false;
            }
            else if (ValidateNewItemLocation(location))
            {
                MessageBox.Show("Lokalizacja musi być wypełniona");
                valid = false;
            }

            return valid;
        }

        private static bool ValidateNewItemAmount(string amount)
        {
            return !int.TryParse(amount, out int Amount);
        }

        private static bool ValidateNewItemAmountIsNotEmpty(string amount)
        {
            return amount.Length == 0;
        }

        private static bool ValidateNewItemName(string name)
        {
            return name == "";
        }

        private static bool ValidateNewItemLocation(string location)
        {
            return location == "";
        }
    }
}
