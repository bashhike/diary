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
            string EnteredUsername = UserName.Text;
            string EnteredPassword = passwordBox.Password;
            if (File.Exists("UserData.dat"))
            {
                string[] LoginDetails = File.ReadAllLines("UserData.dat");
                string StoredUsername = LoginDetails[0];
                string StoredPassword = LoginDetails[1];
                byte[] data = System.Text.Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                EnteredPassword = System.Text.Encoding.ASCII.GetString(data);
                if(EnteredPassword == StoredPassword && EnteredUsername == StoredUsername)
                {
                    MainWindow NewWindow = new MainWindow();
                    NewWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password !!");
                    UserName.Clear();
                    passwordBox.Clear();
                }
            }
            else
            {
                string[] LoginDetails = new string[2];
                LoginDetails[0] = EnteredUsername;
                byte[] data = System.Text.Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                LoginDetails[1] = System.Text.Encoding.ASCII.GetString(data);
                File.WriteAllLines("UserData.dat",LoginDetails);
                MainWindow NewWindow = new MainWindow();
                NewWindow.Show();
                Close();
            }
        }
    }
}
