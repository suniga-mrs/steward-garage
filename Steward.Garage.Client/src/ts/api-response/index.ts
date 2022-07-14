export interface IPagination {
  page: number;
  perpage: number;
  pages: number;
  total: number;
  sortorder: number;
  sortfield: number;
}

export interface IAppApiResponse<TData> {
  data: TData;
  pagination: IPagination;
}
