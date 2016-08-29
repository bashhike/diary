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
            if (!File.Exists("UserData.dat"))
            {
                textBlock.FontSize = 16;
                textBlock.Text = "\t\t\tRegister";
            }
        }

        private void SubmitPass_Click(object sender, RoutedEventArgs e)
        {
            string EnteredUsername = UserName.Text;
            string EnteredPassword = passwordBox.Password;
            string passwd = EnteredPassword;
            string user = EnteredUsername;
            if (File.Exists("UserData.dat"))
            {
                string[] LoginDetails = File.ReadAllLines("UserData.dat");

                string StoredUsername = LoginDetails[0];
                string StoredPassword = LoginDetails[2];

                byte[] data = Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                EnteredPassword = Encoding.ASCII.GetString(data);

                byte[] newdata = Encoding.ASCII.GetBytes(EnteredUsername);
                newdata = new System.Security.Cryptography.SHA256Managed().ComputeHash(newdata);
                EnteredUsername = Encoding.ASCII.GetString(newdata);

                if (EnteredPassword == StoredPassword && EnteredUsername == StoredUsername)
                {
                    string newPass = user + passwd + user;
                    MainWindow NewWindow = new MainWindow(newPass, user);
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
                string[] LoginDetails = new string[3];

                byte[] newdata = Encoding.ASCII.GetBytes(EnteredUsername);
                newdata = new System.Security.Cryptography.SHA256Managed().ComputeHash(newdata);
                LoginDetails[0] = Encoding.ASCII.GetString(newdata);

                LoginDetails[1] = "Some Random Text";

                byte[] data = Encoding.ASCII.GetBytes(EnteredPassword);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                LoginDetails[2] = Encoding.ASCII.GetString(data);

                File.WriteAllLines("UserData.dat",LoginDetails);
                string newPass = user + passwd + user;
                MainWindow NewWindow = new MainWindow(newPass, user);
                NewWindow.Show();
                Close();
            }
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
