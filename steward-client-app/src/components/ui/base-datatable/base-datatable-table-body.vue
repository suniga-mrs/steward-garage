dtDefaulOptions<script lang="ts" setup>
import { initial } from 'lodash';
import type {
  TDatatableColumnItem,
  TData,
  TDatatableOptions,
} from './datatable';
import { dtDefaulOptions, dtClasses } from './datatable.composable';

const props = defineProps<{
  columns: TDatatableColumnItem[];
  data: any[] | TData;
  dtOptions: TDatatableOptions;
}>();

const bodyStyle = {
  maxHeight: props.dtOptions.layout?.height || dtDefaulOptions.layout.height,
  minHeight: props.dtOptions.layout?.minHeight || dtDefaulOptions.layout.minHeight,
  overflow: props.dtOptions?.scrollable ? 'auto' : 'hidden',
};
</script>

<template>
  <tbody :style="bodyStyle">
    <tr v-for="(row, index) in data" :key="index">
      <td
        v-for="(column, index) in columns"
        :key="column.field"
        :data-field="column.field"
        :class="[
          column?.textAlign == 'center' ? dtClasses.cellAlignCenter : '',
          column?.textAlign == 'right' ? dtClasses.cellAlignRight : '',
        ]"
      >
        <div
          class="cell-inner-wrapper"
          :style="{
            width: column.width ?? dtDefaulOptions.layout.cellWidth,
          }"
        >
          <component
            :is="column.template"
            v-if="typeof column.template == 'object'"
            :row-data="row"
          >
          </component>
          <slot v-else name="cell" :column-data="column" :row-data="row">
            {{ row[column.field] }}
          </slot>
        </div>
      </td>
    </tr>
  </tbody>
</template>
