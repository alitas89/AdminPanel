using AdminPanel.EntityLayer.Abctract;

namespace AdminPanle.BusinessLayer.Other.Response
{
    public class PageResponse<T>
        where T: new()
    {
        public List<T> data { get; set; }
        public int totalCount { get; set; }

        public PageResponse()
        {

        }
        public PageResponse(List<T> Data, int TotalCount)
        {
            this.data = Data;
            this.totalCount = TotalCount;
        }
    }
}
