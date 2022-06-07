namespace Signage.Models.CSR
{
    public class TopInfo
    {
        public List<CSRModel> csrList;
        public List<OSRModel> osrList;
        public StatsModel todayModel;
        public StatsModel mtdModel;

        public TopInfo()
        {
            csrList = new List<CSRModel>();
            osrList = new List<OSRModel>();
            todayModel = new StatsModel();
            mtdModel = new StatsModel(); 
        }

    }
}
