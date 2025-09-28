using AplikacjaDoMagazynu.Models;
using AplikacjaDoMagazynu.Services;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikacjaDoMagazynu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ItemsCollection Items { get; private set; } = new ItemsCollection();
        public List<LogEntry> Logs { get; private set; } = new List<LogEntry>();
        public StorageManager StorageManager { get; private set; } = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Items.Items = StorageManager.LoadItems();
            Logs = StorageManager.LoadLogs();

            TypeComboBox.ItemsSource = Enum.GetValues(typeof(ItemTypes))
                .Cast<ItemTypes>()
                .Select((e) => new ItemType{ DisplayName = ItemTypesHelper.ToLable(e), Value = e }).ToList();
            TypeComboBox.DisplayMemberPath = "DisplayName"; 
            TypeComboBox.SelectedIndex = 0;
            AmountTextBox.Text = "0";

            ItemsDataGrid.ItemsSource = Items.Items;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ItemsValidator.Validate(NameTextBox.Text, AmountTextBox.Text, LocationTextBox.Text))
            {
                return;
            };

            DebugTextBlock.Text = NameTextBox.Text 
                + " " + AmountTextBox.Text
                + " " + TypeComboBox.Text 
                + " " + LocationTextBox.Text 
                + " " + NotesTextBox.Text;

            var newItem = new Item()
            {
                Type = ((ItemType)(TypeComboBox.SelectedItem)).Value,
                Name = NameTextBox.Text,
                Location = LocationTextBox.Text,
                Notes = NotesTextBox.Text,
                Quantity = int.Parse(AmountTextBox.Text),
            };
            Items.Add(newItem);
            StorageManager.SaveItems(Items.Items);
            RefreshGrid();

            Logs.Add(new LogEntry(LogTypes.Add, newItem.Id, null , newItem));
            StorageManager.SaveLogs(Logs);
        }

        private void DeleteEntry(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.DataContext != null)
            {
                var item = (Item)button.DataContext;
                Items.Remove(item.Id);
                StorageManager.SaveItems(Items.Items);
                RefreshGrid();

                Logs.Add(new LogEntry(LogTypes.Delete, item.Id, item, null));
                StorageManager.SaveLogs(Logs);
            }
        }
        private void EditEntry(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.DataContext != null)
            {
                var item = (Item)button.DataContext;
                EditWindow subWindow = new EditWindow(item, Items, StorageManager, ItemsDataGrid, Logs);
                subWindow.Show();
            }
        }
        private void RefreshGrid()
        {
            ItemsDataGrid.ItemsSource = null;
            ItemsDataGrid.ItemsSource = Items.Items;
        }
    }
}