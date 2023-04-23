
namespace mp1
{
    public class Contract
    {
        public int durInYears { get; set; }
        public DateTime startDate { get; set; }

        // Add here left_time_of_contract
        
        public Contract(int duration, DateTime date)
        {
            durInYears = duration;
            startDate = date;
        }
    }
}