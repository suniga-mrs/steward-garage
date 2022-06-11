<script lang="ts" setup>
import type { Ref } from 'vue'; 

const isMinimized = ref(false);

const emit = defineEmits<{
    (e: 'sidebar:toggled', value: boolean): void
}>()

const classes = {
    bodySideBarMinimized: "sidebar-minimized",
}

const AppWrapper = inject<Function>("AppWrapper");

watch(isMinimized, (currentValue, oldValue) => {
    
    if (currentValue) {
        AppWrapper?.()?.classList.add(classes.bodySideBarMinimized);
    }
    else{
        AppWrapper?.()?.classList.remove(classes.bodySideBarMinimized);
    }

});

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
        <div class="sidebar-brand">
            <slot name="sidebar-brand" ></slot>
        </div>
        <div class="sidebar-menu-wrapper">
            <div class="sidebar-menu">
                <slot></slot>

                
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>

.sidebar-brand {
    height: $topbar-height;
}

.sidebar-minimized .sidebar {
    width: $sidebar-minimized-width;  
}

.sidebar {
    width: $sidebar-open-width;
    background: red;

    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    z-index: 98;

    transition: $layout-transition;             
}


.sidebar-menu {
    overflow-y: auto;
    overflow-x: hidden;
    height: calc(100vh - #{$topbar-height} - (#{$sidebar-menu-y-margin} * 2) );
    margin: $sidebar-menu-y-margin 0;
}

</style>