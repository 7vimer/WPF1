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
using WpfApp5.SQL;
using System.IO;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Archive.xaml
    /// </summary>
    public partial class Archive : Window
    {
        public Archive()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = Model1.GetContext().Водители.Where(x => x.Архив == true).ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Водители current;
            if (dg.SelectedItem != null) current = (Водители)dg.SelectedItem;
            else return;
            string vigr = "";
            vigr = vigr + current.ИдентификаторGUID + ";";
            vigr = vigr + current.Фамилия+ ";";
            vigr = vigr + current.Имя+ ";";
            vigr = vigr + current.Отчество+ ";";
            vigr = vigr + current.Паспорт+ ";";
            vigr = vigr + current.АдресРегистрации+ ";";
            vigr = vigr + current.АдресПроживания + ";";
            vigr = vigr + current.МестоРаботы+ ";";
            vigr = vigr + current.Должность+ ";";
            vigr = vigr + current.МобильныйТелефон+ ";";
            vigr = vigr + current.Email+ ";";
            vigr = vigr + current.Фотография+ ";";
            vigr = vigr + current.Замечания;
            FileStream fs = File.Create(Environment.CurrentDirectory + "/Водитель" + current.ИдентификаторGUID + ".csv");
            fs.Close();
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "/Водитель" + current.ИдентификаторGUID + ".csv");
            sw.Write(vigr);
            sw.Close();



        }
    }
}
