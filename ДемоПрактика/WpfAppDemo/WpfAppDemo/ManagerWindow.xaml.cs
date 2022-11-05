using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfAppDemo.Classess;

namespace WpfAppDemo
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        DBConnection database = new DBConnection();

        DataTable querty(string querty)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(querty, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return table;
            }
        }

        public void RefreshInfo()
        {
            DataTable obj = querty($"SELECT * FROM OrderModel");
            var listStaff = new List<OrderModel>();
            var set = 0;
            while (set < obj.Rows.Count)
            {
                var staff = new OrderModel(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToDateTime(obj.Rows[set][2]), Convert.ToDateTime(obj.Rows[set][3]), Convert.ToInt32(obj.Rows[set][4]), Convert.ToString(obj.Rows[set][5]), Convert.ToString(obj.Rows[set][6]), Convert.ToString(obj.Rows[set][7]));
                listStaff.Add(staff);
                set++;
            }
            DataGrid_ShowInfo.ItemsSource = listStaff;
        }

        public ManagerWindow()
        {
            InitializeComponent();
            RefreshInfo();
        }

        private void Button_Shutdown_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Boreder_Move_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        bool flag = false;
        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (flag == false)
            {
                BUpdate.Background = Brushes.Pink;
            }
            else
            {
                BUpdate.Background = Brushes.LightGreen;
            }
            flag = !flag;
        }

        private void BEnd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
