using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    
    public partial class Window1 : Window
    {
        private MySqlConnection myConnection;

        public Window1()
        {
            InitializeComponent();
            //  初始化数据库
            initDatabase();
        }
        private MySqlConnection initDatabase()
        {
            // 定义数据库初始化函数
            myConnection = new MySqlConnection("server=localhost;user id=root;password=;database=book");
            myConnection.Open();
            return myConnection;
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            // 接受输入的值
            string name = addName.Text;
            string email = addEmail.Text;
            string content = addContent.Text;


            // 定义sql语句并查询
            string query = "INSERT INTO message_book(name,email,content) VALUES('" + name + "','" + email + "','" + content + "')";
            Debug.WriteLine(query);
            MySqlCommand myCommand = new MySqlCommand(query, myConnection); 
            int flag = myCommand.ExecuteNonQuery();
            if (flag==1)
            {
                Tips.Visibility = Visibility.Visible;
            }
          }
        
    }
   }
