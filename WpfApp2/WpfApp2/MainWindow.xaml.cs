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
using WpfApp1.BusniessLogic;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LogicLayer ll = new LogicLayer();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string uname = username.Text;
            string pwd = password.Password;
            if (uname.Equals("") || pwd.Equals(""))
            {
                MessageBox.Show("Must Fill all the fields.");
            }
            else
            {
                int res =ll.login(uname, pwd);
                if (res == 0)
                { MessageBox.Show("Not correct Credentials, " + uname); }
                else if (res == 1)
                { MessageBox.Show("Verified, " + uname); }
                else if (res == -1)
                { MessageBox.Show("Some PROblem, " + uname); }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (password.IsVisible)
            {
                password.Visibility = Visibility.Hidden;
            }
            else
            {
                password.Visibility = Visibility.Visible;
            }
        }
    }
}
