
namespace mp1
{
    public class Contract
    {
        public int durInYears { get; set; }
        public DateTime startDate { get; set; }

        public Contract(int duration, DateTime date)
        {
            durInYears = duration;
            startDate = date;
        }
    }
}