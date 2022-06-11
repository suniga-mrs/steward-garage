namespace Steward.Garage.Application.Shared.Models
{
    //https://khalidabuhakmeh.com/cursor-paging-with-entity-framework-core-and-aspnet-core
    public class Pagination
    {
        public int Page { get; private set; }
        public int PerPage { get; private set; }
        public int Pages { get; private set; }
        public int Total { get; private set; }
        public string SortOrder { get; private set; } = string.Empty;
        public string SortField { get; private set; } = string.Empty;

        public Pagination(PagingQuery pagingQuery, int totalRecords)
        {
            Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords) / Convert.ToDecimal(pagingQuery.PerPage)));
            Total = totalRecords;
            Page = pagingQuery.Page <= 0 ? 1 : pagingQuery.Page;
            PerPage = pagingQuery.PerPage;
            SortField = pagingQuery.SortField;
            SortOrder = pagingQuery.SortOrder;
        }

    }

    public class PagingQuery
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
        public string SortOrder { get; set; } = string.Empty; // asc & desc
        public string SortField { get; set; } = string.Empty;
        //public string sortCode { get {
        //        return $"{sortField.ToLower().Trim()}-{sortOrder.ToLower()}";
        //    } 
        //}

        public string GetSortCode()
        {
            return $"{SortField.ToLower().Trim()}-{SortOrder.ToLower()}";
        }
    }

    public class PaginatedResult<TData>
    {
        public TData? Data { get; private set; }
        //public int TotalCount { get; private set; } = 0;

        public Pagination Pagination { get; private set; }


        public PaginatedResult(TData data, PagingQuery pagingQuery, int totalCount)
        {
            Data = data;
            //TotalCount = totalCount;

            Pagination = new Pagination(pagingQuery, totalCount);

        }
    }
}
