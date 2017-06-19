using System;
using System.Windows;
using MySql.Data.MySqlClient;//引用Mysql.data.dll中的类  
using System.Collections;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 定位值 343,222,117,240.5
            // 989,212,-529,250.5

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

            checkButtonInit();
            // mysql 连接配置 
            try
            {
                MySqlConnection myConnection = new MySqlConnection("server=localhost;user id=root;password=;database=demo_dev");
                myConnection.Open();
                // 定义sql语句并查询
                string query = "select * from mytable1";
                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.ExecuteNonQuery();
                MySqlDataReader myDataReader = myCommand.ExecuteReader();
                myDataReader.Read();
                myDataReader.Close();
                myConnection.Close();
            }
            catch(Exception )
            {
                Console.Write("异常:");
            }
            
            
            
            

            


        }

        private void checkButtonInit()
        {
            welcomeText.Visibility = Visibility.Hidden;
            messageName.Visibility = Visibility.Visible;
            messageEmail.Visibility = Visibility.Visible;
            messageContent.Visibility = Visibility.Visible;

        }
    }
}
