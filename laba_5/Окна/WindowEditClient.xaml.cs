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
    /// Логика взаимодействия для WindowEditClient.xaml
    /// </summary>
    public partial class WindowEditClient : Window
    {
        private string pathPhoto ="";
        public WindowEditClient()
        {
            InitializeComponent();
            CBrole.ItemsSource = context.Roles.Select(i => i.NameRole).ToList();//сохранил id клиента iduser
            var user = context.Users.Where(i=>i.idUser==idClient).FirstOrDefault();//для хранения выбранного клиента в listview //переда переменной
            //FirstName = TbFname.Text,
            //MidleName = Middlename.Text,
            //        Login = TBlogin.Text,
            //        Password = TBpassword.Text,
            //        idRole = context.Role.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault(),
            //        Image = File.ReadAllBytes(pathPhoto)

            TbFname.Text = user.FirstName;//переда ча запроса в TextBox
            Tblname.Text = user.LastName;//переда ча запроса в TextBox
            Middlename.Text = user.MidleName;//переда ча запроса в TextBox
            TBlogin.Text = user.Login;//переда ча запроса в TextBox
            TBpassword.Text = user.Password;//переда ча запроса в TextBox
            CBrole.SelectedItem = context.Roles.Where(i=>i.idRole == user.idRole ).Select(i=>i.NameRole).FirstOrDefault();////переда ча запроса в TextBox
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var user = context.Users.Where(i=>i.idUser == idClient).FirstOrDefault();
            user.LastName = Tblname.Text;
            user.FirstName = TbFname.Text;
            user.MidleName = Middlename.Text;
            user.Login = TBlogin.Text;
            user.Password = TBpassword.Text;
            user.idRole = context.Roles.Where(i=>i.NameRole == CBrole.SelectedItem.ToString()).Select(i=>i.idRole).FirstOrDefault();
            user.Image = (pathPhoto.Length>0) ? File.ReadAllBytes(pathPhoto) : null;
            context.SaveChanges();
            MessageBox.Show("данные успешно сохранены ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

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
