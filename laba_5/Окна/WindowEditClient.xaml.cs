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
            CBrole.ItemsSource = context.Role.Select(i => i.NameRole).ToList();//сохранил id клиента iduser
            var user = context.User.Where(i=>i.idUser==idClient).FirstOrDefault();//для хранения выбранного клиента в listview //переда переменной
            //FirstName = TbFname.Text,
            //MidleName = Middlename.Text,
            //        Login = TBlogin.Text,
            //        Password = TBpassword.Text,
            //        idRole = context.Role.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault(),
            //        Image = File.ReadAllBytes(pathPhoto)

            TbFname.Text = user.FirstName;//переда ча запроса в TextBox
            Tblname.Text = user.LastName;//переда ча запроса в TextBox
            TBMiddlename.Text = user.MidleName;//переда ча запроса в TextBox
            TBlogin.Text = user.Login;//переда ча запроса в TextBox
            TBpassword.Text = user.Password;//переда ча запроса в TextBox
            CBrole.SelectedItem = context.Role.Where(i=>i.idRole == user.idRole ).Select(i=>i.NameRole).FirstOrDefault();////переда ча запроса в TextBox
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            
            
            if (string.IsNullOrWhiteSpace(TbFname.Text) ||
                string.IsNullOrWhiteSpace(Tblname.Text)||
                string.IsNullOrWhiteSpace(TBlogin.Text)||
                string.IsNullOrWhiteSpace(TBpassword.Text)||
                CBrole.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TBpassword.Text.Length < 6)
            {

                MessageBox.Show("Пароль короткий ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           
            else
            {
                var user = context.User.Where(i => i.idUser == idClient).FirstOrDefault();
                user.LastName = Tblname.Text;
                user.FirstName = TbFname.Text;
                user.MidleName = TBMiddlename.Text;
                user.Login = TBlogin.Text;
                user.Password = TBpassword.Text;
                user.idRole = context.Role.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault();
                user.Image = (pathPhoto.Length > 0) ? File.ReadAllBytes(pathPhoto) : null;
                context.SaveChanges();
                MessageBox.Show("данные успешно сохранены ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
          
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
        private void TBlogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBlogin.Text))
            {
                Tblname.BorderBrush = Brushes.Red;
            }
            else
            {
                Tblname.BorderBrush = Brushes.Green;
            }
        }
        private void TBlast_name_lostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tblname.Text))
            {
                Tblname.BorderBrush = Brushes.Red;
            }
            else
            {
                Tblname.BorderBrush = Brushes.Green;
            }
        }
        private void TBMIddle_name_lostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBMiddlename.Text))
            {
                Tblname.BorderBrush = Brushes.Red;
            }
            else
            {
                Tblname.BorderBrush = Brushes.Green;
            }
        }
        private void CBrole_lostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CBrole.Text))
            {
                CBrole.BorderBrush = Brushes.Red;
            }
            else
            {
                CBrole.BorderBrush = Brushes.Green;
            }
        }
        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBpassword.Text))
            {
                TBpassword.BorderBrush = Brushes.Red;
            }
            else
            {
                TBpassword.BorderBrush = Brushes.Green;
            }
        }
        private void TBF_name_lostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbFname.Text))
            {
                TbFname.BorderBrush = Brushes.Red;
            }
            else
            {
                TbFname.BorderBrush = Brushes.Green;
            }
        }
        private void TBlast_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }
        private void TBF_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }
        private void TBM_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }

        private void TBR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890-".IndexOf(e.Text) < 0;
        }
        private void TBL_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (Char.IsLetter(e.Text, 0));
        }
        private void TBP_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }
    }
}
