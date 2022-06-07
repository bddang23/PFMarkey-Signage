using Microsoft.Data.SqlClient;
using Signage.Controllers.Shared;
using Signage.Models.Front_Lobby;
using System.Diagnostics;

namespace Signage.Controllers
{
    public class FrontLobby
    {
        SqlCommand com;
        SqlDataReader dr;
        SqlConnection conn;
        public TopInfo topInfo;
        public BottomFetchData botInfo;

        public FrontLobby()
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

            if (topInfo.vcsList.Count > 0)
                topInfo.vcsList.Clear();

            try
            {
                conn.Open();
                com.Connection = conn;

                addVendors(com);
                addTotalCost(com);
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        private void addTotalCost(SqlCommand com)
        {
            com.CommandText = "SELECT SUM(Cost_Saved)" +
                              "FROM PFMI_Signage.dbo.Vendors_Cost_Saved vcs " +
                              "WHERE YEAR(Date) = YEAR(GETDATE()) - 1";


            dr = com.ExecuteReader();
            while (dr.Read())
            {
                double cost = Convert.ToDouble(dr[0].ToString());
                topInfo.totalLastYearCostSave = string.Format("{0:n}", cost);
            }
            dr.Close();
        }

        private void addVendors(SqlCommand com)
        {
            com.CommandText = "SELECT  Vendor_Name,Cost_Saved " +
                "FROM PFMI_Signage.dbo.Vendors_Cost_Saved vcs " +
                "JOIN PFMI_Signage.dbo.Vendors v ON v.id = vcs.Vendor " +
                "WHERE YEAR(Date) = YEAR(GETDATE()) - 1 " +
                "ORDER BY Vendor_Name";


            dr = com.ExecuteReader();
            while (dr.Read())
            {
                topInfo.vcsList.Add(new VendorCostSaving(dr["Vendor_Name"].ToString(), dr["Cost_Saved"].ToString()));
            }
            dr.Close();
        }
    }
}
