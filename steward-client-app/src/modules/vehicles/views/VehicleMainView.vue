<script lang="ts" setup>
import { useNavigationMenu } from '../../../composables/navmenu.composable.';

//Pass data to a state management
const { setCurrentParentNavMenu } = useNavigationMenu();

onMounted(() => { 
    // console.log($route.)
    // console.log('Main view mounted')
    
    setCurrentParentNavMenu('vehicle');

})
</script>

<template>
    <router-view></router-view>
</template>
