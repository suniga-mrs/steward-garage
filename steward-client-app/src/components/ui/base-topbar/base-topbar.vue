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

.layout-topbar {
  .content-wrapper {
    padding-top: user_root_var('topbar-height');
    .content {
      height: calc(100vh - #{user_root_var('topbar-height')});
    }
  }
}

.topbar {
  height: user_root_var('topbar-height');
  background: user_root_var('topbar-bg');
  transition: $layout-transition;
  position: fixed;
  top: 0;
  right: 0;
  left: 0;
  display: flex;

  box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
}

.topbar-brand {
  width: user_root_var('topbar-brand-width');
}
</style>
