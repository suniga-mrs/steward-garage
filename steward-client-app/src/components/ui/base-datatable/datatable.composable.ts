import type { TDatatableOptions, TData } from "./datatable";
import { merge } from "../../../utilities/function.util";
import useHttpClient from "../../../utilities/http-client.util";

export const dtDefaulOptions = {
  data: {
    type: 'local',
    source: [],
  },
  pagination: false,
  layout: {
    cellWidth: "100px",
    height: "100%",
    minHeight: "300px",
    pagination: {
      pageButtonsNumber: 5,
      pageSize: 5,
    },
  },
  scrollable: false,
  textPlaceholder: {
    noRecords: "No records found",
    pagination: {
      first: "First",
      prev: "Previous",
      next: "Next",
      last: "Last",
      select: "Select page size",
    },
    pageInfo: "Showing {{start}} - {{end}} of {{total}} records",
  },
  columns: [],
};

export const dtClasses = {
  cellAlignCenter: "cell-align-center",
  cellAlignRight: "cell-align-right",
};
export function useDatatable(options: TDatatableOptions) {

  const _httpClient = useHttpClient({
    timeout: 60000,
    baseUrl: "",
  })

  console.log(options);

  const dtOptions: TDatatableOptions = readonly(merge(unref(dtDefaulOptions), options));


  const isLocal = dtOptions.data?.type == "local";
  const paging = reactive<{
    page: number;
    pages: number;
    perPage: number;
    total: number;
    pageInfo: string;
    pageNumbers: number[];
  }>({
    page: 1,
    pages: 0,
    perPage: 10,
    total: 0,
    pageInfo: "",
    pageNumbers: [],
  });

  const dtState = reactive<{
    dataSet: any[] | TData;
    originalDataSet: any[] | TData,
    loadingData: boolean,
    API: {
      // response: any,
      url: string,
      querySource: Record<string, any>,
    }
  }>({
    dataSet: [],
    originalDataSet: [],
    loadingData: false,

    API: {
      // response: null,
      url: "",
      querySource: {},
    }

  });

  function updateDataSet(dataSet: any[]) {

    if (isLocal) {
      dtState.dataSet = dataSet;
    }
    else {
      dtState.dataSet = dataSet;
      dtState.originalDataSet = dataSet;
    }

  }


  async function getRemoteData() {

    let url = unref(dtState.API.url)
    let query = unref(dtState.API.querySource);
    let method = dtOptions.data.type == 'remote' && dtOptions.data.source.method ? dtOptions.data.source.method : "GET";

    dtState.loadingData = true;

    if (method == "GET") {
      let _getResponse = await _httpClient.get({
        url: url,
        data: query
      });
      handleApiResponse(_getResponse);
    }
    else {
      let _postResponse = await _httpClient.post({
        url: url,
        data: query,
      })
      handleApiResponse(_postResponse);
    }

    function handleApiResponse(apiResponse: any) {

      if (dtOptions.data.type == 'remote')
        //TODO: Status code checking
        if (
          dtOptions.data.source?.mapApiReponse
          && typeof dtOptions.data.source.mapApiReponse == 'function'
        ) {
          const _mappedData = dtOptions.data.source.mapApiReponse(apiResponse.data);
          setPaging({
            total: _mappedData.pagination.total
          })
          updateDataSet(_mappedData.data);
        }
        else {
          if (apiResponse.data?.data) {

            let _metaData = apiResponse.data?.meta || { total: 0 }

            setPaging({
              total: _metaData.total
            })

            updateDataSet(apiResponse.data.data);

          }
          else {
            //TODO: Throw error
          }
        }

    }
  }

  onBeforeMount(() => {

    if (dtOptions.data.type == 'local') {
      setInitialLocalData();
    }
    else if (dtOptions.data.type == 'remote') {
      setInitialRemoteData();
    }

  });

  function setPaging({ page = 0, perPage = 0, total = undefined }) {
    paging.page = page ? unref(page) : paging.page;
    paging.perPage = perPage ? unref(perPage) : paging.perPage;

    if (isLocal) {
      paging.total = dtState.originalDataSet.length;
    } else {
      paging.total = total != undefined ? unref(total) : paging.total;
    }

    paging.pages = Math.ceil(paging.total / paging.perPage);
    const _pageButtonNumbers =
      dtOptions?.layout?.pagination?.pageButtonsNumber ||
      dtDefaulOptions.layout?.pagination?.pageButtonsNumber || 0;


    //Set pageNumbers
    let endPageNumber = Math.ceil(paging.page / _pageButtonNumbers) * _pageButtonNumbers;
    let startPageNumber = endPageNumber - _pageButtonNumbers;

    if (endPageNumber > paging.pages) {
      endPageNumber = paging.pages;
    }
    if (startPageNumber < 0) {
      startPageNumber = 0;
    }


    let _pagingNumbers = [];

    for (let x = startPageNumber; x < (endPageNumber || 1); x++) {
      const pageNumber = x + 1;
      _pagingNumbers.push(pageNumber);
    }

    for (let i = 0; i < _pagingNumbers.length; i++) {
      paging.pageNumbers[i] = _pagingNumbers[i]
    }

    if (paging.total != 0) {
      //Set Info
      let infoEnd =
        paging.page == paging.pages ? paging.total : paging.page * paging.perPage;
      infoEnd = infoEnd > paging.total ? paging.total : infoEnd;

      let infoStart = paging.total != 0 ? infoEnd - (paging.perPage - 1) : 0;
      infoStart = infoStart > 0 ? infoStart : paging.total >= 1 ? 1 : 0;

      const _pageInfo =
        dtOptions?.textPlaceholder?.pageInfo || dtDefaulOptions?.textPlaceholder?.pageInfo || "";

      let _info = _pageInfo
        .replace(/{{total}}/g, paging.total.toString())
        .replace(/{{start}}/g, infoStart.toString())
        .replace(/{{end}}/g, infoEnd.toString());

      paging.pageInfo = _info;

    }
    else {
      paging.pageInfo = "";
    }
  }

  function setInitialLocalData() {
    if (isLocal) {

      dtState.dataSet = dtOptions.data.source;

      const _pageSize =
        dtOptions?.layout?.pagination?.pageSize ||
        dtDefaulOptions?.layout?.pagination?.pageSize || 0;
      //create paging
      setPaging({ page: 1, perPage: _pageSize });

      //set data
      updateLocalData();
    }
  }

  async function setInitialRemoteData() {

    if (dtOptions.data.type == "remote") {

      setPaging({ page: 1, perPage: dtOptions.layout?.pagination?.pageSize });
      dtState.API.url = dtOptions.data.source?.url || "";
      setDataSourceQuery(dtOptions.data.source?.params || {})
      getRemoteData();

    }

  }

  function updateLocalData() {
    const start = Math.max(paging.perPage * (paging.page - 1), 0);
    const end = Math.min(start + paging.perPage, paging.total);

    let localDataSet = dtState.originalDataSet.slice(start, end);

    updateDataSet(localDataSet);
  }

  function goToPage(page: number) {
    //do not proceed if current page is same to new page
    if (page == paging.page) {
      return;
    }

    setPaging({ page: page, perPage: paging.perPage });

    if (isLocal) {
      updateLocalData();
    } else {
      setDataSourceQuery(dtState.API.querySource);
      getRemoteData();
    }
  }

  function setDataSourceQuery(query: Record<string, any>) {

    if (dtOptions.data.type == 'remote') {

      let _paging: Record<string, any> = {
        page: paging.page,
        perPage: paging.perPage,
        sortOrder: '',
        sortField: '',
      }

      if (dtOptions.data.source.pagingMap) {
        _paging = dtOptions.data.source.pagingMap(paging.page, paging.perPage)
      }

      let _params = { ...unref(dtOptions.data.source?.params) }

      dtState.API.querySource = merge(merge(_params, unref(query), _paging))

    }


  }

  return {
    dtState,
    dtOptions,
    paging,

    goToPage,
    // reload,
    // setDataSourceQuery,
    setPaging,
  };
}
