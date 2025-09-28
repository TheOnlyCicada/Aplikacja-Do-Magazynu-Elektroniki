using AplikacjaDoMagazynu.Models;
using AplikacjaDoMagazynu.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplikacjaDoMagazynu
{
    /// <summary>
    /// Logika interakcji dla klasy EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        public Item Item { get; }
        public ItemsCollection ItemsCollection { get; }
        public StorageManager StorageManager { get; set; }
        public DataGrid ItemsGrid { get; }
        public List<LogEntry> Logs { get; }

        public EditWindow(Item item, ItemsCollection itemsCollection, StorageManager storageManager, DataGrid ItemsGrid, List<LogEntry> Logs)
        {
            InitializeComponent();
            Item = item;
            ItemsCollection = itemsCollection;
            StorageManager = storageManager;
            this.ItemsGrid = ItemsGrid;
            this.Logs = Logs;
            Edit_NameTextBox.Text = item.Name;
            Edit_AmountTextBox.Text = item.Quantity.ToString();
            Edit_NotesTextBox.Text = item.Notes;
            Edit_LocationTextBox.Text = item.Location;

            var ComboBoxItems = Enum.GetValues(typeof(ItemTypes))
                .Cast<ItemTypes>()
                .Select((e) => new ItemType { DisplayName = ItemTypesHelper.ToLable(e), Value = e }).ToList();
            Edit_TypeComboBox.ItemsSource = ComboBoxItems;
            Edit_TypeComboBox.DisplayMemberPath = "DisplayName";
            Edit_TypeComboBox.SelectedValue = ComboBoxItems.FirstOrDefault(x => x.Value == Item.Type);
        }

        private void Edit_SaveItem(object sender, RoutedEventArgs e)
        {
            if (!ItemsValidator.Validate(Edit_NameTextBox.Text, Edit_AmountTextBox.Text, Edit_LocationTextBox.Text))
            {
                return;
            };

            var oldItem = new Item()
            {
                Type = Item.Type,
                Name = Item.Name,
                Quantity = Item.Quantity,
                Notes = Item.Notes,
                Location = Item.Location,
                Id = Item.Id,
            } ;

            Item.Type = ((ItemType)(Edit_TypeComboBox.SelectedItem)).Value;
            Item.Name = Edit_NameTextBox.Text;
            Item.Location = Edit_LocationTextBox.Text;
            Item.Notes = Edit_NotesTextBox.Text;
            Item.Quantity = int.Parse(Edit_AmountTextBox.Text);

            StorageManager.SaveItems(ItemsCollection.Items);
            RefreshGrid();

            Logs.Add(new LogEntry(LogTypes.Edit, Item.Id, oldItem , Item));
            StorageManager.SaveLogs(Logs);

            this.Close();
        }
        private void RefreshGrid()
        {
            ItemsGrid.ItemsSource = null;
            ItemsGrid.ItemsSource = ItemsCollection.Items;
        }
    }
}
