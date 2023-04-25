
namespace mp1
{
    public class PlayerContract
    {
        private Dictionary<int, PageOfContract> _pages = new();

        public Dictionary<int, PageOfContract> Pages
        {
            get => _pages.ToDictionary(entry => entry.Key, entry => entry.Value);
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value of pages can not be null");
                }
                foreach (var element in value)
                {
                    if (element.Value == null)
                    {
                        throw new ArgumentNullException("Values inside pages dictionary can not be null");
                    }
                    if (element.Key < 0)
                    {
                        throw new Exception("Key values inside dictionary can not be negative");
                    }
                }
                _pages = value;
            }
        }
        public void addPageOfContract(int key, PageOfContract pageOfContract)
        {
            if (key < 0)
            {
                throw new Exception("Key value can not be negative");
            }
            if (pageOfContract == null)
            {
                throw new ArgumentNullException("page of conract value can not be null");
            }
            _pages.Add(key, pageOfContract);
            pageOfContract.PlayerContract = this;
        }
        private List<Task> _requiredTasks = new();

        public List<Task> RequiredTasks
        {
            get => _requiredTasks.ToList();
        }

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

        public void addTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task value can not be null");
            }
            this._requiredTasks.Add(task);
        }

        public void addRequiredTasks(List<string> tasks)
        {
            foreach (string desc in tasks)
            {
                new Task(this, desc);
            }
        }
        public PlayerContract(float salary, List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                throw new ArgumentException("There has to by at least one task in conract!");
            }
            addRequiredTasks(tasks);
            this.Salary = salary;
        }

        public override string ToString()
        {
            return "Konktrakt Piłkarski opiewający kwotą : " + this.Salary.ToString();
        }

    }
}