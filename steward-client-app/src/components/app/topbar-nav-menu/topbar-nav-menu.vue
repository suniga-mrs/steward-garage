<script lang="ts" setup>
import { useNavigationMenu } from '../../../composables/navmenu.composable.';

const { getRouteByPlacement, currParentNavMenuItem } = useNavigationMenu();

const topbarMenu = getRouteByPlacement('topbar');

watch(currParentNavMenuItem, () => {
  console.log(currParentNavMenuItem.value);
});
</script>

<template>
  <BaseTopbarNavMenu :menu="topbarMenu">
    <template #navMenuItem="{ menu }">
      <li
        v-for="(menuItem, index) in menu"
        :key="menuItem.route"
        tabindex="1"
        :class="{
          'parent-active': menuItem.name == currParentNavMenuItem?.name,
        }"
      >
        <BaseLink
          class="topbar-menu-link"
          :to="{ name: menuItem.name }"
          active-class="active"
          data-parent=""
        >
          {{ menuItem.title }}
        </BaseLink>
      </li>
    </template>
  </BaseTopbarNavMenu>
</template>

<style lang="scss">
.topbar-menu-link {
  text-decoration: none;
  color: $color-black;

  &:active,
  &:hover,
  &.active {
    color: $color-black;
  }
}
</style>
