<script lang="ts" setup>
import useLayout from '../../../composables/layout.composable';

const layoutComposable = useLayout();

const props = defineProps<{
  isHeader?: Boolean;
}>();

onMounted(() => {
  layoutComposable.addClass('layout-topbar');
});

onUnmounted(() => {
  layoutComposable.removeClass('layout-topbar');
});
</script>

<template>
  <div
    :class="{
      topbar: true,
      'topbar-header': isHeader,
    }"
  >
    <div v-show="isHeader" class="topbar-brand">
      <!-- SHOW -->
      <slot name="topbar-brand"></slot>
    </div>

    <div>
      <slot></slot>
    </div>

    <!-- <select>
            <option value="TEST">TEST</option>
        </select> -->
  </div>
</template>

<style lang="scss">
@import '../../../assets/scss/util/root-util';

</style>
