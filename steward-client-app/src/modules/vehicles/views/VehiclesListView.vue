<script lang="ts" setup>
import { useRoute, RouterLink } from 'vue-router';
const $route = useRoute();

//Pass data to a state management
</script>
<template>
  <div>
    Vehicles List
    <RouterLink :to="{ name: 'vehicle-profile', params: { plateNo: 'sdsd' } }"
      >LINK</RouterLink
    >
  </div>
</template>
