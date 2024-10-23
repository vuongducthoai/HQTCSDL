using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Data.SqlTypes;

namespace HQTCSDL.model
{
    internal class Statistic
    {

        My_DB db = new My_DB();
        public DataTable StatisticRevenueByDayInMonth(int month, int year)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.func_calculateRevenueByDayInMonth(@Month, @Year)", db.getConnection);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@Month", SqlDbType.Int)).Value = month;
            cmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int)).Value = year;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            try
            {
                db.openConnection();
                adapter.Fill(dataTable);
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                db.closeConnection();
            }

            return dataTable;
        }

        public DataTable StatisticRevenueByMonthInYear(int year)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.func_calculateRevenueByMonthInYear(@Year)", db.getConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int)).Value= year;

            SqlDataAdapter adapter= new SqlDataAdapter(cmd);

            try
            {
                db.openConnection();
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi tim kiem: " + ex.Message);
            }
            finally
            {

                db.closeConnection();
            }
            return table;
        }

    }
}
