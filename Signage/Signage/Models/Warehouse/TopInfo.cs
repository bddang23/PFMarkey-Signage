namespace Signage.Models.Warehouse
{
    public class TopInfo
    {
        public WHStats ytd;
        public WHStats mtd;
        public WHStats today;
        public List<CostingInfo> info;
        public List<InventoryStats> autocribSpecialist;
        public List<InventoryStats> daysOfSupply;

        public TopInfo()
        {
            ytd = new WHStats();
            mtd = new WHStats();
            today = new WHStats();
            info = new List<CostingInfo>();
            autocribSpecialist = new List<InventoryStats>();
            daysOfSupply = new List<InventoryStats>();
        }
        
    }
}
