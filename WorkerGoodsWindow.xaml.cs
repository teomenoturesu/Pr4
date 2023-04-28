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
    /// Логика взаимодействия для WorkerGoodsWindow.xaml
    /// </summary>
    public partial class WorkerGoodsWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private List<GOOD> Goods { get; set; }
        private List<CATEGORY> Categories { get; set; }
        private List<ListOfGoods> ListOfGoods { get; set; }
        public WorkerGoodsWindow()
        {
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            Goods = pr4Entities.GOOD.ToList<GOOD>();
            Categories = pr4Entities.CATEGORY.ToList<CATEGORY>();
            GoodsSelection();
            GoodsDataGrid.ItemsSource = ListOfGoods;
        }

        private void EditGoodButton_Click(object sender, RoutedEventArgs e)
        {
            var good = GoodsDataGrid.SelectedIndex;
            ListOfGoods row = (ListOfGoods)GoodsDataGrid.Items.GetItemAt(good);
            GOOD currentGood = Goods.Find(g => g.NAME.Equals(row.GoodName));
            EditGoodWindow editGoodWindow = new EditGoodWindow(currentGood);
            editGoodWindow.Show();
            this.Close();
        }

        private void DeleteGoodButton_Click(object sender, RoutedEventArgs e)
        {
            var good = GoodsDataGrid.SelectedIndex;
            ListOfGoods row = (ListOfGoods)GoodsDataGrid.Items.GetItemAt(good);
            GOOD currentGood = Goods.Find(g => g.NAME.Equals(row.GoodName));
            pr4Entities.GOOD.Remove(currentGood);
            pr4Entities.SaveChanges();
            Goods = pr4Entities.GOOD.ToList();
            GoodsSelection();
            GoodsDataGrid.ItemsSource = ListOfGoods;
            MessageBox.Show("Удаление прошло успешно","Внимание");
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewGoodWindow addNewGoodWindow = new AddNewGoodWindow();
            addNewGoodWindow.Show();
            this.Close();
        }
        private void GoodsSelection()
        {
            ListOfGoods = (from good in Goods
                           join category in Categories on good.CATEGORY equals category.ID
                           select new ListOfGoods
                           {
                               GoodName = good.NAME,
                               CategoryName = category.NAME,
                               Price = good.PRICE
                           }).ToList();
        }

        private void NavigationHyperlink_Click(object sender, RoutedEventArgs e)
        {
            WorkerNavigationWindow workerNavigationWindow = new WorkerNavigationWindow();
            workerNavigationWindow.Show();
            this.Close();
        }
    }
}
