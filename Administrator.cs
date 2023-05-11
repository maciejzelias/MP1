namespace mp1
{
    public class Administrator
    {
        private List<AdministratorSponsorContract> _administratorSponsorContracts = new List<AdministratorSponsorContract>();

        public List<AdministratorSponsorContract> AdministratorSponsorContracts
        {
            get => _administratorSponsorContracts.ToList();
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of sponsor contracts can't be null");
                }
                foreach (AdministratorSponsorContract element in value)
                {
                    if (element == null)
                    {
                        throw new ArgumentNullException("Values in list can't be null");
                    }
                }
                _administratorSponsorContracts = value;
            }
        }
        public void addAdministratorSponsorContract(AdministratorSponsorContract administratorSponsorContract)
        {
            if (administratorSponsorContract == null)
            {
                throw new ArgumentNullException("administratorSponsorContreact value can not be null");
            }
            _administratorSponsorContracts.Add(administratorSponsorContract);
        }

        public void removeAdministratorSponsorContract(AdministratorSponsorContract administratorSponsorContract)
        {
            this._administratorSponsorContracts.Remove(administratorSponsorContract);
        }
        // Period of term Administrator ( in years )
        private int _termOfOffice;
        public int TermOfOffice
        {
            get => _termOfOffice;
            set
            {
                if (value < 1)
                {
                    throw new Exception("Value of term of office cannot be lower than 1 !");
                }
                _termOfOffice = value;
            }
        }
        public ManagerStatus Status { get; set; }

        public Administrator(int periodTermOffice, ManagerStatus status)
        {
            this.TermOfOffice = periodTermOffice;
            this.Status = status;
        }

        public override string ToString()
        {
            return Status + " " + TermOfOffice;
        }
    }

    public enum ManagerStatus
    {
        president,
        manager
    }
}