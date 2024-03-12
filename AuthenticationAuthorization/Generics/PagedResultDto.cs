using AuthenticationAuthorization.Enums;

namespace AuthenticationAuthorization.Generics
{
    public class PagedResultDto<T> where T : class
    {
        public PagedResultDto(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        public UserListSortEnum Sort { get; set; }

        public List<T> Items { get; set; }


        public static PagedResultDto<T> ToPagedList(List<T> list, int page, int pageSize)
        {
            int count = list.Count();
            var items = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<T>(items, count, page, pageSize);
        }
    }
}