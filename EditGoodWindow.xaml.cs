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
using System.Windows.Shapes;

namespace Pr4
{
    /// <summary>
    /// Логика взаимодействия для EditGoodWindow.xaml
    /// </summary>
    public partial class EditGoodWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private GOOD _currentGood;
        public EditGoodWindow(GOOD currentGood)
        {
            _currentGood = currentGood;
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            GoodNameTextBox.Text = currentGood.NAME;
            List<CATEGORY> Categories = pr4Entities.CATEGORY.ToList();
            Categories.ForEach(c => CategoriesComboBox.Items.Add(c.NAME));
            CategoriesComboBox.SelectedIndex = currentGood.CATEGORY - 1;
            PriceTextBox.Text = currentGood.PRICE.ToString();
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            var good = pr4Entities.GOOD.Where(g => g.NAME.Equals(_currentGood.NAME)).FirstOrDefault();
            good.NAME = GoodNameTextBox.Text;
            good.CATEGORY = CategoriesComboBox.SelectedIndex + 1;
            if (Int32.TryParse(PriceTextBox.Text, out var price))
            {
                good.PRICE = price;
            }
            pr4Entities.SaveChanges();
            MessageBoxResult messageBoxResult = MessageBox.Show("Данные обновлены","Внимание", MessageBoxButton.OK);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                WorkerGoodsWindow workerGoodsWindow = new WorkerGoodsWindow();
                workerGoodsWindow.Show();
                this.Close();
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
