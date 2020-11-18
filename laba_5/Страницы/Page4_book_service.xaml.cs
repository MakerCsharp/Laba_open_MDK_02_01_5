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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static laba_5.Appdata.Class1;

namespace laba_5.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Page4_book_service.xaml
    /// </summary>
    public partial class Page4_book_service : Page
    {
        public Page4_book_service()
        {
            InitializeComponent();
            listview_Page4_spisop_service.ItemsSource = context.Service.ToList();
            Listview_Forma4.ItemsSource = context.User.ToList();//Listview_Forma4
        }

        private void Login_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = context.User.ToList();
            Listview_Forma4.ItemsSource = list.Where(i => i.Login.Contains(Login_textbox.Text));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = context.Service.ToList();
            listview_Page4_spisop_service.ItemsSource = list.Where(i => i.NServices.Contains(Name_Service.Text));
        }
    }
}
