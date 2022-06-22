<script lang="ts" setup>
import { useNavigationMenu } from "../../../composables/navmenu.composable.";

//Pass data to a state management
const { currChildrenNavMenu } = useNavigationMenu();
</script>

<template>
  <BaseSidebar>
    <template #default>
      <ul class="sidebar-menu-list">
        <li
          v-for="navItem in currChildrenNavMenu"
          :key="navItem.name"
          v-show="navItem.placement?.includes('sidebar')"
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

$sidebar-menu-item-link-padding-left: 1em;

.sidebar-menu-list {
  list-style: none;

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
  padding-left: $sidebar-menu-item-link-padding-left;
  display: flex;
  align-items: center;

  &.active,
  &:hover,
  &:focus,
  &:active {
    background-color: user_root_var("content-bg");
  }
}
</style>
