<script lang="ts" setup>
import { useNavigationMenu } from '../../../composables/navmenu.composable.'

const { getRouteByPlacement } = useNavigationMenu();

const topbarMenu = getRouteByPlacement('topbar');

</script>

<template>
    <BaseTopbarNavMenu :menu="topbarMenu" >
        <template #navMenuItem="{ menuItem }">
            <BaseLink class="topbar-menu-link" :to="{ name: menuItem.name }">{{ menuItem.title }}</BaseLink>
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