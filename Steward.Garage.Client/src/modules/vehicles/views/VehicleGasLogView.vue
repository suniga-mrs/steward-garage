<script lang="ts" setup>
import { useRoute } from 'vue-router';
const $route = useRoute();

//Pass data to a state management
</script>

<template>
  <div>
    Vehicles Gas Log
    <RouterLink :to="{ name: 'vehicles' }">LINK</RouterLink>
  </div>
</template>
