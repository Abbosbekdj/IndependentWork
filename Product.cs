using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IndependentWork
{
    internal class Product
    {
        DBconnect conn = new DBconnect();
        // create a function to add new product to the databases

        public bool insertProduct(string pname, string pcount, string pbrand, string pprice, byte[] pimg)
        {
            var status = false;
            try
            {
                conn.openConnection();
                var newconn = conn.getConnection;
                var sql = @"INSERT INTO `products`(`Nomi`, `Soni`, `Brend`, `Narxi`, `Rasmi`) VALUES (@pn,@pc,@pb,@pp,@pi)";
                MySqlCommand terminal = newconn.CreateCommand();
                terminal.CommandText = sql;

                // @pn,@pc,@pb,@pp, @pd,@pi Going
                terminal.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pname;
                terminal.Parameters.Add("@pc", MySqlDbType.VarChar).Value = pcount;
                terminal.Parameters.Add("@pb", MySqlDbType.VarChar).Value = pbrand;
                terminal.Parameters.Add("@pp", MySqlDbType.VarChar).Value = pprice;
                //terminal.Parameters.Add("@pd", MySqlDbType.Date).Value = pdate;
                terminal.Parameters.Add("@pi", MySqlDbType.Blob).Value = pimg;
                if (terminal.ExecuteNonQuery() == 1)
                {
                    status = true;
                }
            }
            finally
            {
                conn.closeConnection();
            }
            return status;
        }

        public DataTable getproductlist()
        {
            MySqlCommand terminal = new MySqlCommand("SELECT * FROM `products` ",conn.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(terminal);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
