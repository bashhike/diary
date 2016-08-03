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
using System.Security.Cryptography;

namespace DiaryApp
{
    /// <summary>
    /// Interaction logic for EditFile.xaml
    /// </summary>
    public partial class EditFile : Window
    {
        string filename = File.ReadAllText("AppData.dat");
        string UserName; string UserPass;
        public EditFile(string passwd = "", string user = "")
        {
            InitializeComponent();
            if (user != "") UserName = user;
            if (passwd != "") UserPass = passwd;
            LoadFile();

        }

        private void SubmitNewEntry_Click(object sender, RoutedEventArgs e)
        {
            string DiaryEntryText = EditText.Text;
            DiaryEntryText = StringCipher.Encrypt(DiaryEntryText, UserPass);
            File.WriteAllText(MainWindow.CurrentPath + "\\" + filename, DiaryEntryText);
            MainWindow NewWindow = new MainWindow(UserPass,UserName);
            NewWindow.Show();
            Close();
        }

        private void CancelNewEntry_Click(object sender, RoutedEventArgs e)
        {
            MainWindow NewWindow = new MainWindow(UserPass,UserName);
            NewWindow.Show();
            Close();
        }

        void LoadFile()
        {           
            string InitialText = File.ReadAllText(MainWindow.CurrentPath + "\\" + filename);
            try
            {
                InitialText = StringCipher.Decrypt(InitialText, UserPass);
            }
            catch (CryptographicException)
            {
                MessageBox.Show("This file uses a different password for encryption.\nYou might not see readable text.");
            }
            EditText.Text = InitialText;
        }
    }
}
