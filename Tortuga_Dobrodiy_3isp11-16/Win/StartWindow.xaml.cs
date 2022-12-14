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
using Tortuga_Dobrodiy_3isp11_16.Win;

namespace Tortuga_Dobrodiy_3isp11_16.Win
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            MessageBox.Show(Convert.ToString(dt));
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
            this.Close();

        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
