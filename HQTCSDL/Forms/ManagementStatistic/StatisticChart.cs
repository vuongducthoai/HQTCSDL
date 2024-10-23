using HQTCSDL.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HQTCSDL.Forms.ManagementStatistic
{
    public partial class StatisticChart : Form
    {
        Statistic statistic = new Statistic();
        public StatisticChart()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            btnClearChart_Click();
            DateTime selectedDate = dateTimePicker.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;
            DataTable dt = statistic.StatisticRevenueByDayInMonth(month, year);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Day";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "VND";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chart1.Series["Price"].Points.AddXY(dt.Rows[i]["Day"], dt.Rows[i]["Revenue"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnClearChart_Click();
            DateTime selectedDate = dateTimePicker.Value;
            int year = selectedDate.Year;
            DataTable dt = statistic.StatisticRevenueByMonthInYear(year);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "VND";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chart1.Series["Price"].Points.AddXY(dt.Rows[i]["Month"], dt.Rows[i]["Revenue"]);
            }
        }

        private void btnClearChart_Click()
        {
            // Xóa tất cả các điểm dữ liệu của biểu đồ
            chart1.Series["Price"].Points.Clear();

            // Nếu bạn có nhiều Series, bạn có thể lặp qua và xóa tất cả:
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            // Optionally: Bạn có thể xóa tiêu đề trục hoặc thiết lập lại biểu đồ về mặc định
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "";
        }
    }
}



