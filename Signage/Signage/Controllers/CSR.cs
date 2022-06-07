using Microsoft.Data.SqlClient;
using Signage.Controllers.Shared;
using Signage.Models.CSR;
using System.Diagnostics;

namespace Signage.Controllers
{
    public class CSR
    {
        SqlCommand com;
        SqlDataReader dr;
        SqlConnection conn;
        public TopInfo topInfo;
        public BottomFetchData botInfo;


        public CSR()
        {
            com = new SqlCommand();
            conn = new SqlConnection();
            topInfo = new TopInfo();
            botInfo = new BottomFetchData();
            dr = null;
            conn.ConnectionString = "Data Source=PFM-SQL;Initial Catalog=PFMI_Signage;User Id=pfmarkey;Password=Pfmi2880;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database='PFMI_Signage'";
            FetchData();
        }

        private void FetchData()
        {
            if (topInfo.osrList.Count > 0)
                topInfo.osrList.Clear();
            if (topInfo.csrList.Count > 0)
                topInfo.csrList.Clear();

            try
            {
                conn.Open();
                com.Connection = conn;

                addOSR(com);
                addCSR(com);
                addTodayModel(com);
                addMTDModel(com);
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        private void addCSR(SqlCommand com)
        {
            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.CSR ORDER BY Sales";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.csrList.Add(new CSRModel(dr["Name"].ToString(), dr["BookingCount"].ToString(), dr["Line Count"].ToString(), dr["Sales"].ToString()));
            }
            dr.Close();
        }

        private void addOSR(SqlCommand com)
        {
            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.OSR ORDER BY Sales";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.osrList.Add(new OSRModel(dr["Name"].ToString(), dr["Sales"].ToString()));
            }
            dr.Close();
        }

        private void addTodayModel(SqlCommand com)
        {
            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.BookingsDaily";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.todayModel.bookings = dr["Expr1"].ToString();
            }
            dr.Close();

            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.SalesDaily";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.todayModel.sales =dr["Sales"].ToString();
            }
            dr.Close();

            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.GoalDaily";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.todayModel.goal =dr["Expr1"].ToString();
            }
            dr.Close();
        }
        private void addMTDModel(SqlCommand com)
        {
            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.BookingsMTD";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.mtdModel.bookings = dr["Expr1"].ToString();
            }
            dr.Close();

            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.SalesMTD";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.mtdModel.sales = dr["Sales"].ToString();
            }
            dr.Close();

            com.CommandText = "SELECT * FROM PFMI_Signage.dbo.GoalMTD";
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.mtdModel.goal = dr["Expr1"].ToString();
            }
            dr.Close();
        }

    }
}
