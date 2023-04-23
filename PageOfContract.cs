
namespace mp1
{
    public class PageOfContract
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
        private string _contentOfPage;

        public string ContentOfPage
        {
            get => _contentOfPage;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value of content of page can not be null or empty");
                }
                _contentOfPage = value;
            }
        }

        public PageOfContract(string content)
        {
            this.ContentOfPage = content;
        }

        public override string ToString()
        {
            return this._contentOfPage;
        }
    }
}