<script lang="ts" setup>
import type { TDatatableColumnItem } from './datatable';
import { dtDefaults, dtClasses } from './datatable.composable';

defineProps<{
  columns: TDatatableColumnItem[];
}>();
</script>

<template>
  <tfoot>
    <tr>
      <th
        v-for="column in columns"
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
            width: column.width ?? dtDefaults.layout.cellWidth,
          }"
        >
          <component
            :is="column.templateFoot"
            v-if="typeof column.templateFoot == 'object'"
          >
          </component>
          <slot v-else name="footer-cell" :column-data="column">
            {{ column.title }}
          </slot>
        </div>
      </th>
    </tr>
  </tfoot>
</template>
