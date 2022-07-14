<script lang="ts" setup>
import { h } from "vue";
import { useNavigationMenu } from "../../../composables/navmenu.composable.";
import { useVehicleStore } from "../vehicle.store";
import { useRoute } from "vue-router";
import SidebarHeaderVehicleInfo from "../components/sidebar-header-vehicle-info.vue";

//Pass data to a state management
const {
  setCurrentParentNavMenu,
  setCurrentChildrenNavMenu,
  setSidebarHeaderComponent,
} = useNavigationMenu();

const route = useRoute();
const storeVehicle = useVehicleStore();
const vehicleProfile = storeVehicle.currentVehicle;

storeVehicle.init((route.params?.plateNo as string) ?? "");

const sidebarHeader = SidebarHeaderVehicleInfo;

setSidebarHeaderComponent(sidebarHeader);

onMounted(() => {
  setCurrentParentNavMenu("vehicles");
  setCurrentChildrenNavMenu("vehicle");
});

onUnmounted(() => {
  setCurrentParentNavMenu(null);
  setSidebarHeaderComponent(null);
});
</script>

<template>
  <router-view></router-view>
</template>
