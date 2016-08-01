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
using System.Windows.Shapes;
using System.IO;

namespace DiaryApp
{
    /// <summary>
    /// Interaction logic for NewEntryWindow.xaml
    /// </summary>
    public partial class NewEntryWindow : Window
    {
        public NewEntryWindow()
        {
            InitializeComponent();
        }

        private void CancelNewEntry_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SubmitNewEntry_Click(object sender, RoutedEventArgs e)
        {
            string DiaryEntryText = NewEntryText.Text ;
            string filename = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss");
            filename += ".diary";
            File.WriteAllText(filename, DiaryEntryText);
            Close();
        }
    }
}
