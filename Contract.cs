
namespace mp1
{
    public class Contract
    {
        int duration { get; set; }
        DateTime startDate { get; set; }

        public Contract(int dur, DateTime time)
        {
            duration = dur;
            startDate = time;
        }
    }
}