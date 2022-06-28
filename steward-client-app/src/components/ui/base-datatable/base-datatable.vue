<script lang="ts" setup>
import { ref, unref, reactive, computed } from "vue";
import { useScroll } from "@vueuse/core";
import type { TDatatableOptions } from "./datatable";

import { useDatatable, dtDefaulOptions } from "./datatable.composable";

const props = defineProps<{
  options: TDatatableOptions;
}>();

const _defaultOptions: TDatatableOptions = {
  data: props.options.data,
  pagination: false,
  layout: {
    height: undefined,
  },
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
  columns: props.options.columns,
};

const { dtOptions, paging, goToPage, dtState } = useDatatable(props.options);

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
  <div class="datatable">
    <table class="table d-block">
      <BaseDatatableTableHead
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
      <BaseDatatableTableBody
        ref="elTableBody"
        :columns="scrollableColumns"
        :data="dtState.dataSet"
        :dt-options="dtOptions"
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
      <BaseDatatableTableFoot
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
    </table>
    <div class="datatable-paging-controls">
      <div class="btn-group">
        <button
          class="btn btn-sm btn-secondary"
          type="button"
          @click="goToPage(1)"
          :disabled="paging.page <= 1"
        >
          {{
            dtOptions?.textPlaceholder?.pagination?.first ||
            dtDefaulOptions?.textPlaceholder?.pagination?.first ||
            ""
          }}
        </button>
        <button
          class="btn btn-sm btn-secondary"
          type="button"
          @click="goToPage(paging.page - 1)"
          :disabled="paging.page <= 1"
        >
          {{
            dtOptions?.textPlaceholder?.pagination?.prev ||
            dtDefaulOptions?.textPlaceholder?.pagination?.prev
          }}
        </button>
        <button
          class="btn btn-sm btn-secondary"
          v-for="page in paging.pageNumbers"
          :key="page"
          :class="{
            active: paging.page == page,
          }"
          type="button"
          @click="goToPage(page)"
        >
          {{ page }}
        </button>
        <button
          class="btn btn-sm btn-secondary"
          type="button"
          @click="goToPage(paging.page + 1)"
          :disabled="paging.page >= paging.pages"
        >
          {{
            dtOptions?.textPlaceholder?.pagination?.next ||
            dtDefaulOptions?.textPlaceholder?.pagination?.next ||
            ""
          }}
        </button>
        <button
          class="btn btn-sm btn-secondary"
          type="button"
          @click="goToPage(paging.pages)"
          :disabled="paging.page >= paging.pages"
        >
          {{
            dtOptions?.textPlaceholder?.pagination?.last ||
            dtDefaulOptions?.textPlaceholder?.pagination?.last ||
            ""
          }}
        </button>
      </div>
      <div>
        {{ paging.pageInfo }}
      </div>
    </div>
  </div>
</template>

<style lang="scss">
@import "../../../assets/scss/variables";
@import "../../../assets/scss/scrollbar";

$datatable-cell-padding-x: 0.5rem;
$datatable-cell-padding-y: 0.3rem;

$datatable-scroll-x-width: $scrollbar-thumb-size;
$datatable-scroll-y-width: $scrollbar-thumb-size;

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
      // display: none;
      //TODO: native scrollbar vs perfect scrollbar
      // display: none;
      @include mix-scrollbar();
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
  }
}
</style>
