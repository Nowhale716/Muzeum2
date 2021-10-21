using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Muzeum
{
    class DataBaseCore
    {
        public static string connStr = @"Data Source=62.78.81.19;Initial Catalog=Музей;User ID=24-тпшалаевнс;Password=481810";

        public static DataTable Query(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr);
                adapter.Fill(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД" + ex, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return table;
        }
    }
}
