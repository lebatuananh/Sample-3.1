namespace Base.Web.Models
{
    public class PaginationModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public PaginationModel()
        {

        }
    }
}