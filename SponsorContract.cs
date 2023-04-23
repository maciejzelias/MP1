namespace mp1
{
    public class SponsorContract
    {
        private AdministratorSponsorContract _administratorSponsorContract;

        public AdministratorSponsorContract AdministratorSponsorContract
        {
            get;
            set;
        }
        private float _rate;

        public float Rate
        {
            get => _rate;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Rate can't be lower than zero !");
                }
                _rate = value;
            }
        }
        public SponsorContract(float rate)
        {
            this.Rate = rate;
        }

        public override string ToString()
        {
            return "Konrakt z rata : " + Rate.ToString();
        }
    }
}