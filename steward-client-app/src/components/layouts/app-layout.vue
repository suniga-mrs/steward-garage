<script lang="ts" setup> 
import { useRoute } from 'vue-router';
import useLayout from '../../composables/layout.composable'

const $route = useRoute();
const layout = computed(() => {
    return $route.meta.layout
})

const layoutComposable = useLayout();
const wrapperClasses = layoutComposable.classes;

</script>

<template>
    <component :is="layout || 'div'" :class="wrapperClasses">
        <slot></slot>
    </component>
</template>


<style lang="scss">
@import "../../assets/scss/_root.scss";
@import "../../assets/scss/_layout.scss";
</style>