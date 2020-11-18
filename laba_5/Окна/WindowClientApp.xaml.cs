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
            CBrole.ItemsSource = context.Role.Select(i => i.NameRole).ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbFname.Text)||
                string.IsNullOrWhiteSpace(Tblname.Text)||
                string.IsNullOrWhiteSpace(TBlogin.Text)||
                string.IsNullOrWhiteSpace(TBpassword.Text)||
                CBrole.SelectedItem== null)
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
           if (TBpassword.Text.Length < 6)
            {

                MessageBox.Show("Пароль короткий ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
              if(pathPhoto!=null)
            {
                context.User.Add(new User
                {
                    LastName = Tblname.Text,
                    FirstName = TbFname.Text,
                    MidleName = Middlename.Text,
                    Login = TBlogin.Text,
                    Password = TBpassword.Text,
                    idRole = context.Role.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault(),
                    Image = File.ReadAllBytes(pathPhoto)
                });
                context.SaveChanges();
                MessageBox.Show($"{Tblname.Text} {TbFname.Text} успешно добавлено !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            else 
            {
                context.User.Add(new User
                {
                    LastName = Tblname.Text,
                    FirstName = TbFname.Text,
                    MidleName = Middlename.Text,
                    Login = TBlogin.Text,
                    Password = TBpassword.Text,
                    idRole = context.Role.Where(i => i.NameRole == CBrole.SelectedItem.ToString()).Select(i => i.idRole).FirstOrDefault()
                   
                }); 
                context.SaveChanges();
                MessageBox.Show($"{Tblname.Text} {TbFname.Text} успешно добавлено !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void TB_last_name_lostfocus(object sender, RoutedEventArgs e)
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

        private void TB_First_name_lostfocus(object sender, RoutedEventArgs e)
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

   

        private void CB_Role_name_lostfocus(object sender, RoutedEventArgs e)
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

        private void TB_Login_lostfocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBlogin.Text))
            {
                TBlogin.BorderBrush = Brushes.Red;

            }
            else
            {
                TBlogin.BorderBrush = Brushes.Green;
            }
        }

        private void TB_Password_lostfocus(object sender, RoutedEventArgs e)
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

        private void Tb_last_name_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }

        private void Tb_First_name_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }

        private void Tb_Middle_name_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }

        private void Tb_Role_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text,0));
        }

        private void Tb_Login_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text,0));
        }

        private void Tb_PAssword_Preview_Text_input(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text,0));
        }

        private void TB_Middle_name_lostfocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Middlename.Text))
            {
                Middlename.BorderBrush = Brushes.Red;


            }
            else
            {

                Middlename.BorderBrush = Brushes.Green;
            }
        }
    }
}
