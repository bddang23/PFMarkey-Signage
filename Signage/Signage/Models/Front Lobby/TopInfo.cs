namespace Signage.Models.Front_Lobby
{
    public class TopInfo
    {
        public List<VendorCostSaving> vcsList;
        public String totalLastYearCostSave;

        public TopInfo()
        {
            vcsList = new List<VendorCostSaving>();
            totalLastYearCostSave = "";
        }
    }
}
