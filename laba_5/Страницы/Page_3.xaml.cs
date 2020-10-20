using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static laba_5.Appdata.Class1;

namespace laba_5.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Page_3.xaml
    /// </summary>
    
    public partial class Page_3 : Page
    {
        private decimal a = 0;
        public Page_3()
        {
            InitializeComponent();
            List123.ItemsSource = context.Services.ToList();

        }

        public void Filter()
        {
            
            Filter();
        }

        private void Name_srvices(object sender, TextChangedEventArgs e)
        {
            var list = context.Services.ToList();
            List123.ItemsSource = list.Where(i => i.Services.Contains(TextBox_NAme_services_services.Text));
        }

        private void MInprice(object sender, TextChangedEventArgs e)
        {
            //////var list = context.Service.ToList();

            //////List123.ItemsSource = list.Where(i => i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper()));
            //var list = context.Service.ToList();
            //List123.ItemsSource = list.Where(i=>i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper().Min(i=>i.ToString())));
            var list = context.Services.ToList();
            //user.Image = (pathPhoto.Length > 0) ? File.ReadAllBytes(pathPhoto) : null;
            try
            {

                a = (Convert.ToDecimal(TextBox_MInPrice.Text));


                List123.ItemsSource = list.Where(i => i.Price >= a).ToList();


            }
            catch
            {
                a = 0;
                List123.ItemsSource = list;
            }
        }
        private void TextBox_MaxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = context.Services.ToList();
            try
            {

                a = (Convert.ToDecimal(TextBox_MaxPrice.Text));


                List123.ItemsSource = list.Where(i => i.Price <= a).ToList();


            }
            catch
            {
                a = 0;
                List123.ItemsSource = list;
            }
            //List123.ItemsSource = from i in list
            //                      where (i.Price < Convert.ToInt32(TextBox_MaxPrice.Text))
            //                      select i.ToString().ToList(); 
        }

        private void BUtton_Delete(object sender, RoutedEventArgs e)
        {
            var result_1 = MessageBox.Show("Вы действительно хотите удалить запись ?", "Удаление услуги", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result_1 == MessageBoxResult.Yes)
            {
                var result_2 = MessageBox.Show("Вы дейстивительно хотите сделать ?", "Удаление услуги", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result_2 == MessageBoxResult.Yes)
                {
                    if (List123.SelectedItem is Service service)
                    {
                        context.Services.Remove(context.Services.Where(i => i.diServices == service.diServices).FirstOrDefault());
                        context.SaveChanges();
                        MessageBox.Show("Запись успешно удалена ", "Удаление услуги", MessageBoxButton.OK, MessageBoxImage.Information);
                        List123.ItemsSource = context.Services.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Выберите услугу из списка !", "Удаление услуги", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
