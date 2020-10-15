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
using laba_5.Окна;

namespace laba_5.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            listview_form.ItemsSource = context.User.ToList();


            List<Role> roles = context.Role.ToList();
            
            roles.Insert(0, new Role() {  NameRole= "Все роли" });
            Combobox_Role.ItemsSource = roles;
            Combobox_Role.DisplayMemberPath = "NameRole";
            Combobox_Role.SelectedIndex = 0;

            
        }

        private void Textbox_Last_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filter();
            //1 часть работы 
            var list = context.User.ToList();
            listview_form.ItemsSource = list.Where(i => i.LastName.ToUpper().Contains(Textbox_Last_Name.Text.ToUpper()));


        }

        private void Textbox_First_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filter();
            //1 часть работы 
            var list = context.User.ToList();
            //Ниже код с ошибкой
             listview_form.ItemsSource = list.Where(i => i.FirstName.Contains(Textbox_First_Name.Text) );
            //Перевод в верхний регистр 

        }
        //i.MiddleName.Contains(Textbox_Last_name.Text.ToUpper()
        private void Textbox_Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Filter();

            //1 часть работы 
            var list = context.User.ToList();
            listview_form.ItemsSource = list.Where(i => i.Login.ToLower().Contains(Textbox_Login.Text));

        }//Перевод в верхний регистр 

        private void Combobox_Role_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            //Filter();
            //1 часть работы 
            var list = context.User.ToList();
            if (Combobox_Role.SelectedIndex == 0)
            {
                listview_form.ItemsSource = list;
            }
            else
            {
                var Role = Combobox_Role.SelectedItem as Role;
                list = list.Where(i => i.idRole == Role.idRole).ToList();
                listview_form.ItemsSource = list;
            }
        }
        public void Filter()
        {
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowClientApp windowClientApp = new WindowClientApp();
            windowClientApp.ShowDialog();
           
        }

        private void Button_Edit_click(object sender, RoutedEventArgs e)
        {
            if (listview_form.SelectedItem is User User)
            {
                idClient = User.idUser;
                WindowEditClient windowEditClient = new WindowEditClient();
                windowEditClient.ShowDialog();
                listview_form.ItemsSource = context.User.ToList();//обновляем listview

             }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования !","Уведомление",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
