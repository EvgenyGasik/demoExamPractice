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
using demoExam.Models;

namespace demoExam.Pages
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                string login = loginField.Text.Trim();


                if (login.Length == 0) return;

                Users u = AppConnect.Reklama_Bd.Users.FirstOrDefault(x => x.login == login);
                if (u == null)

                {
                    MessageBox.Show($"Пользователь не найден");
                    return;
                }

                AppConnect.CurrentUser = u;


                if (u.roleid == 1 || u.roleid == 2)
                {

                }
                else
                {
                    AppFrame.mainFrame.Navigate(new ProductPage());
                    MessageBox.Show($"Вход успешен!!");
                   

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\nInner: {ex.InnerException?.Message}\n\nStack: {ex.StackTrace}");
            }

        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.CurrentUser = null;
            AppFrame.mainFrame.Navigate(new ProductPage());

        }
    }
}
