using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MenuItem : INotifyPropertyChanged
    {
        private string item;
        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


        public partial class MainWindow : Window
    {
        private ObservableCollection<MenuItem> billItems = new ObservableCollection<MenuItem>();
        public double subtotal = 0.0;
        public double tax1 = 0.13;
        //Beverage cmbox
        public ObservableCollection<MenuItem> liquid = new ObservableCollection<MenuItem>
        
        {
            new MenuItem {Item = "Soda",             Price = 1.95},
            new MenuItem {Item = "Tea",              Price = 1.50},
            new MenuItem {Item = "Coffee",           Price = 1.25},
            new MenuItem {Item = "Mineral Water",    Price = 2.95},
            new MenuItem {Item = "Juice",            Price = 2.50},
            new MenuItem {Item = "Milk",             Price = 1.50}
        };

        public ObservableCollection<MenuItem> appetizer = new ObservableCollection<MenuItem>

        {
            new MenuItem {Item = "Bufallo Wings",       Price = 5.95},
            new MenuItem {Item = "Bufallo Fingers",     Price = 6.95},
            new MenuItem {Item = "Potato Skins",        Price = 8.95},
            new MenuItem {Item = "Nachos",              Price = 8.95},
            new MenuItem {Item = "Mushroom Caps",       Price = 10.95},
            new MenuItem {Item = "Shirmp Cocktail",     Price = 12.95},
            new MenuItem {Item = "Chips and Salsa",     Price = 6.95}
        };

        public ObservableCollection<MenuItem> mainCourse = new ObservableCollection<MenuItem>

        {
            new MenuItem {Item = "Seafood Alfredo", Price = 15.95},
            new MenuItem {Item = "Chicken Alfredo", Price = 13.95},
            new MenuItem {Item = "Chiken Picatta",  Price = 11.95},
            new MenuItem {Item = "Turkey Club",     Price = 19.95},
            new MenuItem {Item = "Lobster Pie",     Price = 19.95},
            new MenuItem {Item = "Prime Rib",       Price = 20.95},
            new MenuItem {Item = "Shrimp Scampi",   Price = 18.95},
            new MenuItem {Item = "Turkey Dinner",   Price = 13.95},
            new MenuItem {Item = "Stuffed Chicken", Price = 14.95}
        };

        private ObservableCollection<MenuItem> dessert = new ObservableCollection<MenuItem>

        {
            new MenuItem {Item = "Sundae",      Price = 3.95},
            new MenuItem {Item = "Carrot Cake", Price = 5.95},
            new MenuItem {Item = "Mud Pie",     Price = 4.95},
            new MenuItem {Item = "Apple Crisp", Price = 5.95}
        };
        public MainWindow()
        {
            // Populate your ComboBoxes with menu items (you need to implement MenuItem class)

            // Set initial values for total fields
            InitializeComponent();
            cmbBeverage.ItemsSource = liquid;
            cmbAppetizer.ItemsSource = appetizer;
            cmbDessert.ItemsSource = dessert;
            cmbMainCourse.ItemsSource = mainCourse;
            imgLogo.MouseLeftButtonDown += ImgLogo_MouseLeftButtonDown;

            dgBill.ItemsSource = billItems;
            UpdateTotalFields();
        }
        private void ClearBill_Click(object sender, RoutedEventArgs e)
        {
            // Clear the bill and update total fields
            billItems.Clear();
            subtotal = 0.0;
            UpdateTotalFields();
        }

        private void ImgLogo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        
        {
            try
            {
                // Manejar el clic del logo aquí (por ejemplo, abrir un enlace, mostrar información, etc.)
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://www.emporioentucasa.cl")
                {
                    UseShellExecute = true
                });
            }
            catch (Exception exep)
            {
                MessageBox.Show($"Error: Fail to open the link: {exep.Message}");
            }
        }

        private void UpdateTotalFields()
        {
            // Update the Subtotal, Tax, and Total fields
            txtSubtotal.Text = subtotal.ToString("C");
            // Implement tax calculation if needed
            double tax = subtotal * tax1;
            txtTax.Text = tax.ToString("C");
            double total = subtotal + tax;
            txtTotal.Text = total.ToString("C");
        }
        // Handle the selection change event for each ComboBox
        // Add the selected item to the DataGrid and update the subtotal
        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem != null)
            {
                MenuItem selectedItem = (MenuItem)comboBox.SelectedItem;
                billItems.Add(selectedItem);
                subtotal += selectedItem.Price;
                UpdateTotalFields();
            }
        }
    }
    // Define a simple MenuItem class (you may need to extend this based on your actual data model)
 
}

