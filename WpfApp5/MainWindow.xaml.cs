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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int UCode;
        public MainWindow()
        {
            InitializeComponent();
        }
        public int time = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pass.Text == "inspector" && login.Text == "inspector")
            {
                if(pincode.Visibility == Visibility.Visible)
                {
                    if(Convert.ToInt32(pincode.Text) != UCode)
                    {
                        MessageBox.Show("Пинкод не соответствует");
                        return;
                    }
                }
                else
                {
                    Random rnd = new Random();
                    UCode = rnd.Next(1000, 9999);
                    MessageBox.Show("Ваш уникальный код: " + UCode);
                }
                
                this.Hide();
                AllDrivers ad = new AllDrivers(this);
                ad.Show();
            }
            else
            {
                MessageBox.Show("Логин или пароль неправильный");
            }
        }
        
    }
}
