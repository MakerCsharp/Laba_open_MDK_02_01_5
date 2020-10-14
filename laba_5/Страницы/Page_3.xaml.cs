using System;
using System.Collections.Generic;
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
        public Page_3()
        {
            InitializeComponent();
            //List123.ItemsSource = context.Service.ToList();
        }
        

        private void Name_srvices(object sender, TextChangedEventArgs e)
        {
            //var list = context.Service.ToList();
            //List123.ItemsSource = list.Where(i => i.Services.ToUpper().Contains(TextBox_NAme_services_services.Text.ToUpper()));
        }

        private void MInprice(object sender, TextChangedEventArgs e)
        {
            //////var list = context.Service.ToList();

            //////List123.ItemsSource = list.Where(i => i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper()));

            
            //var list = context.Service.ToList();
            //List123.ItemsSource = list.Where(i=>i.Price.ToString().Contains(TextBox_MInPrice.Text.ToUpper().Min(i=>i.ToString())));
            

            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //TextBox_MaxPrice
            // TextBox_MInPrice
            //TextBox_NAme_services_services



            //    decimal num_1 = 10;
            //string name = "Рудд";
            //decimal num_2 = 20;

            //    System.Data.SqlClient.SqlParameter param_1 = new System.Data.SqlClient.SqlParameter("@price_max", num_1);
            //    System.Data.SqlClient.SqlParameter param_2 = new System.Data.SqlClient.SqlParameter("@price_min", num_2);
            //      System.Data.SqlClient.SqlParameter param_3 = new System.Data.SqlClient.SqlParameter("Name", name);
            //var list = context.Service.ToList();
            //var phones = db.Database.SqlQuery<>("GetPhonesByCompany @name", param);

            //SqlCommand cmd = new SqlCommand("vvod_max_min");
            //cmd.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //List123.DataContext = dt;




        }
    }
}
