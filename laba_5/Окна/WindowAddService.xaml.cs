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
    /// Логика взаимодействия для WindowAddService.xaml
    /// </summary>
    public partial class WindowAddService : Window
    {
        private string pathPhoto;
        public WindowAddService()
        {
            InitializeComponent();
        }
        private void Button_Click_add_new_service(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbService.Text)||
                string.IsNullOrWhiteSpace(TbPrice.Text))
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (pathPhoto != null)
            {
                context.Services.Add(new Service
                {
                    NServices = TbService.Text,
                    Price = Convert.ToDecimal(TbPrice.Text),
                    image = File.ReadAllBytes(pathPhoto)
                });
                context.SaveChanges();
                MessageBox.Show($"{TbService.Text} {TbPrice.Text} успешно добавленно !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                context.Services.Add(new Service
                {
                    NServices = TbService.Text,
                    Price = Convert.ToDecimal(TbPrice.Text),
                });
                context.SaveChanges();
                MessageBox.Show($"{TbService.Text} {TbPrice.Text} успешно добавленно !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }   
        }
        private void Button_image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                photoService.Source = new BitmapImage(new Uri(fileDialog.FileName));
                pathPhoto = fileDialog.FileName;

            }
        }

        

        private void Button_Click_cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TB_Name_Service_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbService.Text))
            {


                TbService.BorderBrush = Brushes.Red;

            }
            else
            {

                TbService.BorderBrush = Brushes.Green;

            }
        }

        private void TB_Price_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbPrice.Text))
            {


                TbPrice.BorderBrush = Brushes.Red;

            }
            else
            {

                TbPrice.BorderBrush = Brushes.Green;

            }
        }

        private void Tb_Price_Preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890-".IndexOf(e.Text, 0)<0;
        }

        private void Tb_Name_service_Preview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }
    }
}
