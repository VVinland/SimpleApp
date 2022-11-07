﻿using System;
using System.Data;
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

namespace SimpleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string line = (string)((Button)e.OriginalSource).Content;
            if (line == "AC") text.Text = "";
            else if (line == "=")
            {
                string value = new DataTable().Compute(text.Text, null).ToString();
                text.Text = value;
            }
            else text.Text += line;

        }
    }
}
