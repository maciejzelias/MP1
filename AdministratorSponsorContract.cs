namespace mp1
{
    public class AdministratorSponsorContract
    {
        private Administrator _administrator;
        public Administrator Administrator
        {
            get => _administrator;
            set
            {
                if (value == Administrator) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Administrator value can't be null");
                }
                _administrator = value;
                value.addAdministratorSponsorContract(this);
            }
        }

        private SponsorContract _sponsorContract;
        public SponsorContract SponsorContract
        {
            get => _sponsorContract;
            set
            {
                if (value == SponsorContract) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Sponsor contract value can not be null");
                }
                _sponsorContract = value;
                value.AdministratorSponsorContract = this;
            }
        }
        private string _nameOfSponsor;
        public string NameOfSponsor
        {
            get => _nameOfSponsor;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of sponsor can't be empty or null !");
                }
                _nameOfSponsor = value;
            }
        }

        public SponsorContractType type { get; set; }

        public AdministratorSponsorContract(Administrator administrator, SponsorContract sponsorContract, string name, SponsorContractType type)
        {
            this.Administrator = administrator;
            this.SponsorContract = sponsorContract;
            this.NameOfSponsor = name;
            this.type = type;
        }

        public override string ToString()
        {
            return this.NameOfSponsor;
        }


    }

    public enum SponsorContractType
    {
        electronic,
        architecture,
        airlanes
    }
}