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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDemo.Classess;

namespace WpfAppDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создание карточки объекта.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void CreateCard(int row, int column, string Text)
        {
            TextBlock text = new TextBlock();
            text.Text = Text;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            this.Content = text;
        }

        DBConnection database = new DBConnection();

        public MainWindow()
        {
            InitializeComponent();
           
        }

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

        private void Boreder_Move_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TAuth_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BAuth.Visibility = Visibility;
            BShow.Visibility = Visibility.Hidden;
        }

        private void TShow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BAuth.Visibility = Visibility;
            BShow.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                  
            DataTable obj = querty($"SELECT * FROM Auth WHERE Login = '{TB_Loggin.Text}' AND Pass = '{TB_Pass.Text}'");
            if(obj.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            var user = new AuthModel(Convert.ToString(obj.Rows[0][0]), Convert.ToString(obj.Rows[0][1]), Convert.ToString(obj.Rows[0][2]), Convert.ToString(obj.Rows[0][3]));

            if(user.Role == "Администратор")
            {
                var userW = new AdminWindow();
                userW.Show();
                this.Hide();
            }
            else if(user.Role == "Менеджер")
            {
                var userW = new ManagerWindow();
                userW.Show();
                this.Hide();
            }
            else if(user.Role == "Клиент")
            {
                var userW = new UserWindow();
                userW.Show();
                this.Hide();
            }
           
        }
    }
}
