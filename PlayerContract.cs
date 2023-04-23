
namespace mp1
{
    public class PlayerContract
    {
        private Player _player;

        public Player player { get; set; }
        private float _salary;

        public float Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary value can't be lower than 0");
                }
                _salary = value;
            }
        }

        public PlayerContract(float salary)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return "Konktrakt Piłkarski opiewający kwotą : " + this.Salary.ToString();
        }

    }
}