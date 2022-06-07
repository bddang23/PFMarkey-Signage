namespace Signage.Models.CSR
{
    public class CSRModel
    {
        public String name;
        public int bookingCount;
        public int lineCount;
        public String sales;

        public CSRModel(String n, String bookCounts, String lineCounts, String sales )
        {
            name = n;
            bookingCount = Convert.ToInt32( bookCounts );
            lineCount = Convert.ToInt32( lineCounts );
            this.sales = sales;
        }
    }
}
