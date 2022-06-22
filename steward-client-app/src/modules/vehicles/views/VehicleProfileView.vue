<script lang="ts" setup>
import { useRoute } from "vue-router";
const $route = useRoute();

//Pass data to a state management
console.log($route.name);
onUpdated(() => {});
</script>

<template>Vehicle Profile</template>
