using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static laba_5.Appdata.Class1;

namespace laba_5.Окна
{
    /// <summary>
    /// Логика взаимодействия для WindowClientApp.xaml
    /// </summary>
    public partial class WindowClientApp : Window

    {
        private string pathPhoto;
        public WindowClientApp()
        {
            InitializeComponent();
            CBrole.ItemsSource = context.Roles.Select(i => i.NameRole).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(pathPhoto!=null)
            {
                context.Users.Add(new User
                {
                    LastName = Tblname.Text,
                    FirstName = TbFname.Text,
                    MidleName = Middlename.Text,
                    Login = TBlogin.Text,
                    Password = TBpassword.Text,
                    idRole = context.Roles.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault(),
                    Image = File.ReadAllBytes(pathPhoto)
                });

            }
            else
            {
                context.Users.Add(new User
                {
                    LastName = Tblname.Text,
                    FirstName = TbFname.Text,
                    MidleName = Middlename.Text,
                    Login = TBlogin.Text,
                    Password = TBpassword.Text,
                    idRole = context.Roles.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault()
                   
                });

            }
            context.SaveChanges();
            MessageBox.Show($"{Tblname.Text} {TbFname.Text} успешно добавлено !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                photoUser.Source = new BitmapImage(new Uri(fileDialog.FileName));

                pathPhoto = fileDialog.FileName;
            }
        }
    }
}
