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
    /// Логика взаимодействия для WorkerAuthorizationWindow.xaml
    /// </summary>
    public partial class WorkerAuthorizationWindow : Window
    {
        private List<WORKER> Workers { get; set; }
        private Pr4Entities pr4Entities;
        public WorkerAuthorizationWindow()
        {
            pr4Entities = new Pr4Entities();
            InitializeComponent();
            Workers = pr4Entities.WORKER.ToList<WORKER>();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            if (login != "" && password != "")
            {
                if (Workers.Exists(w => w.LOGIN.Equals(login)))
                {
                    WORKER currentWorker = Workers.FirstOrDefault(w => w.LOGIN.Equals(login));
                    if (currentWorker.PASSWORD.Equals(password))
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Вы успешно авторизовались", "Внимание", MessageBoxButton.OK);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {
                            WorkerGoodsWindow workerGoodsWindow = new WorkerGoodsWindow();
                            workerGoodsWindow.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверный пароль","Внимание");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите все данные", "Внимание");
            }
        }
    }
}
