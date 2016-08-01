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
using System.IO;

namespace DiaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string CurrentPath = "E:\\temp";

        public MainWindow()
        {
            InitializeComponent();
            ListFilesInDirectory(CurrentPath);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewEntry_Click(object sender, RoutedEventArgs e)
        {
            NewEntryWindow win = new NewEntryWindow();
            win.Show();
        }

        private void EditEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            string item = listBox.SelectedItem.ToString();
            MessageBox.Show(item);
        }

        private void DeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            string item = listBox.SelectedItem.ToString();
            string file = CurrentPath + "\\" + item;
            try
            {
                File.Delete(file);
                ListFilesInDirectory(CurrentPath);
            }
            catch(IOException)
            {
                MessageBox.Show("Error while deleting the file :", item);
            }
        }

        public void ListFilesInDirectory(string directory)
        {
            listBox.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(@directory);
            FileInfo[] Files = dinfo.GetFiles("*.*");
            foreach(FileInfo file in Files)
            {
                listBox.Items.Add(file.Name);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
