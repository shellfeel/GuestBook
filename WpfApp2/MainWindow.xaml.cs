using System.Windows;
using MySql.Data.MySqlClient;//引用Mysql.data.dll中的类  
using System.Diagnostics;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection myConnection;
        private MySqlDataReader myDataReader;
        private string id;
        public MainWindow()
        {
            InitializeComponent();
            // Ui 状态初始化
            mainButtonInit();
            // 数据库连接初始化
            initDatabase();
           
        }
        private MySqlDataReader checkInit()
        {
            /// <summary>
            /// 数据库查询初始化
            /// </summary>
            ///<returns>
            ///数据库查询值对象
            ///</returns> 
            ///
            myConnection.Close();
            initDatabase();
            //定义sql语句并查询
            string query = "select * from message_book";
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
            myDataReader = myCommand.ExecuteReader();
            
            return myDataReader;
        }
        private void displayResult()
        {
            // 将结果显示到Gui上


            //  获取数据库数据
            myDataReader.Read();
             id = myDataReader["id"].ToString();
            string name = myDataReader["name"].ToString();
            string email = myDataReader["email"].ToString();
            string content = myDataReader["content"].ToString();
            // 显示到UI上
            messageId.Text = id;
            messageName.Text = name;
            messageEmail.Text = email;
            messageContent.Text = content;
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            // Button显示初始化
            // 数据库查询初始化
            checkInit();
            checkButtonInit();
            displayResult();
            nextBook.Visibility = Visibility.Visible;
        }

        private void mainButtonInit()
        {
            // 主窗口初始化
            welcomeText.Visibility = Visibility.Visible;
            book.Visibility = Visibility.Hidden;

        }
        private void checkButtonInit()
        {
            // 查看留言初始化
            welcomeText.Visibility = Visibility.Hidden;
            book.Visibility = Visibility.Visible;
           

        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            // 增加留言逻辑
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void nextBook_Click(object sender, RoutedEventArgs e)
        {
            
            displayResult();
            // 查看下一条留言
        }

        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            // 删除当前留言
            myConnection.Close();
            myConnection = new MySqlConnection("server=localhost;user id=root;password=;database=book;charset=utf8");
            myConnection.Open();
            string sql = "delete from message_book where id=" + id;
            MySqlCommand myCommand = new MySqlCommand(sql, myConnection);
            int flag = myCommand.ExecuteNonQuery();
            if(flag == 1)
            {
                Debug.WriteLine("删除成功！");
                nextBook.Visibility = Visibility.Hidden;
            }
        }
        private MySqlConnection initDatabase()
        {
            // 定义数据库初始化函数
            myConnection = new MySqlConnection("server=localhost;user id=root;password=;database=book;charset=utf8");
            myConnection.Open();
            return myConnection;
        }
    }

}
