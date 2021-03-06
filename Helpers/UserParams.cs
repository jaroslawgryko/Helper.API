namespace Helper.API.Helpers
{
    public class UserParams
    {
        // stronicowanie
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        // filtrowanie
        public string InstytucjaRodzaj { get; set; }

        // sortowanie
        public string OrderBy { get; set; }
    }
}