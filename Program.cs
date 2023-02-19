using System.Data.SqlClient;
namespace CsharpForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Suyog laptop Database
            //SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=signUp;Integrated Security=True");
            
            //Suyog lab Database
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");


            //Rohan lab Database
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");

            //Rohan Legion database
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");

            ApplicationConfiguration.Initialize();
            conn.Open();
            string query = "SELECT count(*) from signUp_Table";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            int count=Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (count > 0)
            {
                Application.Run(new Mainmenu());
            }
            else
            {
                Application.Run(new signUpForm());
            }

            /*ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());*/
        }
    }
}