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
    /// Логика взаимодействия для WindowEditService.xaml
    /// </summary>
    public partial class WindowEditService : Window
    {
        private string pathPhoto = "";
        public WindowEditService()
        {
            InitializeComponent();
            var service = context.Service.Where(i => i.idServices == idServices).FirstOrDefault();
            TbName_Service.Text = service.NServices;
            TbPrice.Text = Convert.ToString(service.Price);
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName_Service.Text)||
                string.IsNullOrWhiteSpace(TbPrice.Text))
              
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                var service = context.Service.Where(i => i.idServices == idServices).FirstOrDefault();
                service.NServices = TbName_Service.Text;
                service.Price = Convert.ToDecimal(TbPrice.Text);
                service.image = (pathPhoto.Length > 0) ? File.ReadAllBytes(pathPhoto) : null;
                context.SaveChanges();
                MessageBox.Show("данные успешно сохранены ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

      

        private void Button_Click_cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_image_edit_service(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                photoService.Source = new BitmapImage(new Uri(fileDialog.FileName));
                pathPhoto = fileDialog.FileName;

            }
        }

        private void TBPRice_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890-".IndexOf(e.Text) < 0;

        }

       

        private void TBPrice_name_LostFocus(object sender, RoutedEventArgs e)
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

        private void TBService_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!Char.IsLetter(e.Text, 0));
        }

        private void TBService_name_lostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName_Service.Text))
            {
                TbName_Service.BorderBrush = Brushes.Red;
            }
            else
            {
                TbName_Service.BorderBrush = Brushes.Green;
            }
        }
    }
}
