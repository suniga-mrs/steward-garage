<script lang="ts" setup>

const AppWrapper = inject<Function>("AppWrapper");


onMounted(() => {
    AppWrapper?.()?.classList.add('layout-topbar')
 })


onUnmounted(() => {
    AppWrapper?.()?.classList.remove('layout-topbar')
})

</script>


<template>
    <div class="topbar">

        <select>
            <option value="TEST">TEST</option>
        </select>

    </div>
</template>

<style lang="scss">



.sidebar-minimized .topbar {
    left: $sidebar-minimized-width;
}

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

    left: $sidebar-open-width;
        z-index: 97;


}

</style>