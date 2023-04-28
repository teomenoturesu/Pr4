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

namespace Pr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private List<CUSTOMER> Customers { get; set; }
        public MainWindow()
        {
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            Customers = pr4Entities.CUSTOMER.ToList<CUSTOMER>();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            WorkerAuthorizationWindow workerAuthorizationWindow = new WorkerAuthorizationWindow();
            workerAuthorizationWindow.Show();
            this.Close();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            if(login != "" && password != "")
            {
                if(Customers.Exists(c => c.LOGIN.Equals(login)))
                {
                    CUSTOMER currentCustomer = Customers.FirstOrDefault(c => c.LOGIN.Equals(login));
                    if(currentCustomer.PASSWORD.Equals(password))
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Вы успешно авторизовались", "Внимание", MessageBoxButton.OK); 
                        if(messageBoxResult == MessageBoxResult.OK)
                        {
                            CustomerNavigationWindow customerNavigationWindow = new CustomerNavigationWindow(currentCustomer);
                            customerNavigationWindow.Show();
                            this.Close();
                        }
                    }  
                    else
                    {
                        MessageBox.Show("Вы ввели неверный пароль","Внимание");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином не существует","Внимание");
                }
            }
            else
            {
                MessageBox.Show("Введите все данные","Внимание");
            }
        }
    }
}
