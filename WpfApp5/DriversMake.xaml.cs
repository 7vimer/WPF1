using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp5.SQL;
using System.IO;
using Image = System.Drawing.Image;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для DriversMake.xaml
    /// </summary>
    public partial class DriversMake : Window
    {
        AllDrivers alldr;
        public DriversMake()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Guid.Text == null || famil.Text == null || imya.Text == null || otch.Text == null || passport.Text == null || addresprozhGorod.Text == null || addresprozhGorodAll.Text == null || adressregAll.Text == null
                || adressregGorod.Text == null || photo.Text == null || email.Text == null || phone.Text.Substring(0,3) != "+7(" || phone.Text.Substring(6,1) != ")")
            {
                MessageBox.Show("Заполните все поля правильно");
                return;
            }

            Водители vod = new Водители();
            vod.Фамилия = famil.Text;
            vod.Имя = imya.Text;
            vod.Отчество = otch.Text;
            vod.Паспорт = passport.Text;
            vod.АдресПроживания = addresprozhGorod.Text + ", " + addresprozhGorodAll.Text;
            vod.АдресРегистрации = adressregGorod.Text + ", " + adressregAll.Text;
            vod.МестоРаботы = workplace.Text;
            vod.Должность = dolzhn.Text;
            vod.МобильныйТелефон = phone.Text;
            vod.Email = email.Text;
            vod.Замечания = descript.Text;
            vod.Фотография = photo.Text;
            vod.Архив = false;
            Model1.GetContext().Водители.Add(vod);
            Model1.GetContext().SaveChanges();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Картинки (*.jpeg,*.jpg)|*.jpg;*.jpeg";
            if (ofd.ShowDialog() == true)
            {
                if(new FileInfo(ofd.FileName).Length > 2097152)
                {
                    MessageBox.Show("Размер файла не может привышать 2МБ");
                    return;
                }
                Image i = Image.FromFile(ofd.FileName);
                if(i.Width != i.Height / 4 * 3)
                {
                    MessageBox.Show("Изображение должно быть формата 4:3");
                    //return;
                }
                photo.Text = ofd.FileName;
            }
        }
    }
}
