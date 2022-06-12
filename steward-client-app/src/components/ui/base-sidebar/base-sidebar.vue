<script lang="ts" setup>
import type { Ref } from 'vue'; 
import useLayout from '../../../composables/layout.composable'


const props = defineProps<{
    isFullLayout?: Boolean
}>();


const isMinimized = ref(false);

const emit = defineEmits<{
    (e: 'sidebar:toggled', value: boolean): void
}>()

const classes = {
    bodySidebarContentLayout: "sidebar-content-layout",
    bodySidebarFullLayout: "sidebar-full-layout",
    bodySidebarMinimized: "sidebar-minimized",
}

const layoutComposable = useLayout();

watch(isMinimized, (currentValue, oldValue) => {    
    if (currentValue) {
        layoutComposable.addClass(classes.bodySidebarMinimized);
    }
    else{
        layoutComposable.removeClass(classes.bodySidebarMinimized);
    }   
});

onMounted(() => {
    if (props.isFullLayout){
        layoutComposable.addClass(classes.bodySidebarFullLayout);
    }
    else {
        layoutComposable.addClass(classes.bodySidebarContentLayout);
    }
});

onUnmounted(() => {
    layoutComposable.removeClass(classes.bodySidebarMinimized);
    layoutComposable.removeClass(classes.bodySidebarFullLayout);
    layoutComposable.removeClass(classes.bodySidebarContentLayout);
})

function toggleSidebar() { 

    isMinimized.value = !isMinimized.value 

    emit("sidebar:toggled", isMinimized.value);
    return unref(isMinimized);
}

defineExpose({
    toggleSidebar,
    
})

</script>

<template>
    <div class="sidebar" :class="{
        minimized: isMinimized
    }">
        <div class="sidebar-brand" v-show="isFullLayout">
            <slot name="sidebar-brand" ></slot>
        </div>
        <div class="sidebar-menu-wrapper">
            <div class="sidebar-menu">
                <slot></slot>

                
            </div>
        </div>
    </div>
</template>

<style lang="scss">
@import '../../../assets/scss/variables';
@import '../../../../node_modules/bootstrap/scss/bootstrap-utilities.scss';
@import '../../../assets/scss/util/root-util';
@import '../../../assets/scss/scrollbar';

.sidebar-brand {
    height: user_root_var('topbar-height');
}

.sidebar-minimized {
    .sidebar {
        width: $sidebar-minimized-width;
    }
}

.sidebar-full-layout {

    .sidebar {
        top: 0;
        bottom: 0;
        left: 0;    
        position: fixed;  
    }
     
}

.sidebar {
    width: $sidebar-open-width;
    background: user_root_var('sidebar-bg');
    position: absolute;
   
    top: unset;
    bottom: unset;
    left: unset;

    // z-index: 98;
    transition: $layout-transition;             
}

.sidebar-menu {
    overflow-y: auto;
    overflow-x: hidden;
    height: calc(100vh - #{user_root_var('topbar-height')} - (#{$sidebar-menu-y-margin} * 2) );
    margin: $sidebar-menu-y-margin 0;    

        @include mix-scrollbar(
            $thumb-color: rgba(100, 100, 100, 1),
            $thumb-color-hidden: rgba(100, 100, 100, 0),
            $thumb-color-hover: rgb(46, 46, 46),
            $thumb-size: 8px,
            $track-color: user_root_var('sidebar-bg')
        );
}

@include media-breakpoint-up(sm) {

    .sidebar-full-layout {
        .topbar {
            &:not(.top-header) {
                left: $sidebar-open-width;
                // z-index: 97;
            }
        }

        &.sidebar-minimized {
            .content-wrapper {
                margin-left: $sidebar-minimized-width;
            }

            .topbar:not(.topbar-header) {
                left: $sidebar-minimized-width;
            }
        }

        .content-wrapper {
            margin-left: $sidebar-open-width;
        }

    }

    .sidebar-content-layout {

        .content {
            margin-left: $sidebar-open-width;
        }

        &.sidebar-minimized {
            .content {
                margin-left: $sidebar-minimized-width;
            }
        }

    }
}


</style>