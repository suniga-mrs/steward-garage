import type { TDatatableOptions, TData } from "./datatable";
import { merge } from "../../../utilities/function.util";

export const dtDefaulOptions: TDatatableOptions = {
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


  const dtOptions = reactive(merge(unref(dtDefaulOptions), options));


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
    API: {
      response: any,
      url: string,
      querySource: Record<string, any>,
    }
  }>({
    dataSet: [],
    originalDataSet: [],
    // loadingData: false,

    API: {
      response: null,
      url: "",
      querySource: {},
    }

  });

  async function getRemoteData() {


    // let url = unref(dtState.API.url)
    // let query = unref(dtState.API.querySource);

    // dtState.loadingData = true;

    // await axios.get(url, {
    //   params: query
    // })
    //   .then(function (response) {

    //     console.log(response);

    //     dtState.API.response = response.data;

    //     updateRemoteData();

    //   })
    //   .catch(function (error) {
    //     console.error(error);
    //   })
    //   .then(function () {
    //     // always executed

    //     dtState.loadingData = false;

    //   });
  }

  onBeforeMount(() => {
    setInitialLocalData();
    // setInitialRemoteData();
  });

  function setPaging({ page = 0, perPage = 0, total = 0, pages = 0 }) {
    paging.page = page ? unref(page) : paging.page;
    paging.perPage = perPage ? unref(perPage) : paging.perPage;

    if (isLocal) {
      paging.total = dtState.originalDataSet.length;
    } else {
      paging.total = total != undefined ? unref(total) : paging.total;
      paging.pages = pages != undefined ? unref(pages) : paging.pages;
    }

    paging.pages = Math.ceil(paging.total / paging.perPage);

    const _pageButtonNumbers =
      dtOptions?.layout?.pagination?.pageButtonsNumber ||
      dtDefaulOptions.layout?.pagination?.pageButtonsNumber || 0;

    //set pageNumbers
    let endPageNumber = Math.ceil(paging.page / _pageButtonNumbers) * _pageButtonNumbers;
    let startPageNumber = endPageNumber - _pageButtonNumbers;

    if (endPageNumber > paging.pages) {
      endPageNumber = paging.pages;
    }
    if (startPageNumber < 0) {
      startPageNumber = 0;
    }

    paging.pageNumbers = [];

    for (let x = startPageNumber; x < (endPageNumber || 1); x++) {
      const pageNumber = x + 1;
      paging.pageNumbers.push(pageNumber);
    }

    let infoEnd =
      paging.page == paging.pages ? paging.total : paging.page * paging.perPage;
    infoEnd = infoEnd > paging.total ? paging.total : infoEnd;

    let infoStart = paging.total != 0 ? infoEnd - (paging.perPage - 1) : 0;
    infoStart = infoStart > 0 ? infoStart : paging.total >= 1 ? 1 : 0;

    const _pageInfo =
      dtOptions?.textPlaceholder?.pageInfo || dtDefaulOptions?.textPlaceholder?.pageInfo || "";

    paging.pageInfo = _pageInfo
      .replace(/{{total}}/g, paging.total.toString())
      .replace(/{{start}}/g, infoStart.toString())
      .replace(/{{end}}/g, infoEnd.toString());
  }

  function setInitialLocalData() {
    if (isLocal) {
      dtState.dataSet = dtOptions.data.source;
      dtState.originalDataSet = dtOptions.data.source;

      const _pageSize =
        dtOptions?.layout?.pagination?.pageSize ||
        dtDefaulOptions?.layout?.pagination?.pageSize || 0;
      //create paging
      setPaging({ page: 1, perPage: _pageSize });

      //set data
      updateLocalData();
    }
  }

  // async function setInitialRemoteData() {

  //   //create paging 
  //   setPaging({ page: 1, perPage: dtOptions.layout?.pagination?.pageSize });

  //   dtState.API.url = dtOptions.data.source?.url || "";
  //   setDataSourceQuery(dtOptions.data.source?.params)



  //   getRemoteData();
  // }

  function updateLocalData() {
    const start = Math.max(paging.perPage * (paging.page - 1), 0);
    const end = Math.min(start + paging.perPage, paging.total);

    // console.log(start, end);
    // console.log(start, end);
    dtState.dataSet = dtState.originalDataSet.slice(start, end);
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
      // setDataSourceQuery();
      // getRemoteData();
      // updateRemoteData();
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
