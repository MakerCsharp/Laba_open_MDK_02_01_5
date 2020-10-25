using laba_5.Appdata;
using laba_5.Окна;
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
        private decimal max_a = 0;
        private decimal min_a = 0;
        private string text;
        public Page_3()
        {
            InitializeComponent();
            List123.ItemsSource = context.Services.ToList();

        }
        private void Name_srvices(object sender, TextChangedEventArgs e)
        {
            //var list = context.Services.ToList();
            //List123.ItemsSource = list.Where(i => i.Services.Contains(TextBox_NAme_services_services.Text));
            Filter_2();
        }

        private void MInprice(object sender, TextChangedEventArgs e)
        {
            //////var list = context.Service.ToList();

            //////List123.ItemsSource = list.Where(i => i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper()));
            //var list = context.Service.ToList();
            //List123.ItemsSource = list.Where(i=>i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper().Min(i=>i.ToString())));
            //var list = context.Services.ToList();
            //user.Image = (pathPhoto.Length > 0) ? File.ReadAllBytes(pathPhoto) : null;
            //try
            //{

            //    a = (Convert.ToDecimal(TextBox_MInPrice.Text));

            Filter_2();
            //    List123.ItemsSource = list.Where(i => i.Price >= a).ToList();


            //}
            //catch
            //{
            //    a = 0;
            //    List123.ItemsSource = list;
            //}
        }
        private void TextBox_MaxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter_2();
            //var list = context.Services.ToList();
            //try
            //{

            //    a = (Convert.ToDecimal(TextBox_MaxPrice.Text));


            //    List123.ItemsSource = list.Where(i => i.Price <= a).ToList();


            //}
            //catch
            //{
            //    a = 0;
            //    List123.ItemsSource = list;
            //}
            //List123.ItemsSource = from i in list
            //                      where (i.Price < Convert.ToInt32(TextBox_MaxPrice.Text))
            //                      select i.ToString().ToList(); 

            //var list = context.User.Where(i => i.LastName.Contains(Textbox_Last_name.Text))
            //                       .Where(i => i.MidleName.Contains(Textbox_First_Name.Text) || i.FirstName.Contains(Textbox_First_Name.Text))
            //                       .Where(i => i.Login.Contains(Textbox_Login.Text)).ToList();
            //listview_form.ItemsSource = list;
            //if (Combobox_Role.SelectedIndex == 0)
            //{
            //    listview_form.ItemsSource = list;
            //}
            //else
            //{
            //    var Role = Combobox_Role.SelectedItem as Role;
            //    list = list.Where(i => i.idRole == Role.idRole).ToList();
            //    listview_form.ItemsSource = list;
            //}
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

        public void Filter_2()
        {
            var list = context.Services.ToList();
            try
            {
                max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
                min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
                text = (Convert.ToString(TextBox_NAme_services_services.Text));
                List123.ItemsSource = list.Where(i => i.NServices.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            }
            catch
            {
                max_a = 0;
                min_a = 0;
                text = " ";
                List123.ItemsSource = list;
            }
            //////1
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            //////2
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            //////3
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            //////4
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            /////5
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            /////6
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            //////7
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}
            /////8
            //try
            //{
            //    max_a = (Convert.ToDecimal(TextBox_MaxPrice.Text));
            //    min_a = (Convert.ToDecimal(TextBox_MInPrice.Text));
            //    text = (Convert.ToString(TextBox_NAme_services_services.Text));
            //    List123.ItemsSource = context.Services.Where(i => i.Services.Contains(text)).Where(i => i.Price <= max_a).Where(i => i.Price >= min_a).ToList();
            //}
            //catch
            //{
            //    max_a = 0;
            //    min_a = 0;
            //    text = " ";
            //    List123.ItemsSource = list;

            //}




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAddService windowAdd = new WindowAddService();
            windowAdd.ShowDialog();
            List123.ItemsSource = context.Services.ToList();
        }

        private void Edit_clikc(object sender, RoutedEventArgs e)
        {
            if (List123.SelectedItem is Service service)
            {
                idServices = service.diServices;
                WindowEditService windowEdit = new WindowEditService();
                windowEdit.ShowDialog();
                List123.ItemsSource = context.Services.ToList();

            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
    }
}
