<script lang="ts" setup>
import { useNavigationMenu } from "../../../composables/navmenu.composable.";

//Pass data to a state management
const {
  currChildrenNavMenu,
  sidebarHeaderComponent,
  setSidebarHeaderComponent,
} = useNavigationMenu();
</script>

<template>
  <BaseSidebar class="app-sidebar">
    <template #default>
      <!-- <component v-if="sidebarHeaderComponent" :is="sidebarHeaderComponent"></component> -->

      <div class="sidebar-header" v-if="sidebarHeaderComponent">
        <component :is="sidebarHeaderComponent"></component>
        <!-- <SidebarHeaderVehicleInfo></SidebarHeaderVehicleInfo> -->
      </div>
      <ul class="sidebar-menu-list">
        <li
          v-for="navItem in currChildrenNavMenu"
          v-show="navItem.placement?.includes('sidebar')"
          :key="navItem.name"
        >
          <BaseLink :to="{ name: navItem.name }" class="sidebar-menu-list-item-link">
            {{ navItem.title }}
          </BaseLink>
        </li>
      </ul>
    </template>
  </BaseSidebar>
</template>

<style lang="scss">
@import "../../../assets/scss/util/root-util";
$sidebar-menu-item-height: 40px;
$sidebar-menu-item-margin-y: 2.5px;

$sidebar-menu-padding-left: 2rem;
$sidebar-menu-item-link-padding-left: 1.5rem;

.app-sidebar {
  padding-left: $sidebar-menu-padding-left;

  .sidebar-header {
    margin-top: 1rem;
    margin-bottom: 1rem;
  }

  .sidebar-menu-list {
    list-style: none;
    margin: 0;
    padding: 0;

    > li {
      height: $sidebar-menu-item-height;
      margin: #{$sidebar-menu-item-margin-y} 0;
    }
  }

  .sidebar-menu-list-item-link {
    text-decoration: none;
    color: $color-black;
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    padding-left: $sidebar-menu-item-link-padding-left;

    &.active,
    &:hover,
    &:focus,
    &:active {
      background-color: user_root_var("content-bg");
      color: $color-black;
    }
  }
}
</style>
