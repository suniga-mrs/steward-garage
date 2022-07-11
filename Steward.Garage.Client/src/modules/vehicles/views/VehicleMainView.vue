<script lang="ts" setup>
import { useNavigationMenu } from '../../../composables/navmenu.composable.';

//Pass data to a state management
const { setCurrentParentNavMenu, setCurrentChildrenNavMenu } =
  useNavigationMenu();

onMounted(() => {
  setCurrentParentNavMenu('vehicles');
  setCurrentChildrenNavMenu('vehicle');
});

onUnmounted(() => {
  // console.log($route.)
  // console.log('Main view mounted')

  setCurrentParentNavMenu(null);
});
</script>

<template>
  <router-view></router-view>
</template>
