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
using System.Windows.Shapes;
using System.IO;

namespace DiaryApp
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void SubmitPass_Click(object sender, RoutedEventArgs e)
        {
            string EnteredPassword = passwordBox.Password;
            if (File.Exists("UserData.dat"))
            {
                string StoredPassword = File.ReadAllText("UserData.dat");
                byte[] data = System.Text.Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                EnteredPassword = System.Text.Encoding.ASCII.GetString(data);
                if(EnteredPassword == StoredPassword)
                {
                    MainWindow NewWindow = new MainWindow();
                    NewWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password !!");
                    passwordBox.Clear();
                }
            }
            else
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                EnteredPassword = System.Text.Encoding.ASCII.GetString(data);
                File.WriteAllText("UserData.dat",EnteredPassword);
                MainWindow NewWindow = new MainWindow();
                NewWindow.Show();
                Close();
            }
        }
    }
}
