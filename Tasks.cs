namespace mp1
{
    public class Task
    {
        private PlayerContract _playerContract;

        public PlayerContract PlayerContract
        {
            get => _playerContract;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value of player contract can not be null");
                }
                _playerContract = value;
            }
        }

        public Task(PlayerContract playerContract, string desc)
        {
            this.PlayerContract = playerContract;
            this.Description = desc;
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value of description can not be null or empty");
                }
                _description = value;
            }
        }

        public override string ToString()
        {
            return this._description;
        }

    }
}