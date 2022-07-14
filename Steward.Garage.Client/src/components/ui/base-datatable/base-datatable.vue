<script lang="ts" setup>
import { ref, unref, reactive, computed } from "vue";
import { useScroll } from "@vueuse/core";
import type { TDatatableOptions } from "./datatable";
import { isChromium } from "../../../utilities/function.util";

import { useDatatable, dtDefaulOptions } from "./datatable.composable";

const props = defineProps<{
  options: TDatatableOptions;
}>();

const {
  dtOptions,
  paging,
  goToPage,
  dtState,
  reload,
  setDataSourceQuery,
  filterRemoteData,
} = useDatatable(props.options);

// const dataSet = computed(() => {
//     if (props.options.data.type == 'local')
//         return props.options.data.source
//         return [];
// });

// const _lockedLeftColumns = computed(() => {
//   return dtOptions.columns.filter((item) => item.lock == 'left');
// });

// const _lockedRightColumns = computed(() => {
//   return dtOptions.columns.filter((item) => item.lock == 'right');
// });

const scrollableColumns = computed(() => {
  return dtOptions.columns.filter((item) => item.lock == undefined || item.lock == null);
});

const elTableHead = ref<HTMLElement>();
const elTableBody = ref<HTMLElement>();
const elTableFooter = ref<HTMLElement>();

const { x } = useScroll(elTableBody);

const tableScrollLeft = computed(() => {
  return "-" + unref(x) + "px";
});

// const tableScrollTop = computed(() => {
//     return '-' + unref(y) + 'px';
// })
</script>

<template>
  <div class="datatable w-100">
    <table
      class="table w-100 mb-3"
      :class="{
        'native-scroll-chrome': isChromium() && dtOptions.scrollable,
      }"
    >
      <!-- begin:: Table Head -->
      <BaseDatatableTableHead
        v-if="dtOptions.layout?.header"
        ref="elTableHead"
        :columns="scrollableColumns"
        :style="{
          left: tableScrollLeft,
        }"
      >
        <template #header-cell="{ columnData }">
          <slot
            :name="'header-cell-' + columnData.field"
            :column-data="columnData"
          ></slot>
        </template>
      </BaseDatatableTableHead>
      <!-- end:: Table Head -->

      <!-- begin:: Table Body -->
      <!-- <template v-if="dtState.loadingData">
        <div
          class="d-flex justify-content-center align-items-center py-5"
          :style="{
            maxHeight: dtOptions.layout?.height,
            minHeight: dtOptions.layout?.minHeight,
          }"
        >
          <div class="spinner-border text-primary" role="status">
            <span class="visually-hidden"></span>
          </div>
        </div>
      </template> -->
      <BaseDatatableTableBody
        ref="elTableBody"
        :columns="scrollableColumns"
        :data="dtState.dataSet"
        :dt-options="dtOptions"
        :loading-data="dtState.loadingData"
      >
        <template #cell="{ columnData, rowData }">
          <slot
            :name="'body-cell-' + columnData.field"
            :column-data="columnData"
            :row-data="rowData"
          >
          </slot>
        </template>
      </BaseDatatableTableBody>
      <!-- end:: Table Body -->

      <!-- begin:: Table Foot -->
      <BaseDatatableTableFoot
        v-if="dtOptions.layout?.footer"
        ref="elTableFooter"
        :columns="scrollableColumns"
        :style="{
          left: tableScrollLeft,
        }"
      >
        <template #footer-cell="{ columnData }">
          <slot
            :name="'footer-cell-' + columnData.field"
            :column-data="columnData"
          ></slot>
        </template>
      </BaseDatatableTableFoot>
      <!-- end:: Table Foot -->
    </table>

    <!-- begin:: Pagination -->
    <div
      v-if="dtOptions.pagination && dtState.originalDataSet.length > 0"
      class="datatable-paging"
    >
      <BasePagination
        class="datatable-paging-controls"
        :page="paging.page"
        :pages="paging.pages"
        :per-page="paging.perPage"
        :total="paging.total"
        :page-numbers="dtOptions.layout?.pagination?.pageButtonsNumber || 5"
        :text-placeholders="{
          first: dtOptions.textPlaceholder?.pagination?.first || 'First',
          prev: dtOptions.textPlaceholder?.pagination?.prev || 'Prev',
          next: dtOptions.textPlaceholder?.pagination?.next || 'Next',
          last: dtOptions.textPlaceholder?.pagination?.last || 'Last',
        }"
        size="sm"
        @go-to-page="goToPage"
      >
      </BasePagination>
      <div class="datatable-paging-info">
        <!-- <BaseSelect
          v-model="paging.perPage"
          class="datatable-paging-perpage"
          :options="[10, 20, 50]"
          :clearable="false"
        ></BaseSelect> -->
        <span class="datatable-paging-summary">{{ paging.pageInfo }}</span>
      </div>
    </div>
    <!-- End:: Pagination -->
  </div>
</template>

<style lang="scss">
@import "../../../assets/scss/variables";
@import "../../../assets/scss/scrollbar";

.datatable {
  display: flex;
  position: relative;
  flex-direction: column;
  table {
    overflow: hidden;
    width: 100%;
    display: block;
    // thead > tr {

    // }

    > :not(:first-child) {
      border-top: none;
    }

    tr {
      width: 100%;
      position: relative;
      display: table;
      table-layout: initial;
    }

    > thead,
    > tbody,
    > tfoot {
      display: block;
      position: relative;
      // border: none;
      // tr {
      //   // td:first-child,
      //   // th:first-child {
      //   //   position: -webkit-sticky;
      //   //   position: sticky;
      //   //   background-color: red !important;
      //   // }
      // }

      td,
      th {
        // border: none;
        padding: #{$datatable-cell-padding-y} 0 #{$datatable-cell-padding-y} #{$datatable-cell-padding-x};
        margin: 0;
        vertical-align: middle;
      }
    }

    > tbody {
      //TODO: native scrollbar vs perfect scrollbar
      @include mix-scrollbar();
    }

    &.native-scroll-chrome {
      > thead,
      > tfoot {
        padding-right: $datatable-scroll-x-width;
      }
    }
  }

  .cell-inner-wrapper {
    // padding: #{$datatable-cell-padding-y} #{$datatable-cell-padding-x} ;
    border: none;
    margin: 0;
    overflow: auto;
    position: relative;

    &.cell-resizable {
      resize: horizontal;
      overflow: auto;
      //    &::after {
      //     content: '';
      //     position: absolute;
      //     cursor: col-resize;
      //     width: 5px;
      //     top: 0;
      //     right: 0;

      //     background-color: red;
      //     height: 100%;

      //    }
    }

    .cell-align-center {
      text-align: center;
    }

    .cell-align-right {
      text-align: right;
    }
  }

  .datatable-paging-controls {
    display: flex;
    justify-content: space-between;
    align-items: center;

    .pagination {
      margin-bottom: 0;
    }
  }

  .datatable-paging {
    display: flex;
    justify-content: space-between;
    align-items: center;
    // margin-top: 10px;
  }
}
</style>
