using System;
using System.Collections.Generic;
using System.Data.Odbc;
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

namespace Pr4
{
    /// <summary>
    /// Логика взаимодействия для AddNewGoodWindow.xaml
    /// </summary>
    public partial class AddNewGoodWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private List<CATEGORY> Categories { get; set; }
        public AddNewGoodWindow()
        {
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            Categories = pr4Entities.CATEGORY.ToList<CATEGORY>();
            Categories.ForEach(c => CategoriesComboBox.Items.Add(c.NAME));
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            string newGoodName = GoodNameTextBox.Text;
            int newGoodCategory = CategoriesComboBox.SelectedIndex + 1;
            int price = Convert.ToInt32(PriceTextBox.Text);
            if (newGoodName != "" && newGoodCategory != -1 && price != 0)
            {
                if (Int32.TryParse(PriceTextBox.Text, out var goodPrice) && goodPrice > 0)
                {
                    int newGoodPrice = goodPrice;
                    GOOD newGood = new GOOD()
                    {
                        NAME = newGoodName,
                        CATEGORY = newGoodCategory,
                        PRICE = newGoodPrice
                    };
                    pr4Entities.GOOD.Add(newGood);
                    pr4Entities.SaveChanges();
                    MessageBoxResult messageBoxResult = MessageBox.Show("Товар добавлен в каталог","Товар добавлен", MessageBoxButton.OK);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        WorkerGoodsWindow workerGoodsWindow = new WorkerGoodsWindow();
                        workerGoodsWindow.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Введите целое положительное число", "Внимание");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные","Внимание");
            }
            
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerGoodsWindow workerGoodsWindow = new WorkerGoodsWindow();
            workerGoodsWindow.Show();
            this.Close();
        }
    }
}
