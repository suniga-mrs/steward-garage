<script lang="ts" setup>
import useLayout from '../../../composables/layout.composable'

const layoutComposable = useLayout();

const props = defineProps<{
    isHeader?: Boolean
}>();


onMounted(() => {
    layoutComposable.addClass('layout-topbar')
})

onUnmounted(() => {
    layoutComposable.removeClass('layout-topbar')
})

</script>


<template>
    <div :class="{ 
        'topbar': true,
        'topbar-header': isHeader
    }">

        <div class="topbar-brand" v-show="isHeader">
            SHOW
            <slot name="topbar-brand"></slot>
        </div>

        <select>
            <option value="TEST">TEST</option>
        </select>

    </div>
</template>

<style lang="scss">



.layout-topbar {
    .content-wrapper {
        padding-top: $topbar-height;
        .content {
            height: calc(100vh - #{$topbar-height})
        }
    }            
}

.topbar {
    height: $topbar-height;
    background: pink;
    transition: $layout-transition;
    position: fixed;
    top: 0;
    right: 0;
    left: 0;   
    display: flex;
}

.topbar-brand {
    width: $topbar-brand-width;
}


</style>