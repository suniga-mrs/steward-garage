<script lang="ts" setup>
import type BaseSideBar from '../ui/base-sidebar/base-sidebar.vue';
import { isSM } from '../../utilities/breakpoint.util';

console.log('Layout Top Header With Sidebar Created');

const elNavSidebar = ref<InstanceType<typeof BaseSideBar>>();

function toggle() {
  elNavSidebar.value?.toggleSidebar();
}
</script>

<template>
  <div class="layout-wrapper d-flex flex-row flex-column-fluid">
    <BaseTopbar :is-header="true">
      <template #topbar-brand>
        <div class="layout-brand-logo d-flex align-items-center h-100">
          <BrandLogo1></BrandLogo1>
        </div>
      </template>
      <template #default>
        <!-- <button type="button" @click="toggle">TOGGLE</button> -->
        <TopbarNavMenu></TopbarNavMenu>
      </template>
    </BaseTopbar>

    <div class="d-flex flex-column content-wrapper">
      <SidebarNavMenu
        v-show="isSM == false"
        ref="elNavSidebar"
        :is-full-layout="false"
      ></SidebarNavMenu>

      <div class="content">
        <slot>
          <RouterView />
        </slot>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped></style>
