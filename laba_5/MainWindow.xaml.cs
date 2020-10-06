﻿using System;
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
using laba_5.Страницы;


namespace laba_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FraMain.Navigate(new Page_1());
          

        }

        private void Client_LIst(object sender, RoutedEventArgs e)
        {
            FraMain.Navigate(new Page2());

        }

        private void Navigate_back(object sender, RoutedEventArgs e)
        {
            if (FraMain.CanGoBack)
            {

                FraMain.GoBack();

            }
        }
    }
}
