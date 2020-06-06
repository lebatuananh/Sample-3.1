namespace Base.Web.Models
{
    public class BasePagingFilterRequest
    {
        private int limit;
        private int page;

        public int Page
        {
            get
            {
                if (page < 1)
                    return 1;
                return page;
            }
            set => page = value;
        }

        public int Limit
        {
            get
            {
                if (limit < 1)
                    return 20;
                if (limit > 200)
                    return 200;
                return limit;
            }
            set => limit = value;
        }
    }
}