<script lang="ts" setup>
import { useRoute } from 'vue-router';
const $route = useRoute();

//Pass data to a state management
console.log($route.name)
onUpdated(() => {
  
})

</script>

<template>
    Vehicle Profile
    <RouterLink :to="{ name:'vehicle-create' }">LINK</RouterLink>
    <RouterLink :to="{ name:'vehicle-gas-logs' }">GAS</RouterLink>
</template>