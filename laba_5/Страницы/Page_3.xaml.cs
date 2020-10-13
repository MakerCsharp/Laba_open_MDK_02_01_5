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
    /// Логика взаимодействия для Page_3.xaml
    /// </summary>
    public partial class Page_3 : Page
    {
        public Page_3()
        {
            InitializeComponent();
            List123.ItemsSource = context.Service.ToList();
        }
        

        private void Name_srvices(object sender, TextChangedEventArgs e)
        {
            var list = context.Service.ToList();
            List123.ItemsSource = list.Where(i => i.Services.ToUpper().Contains(TextBox_NAme_services_services.Text.ToUpper()));
        }

        private void MInprice(object sender, TextChangedEventArgs e)
        {
            //////var list = context.Service.ToList();

            //////List123.ItemsSource = list.Where(i => i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper()));

            
            //var list = context.Service.ToList();
            //List123.ItemsSource = list.Where(i=>i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper().Min(i=>i.ToString())));
            

            

        }
    }
}
