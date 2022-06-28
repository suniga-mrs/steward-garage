dtDefaulOptions<script lang="ts" setup>
import { ref } from 'vue';
import type { TDatatableColumnItem } from './datatable';
import { dtDefaulOptions, dtClasses } from './datatable.composable';
// import { useResizeObserver } from '@vueuse/core';

// const elCells = ref<HTMLElement | undefined>();

onMounted(() => {
  // console.log(elCells.value)
  // for (let key of elCells.value) {
  //     console.log(elCells.value[key])
  //     // useResizeObserver(elCell, (entries) => {
  //     //     const entry = entries[0];
  //     //     const { width, height } = entry.contentRect;
  //     //     console.log(width);
  //     // })
  // }
});

defineProps<{
  columns: TDatatableColumnItem[];
}>();
</script>

<template>
  <thead>
    <tr>
      <th
        v-for="(column, index) in columns"
        :key="column.field"
        :class="[
          column?.textAlign == 'center' ? dtClasses.cellAlignCenter : '',
          column?.textAlign == 'right' ? dtClasses.cellAlignRight : '',
        ]"
      >
        <div
          ref="elCells"
          class="cell-inner-wrapper"
          :style="{
            width: column.width ?? dtDefaulOptions.layout.cellWidth,
          }"
        >
          <component
            :is="column.templateHeader"
            v-if="typeof column.templateHeader == 'object'"
          ></component>
          <slot v-else name="header-cell" :column-data="column">
            {{ column.title }}
          </slot>
        </div>
      </th>
    </tr>
  </thead>
</template>
