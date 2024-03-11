using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IndependentWork
{

    /*
     * Mening malumotlar bazam
     */
    internal class DBconnect
    {
        // Bog'lanish yaratilmoqda
        MySqlConnection conn = new MySqlConnection("Data Source=localhost;port=3306;username=root;password=;database=ecommerce");

        // Bog'lanishga urinish
        public MySqlConnection getConnection
        {
            get
            {
                return conn;
            }
        }

        // Bzani ochib bog'lovchi funksiya
        public void openConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        // Bazani yopuvchi funksiya
        public void closeConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}
