namespace Steward.WheelBox.Application.Shared.Models
{
    public class AppResponse<TData>
    {
        public TData? Data { get; private set; }
        public Pagination? Pagination { get; private set; }

        public AppResponse(TData? objData)
        {
            Data = objData;
        }

        public AppResponse(TData? objData, Pagination pagination)
        {
            Data = objData;
            Pagination = pagination;
        }

    }
}
