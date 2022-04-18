using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using WpfApp5.SQL;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для AllDrivers.xaml
    /// </summary>
    public partial class AllDrivers : Window
    {
        private DispatcherTimer _timer;

        private void IdleTick(object sender, EventArgs e)
        {
            var idle = GetIdle();
            if (idle.Seconds >= 10)
            {
                MessageBox.Show("Zzzz...");
            }
        }

        TimeSpan GetIdle()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            GetLastInputInfo(ref lastInputInfo);

            var lastInput = DateTime.Now.AddMilliseconds(
                -(Environment.TickCount - lastInputInfo.dwTime));
            return DateTime.Now - lastInput;
        }

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        MainWindow main;
        public AllDrivers(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 3);
            _timer.Tick += IdleTick;
            _timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = Model1.GetContext().Водители.Where(x => x.Архив == false).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DriversMake dm = new DriversMake();
            dm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Водители current;
            if (dg.SelectedItem != null) current = (Водители)dg.SelectedItem;
            else return;

            current.Архив = true;
            Model1.GetContext().SaveChanges();
            dg.ItemsSource = Model1.GetContext().Водители.Where(x => x.Архив == false).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Archive arch = new Archive();
            arch.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            main.pinL.Visibility = Visibility.Visible;
            main.pincode.Visibility = Visibility.Visible;
            main.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
