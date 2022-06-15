<script lang="ts" setup>
import { useNavigationMenu } from '../../../composables/navmenu.composable.'

const { mainMenu, setCurrentNavMenu } = useNavigationMenu();

</script>

<template>
    <BaseTopbarNavMenu :menu="mainMenu" @navigate="setCurrentNavMenu" />
</template>