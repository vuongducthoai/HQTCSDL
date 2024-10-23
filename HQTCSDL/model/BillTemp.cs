using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HQTCSDL
{
    internal class Bill
    {
        public int IdBill { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int IdVoucher { get; set; }
        public int IdCustomer { get; set; }
        public int IdUser { get; set; }

        public Bill(DateTime date, string status, int idVoucher, int idCustomer, int idUser)
        {
            Date = date;
            Status = status;
            IdVoucher = idVoucher;
            IdCustomer = idCustomer;
            IdUser = idUser;
        }

        public void AddBill(SqlConnection connection)
        {
            string query = "INSERT INTO Bill (Date, Status, IdVoucher, IdCustomer, IdUser) " +
                           "VALUES (@Date, @Status, @IdVoucher, @IdCustomer, @IdUser);";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@IdVoucher", IdVoucher);
                command.Parameters.AddWithValue("@IdCustomer", IdCustomer);
                command.Parameters.AddWithValue("@IdUser", IdUser);

                command.ExecuteNonQuery();
            }
        }


    }
}
