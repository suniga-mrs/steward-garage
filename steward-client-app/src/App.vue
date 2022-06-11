<script setup lang="ts">
import type { Ref } from 'vue';


const AppWrapper = ref<HTMLElement | undefined>();

//provide('AppWrapper', () : Ref<HTMLElement> => document.getElementById("app-wrapper"));
provide('AppWrapper', (): HTMLElement | undefined => AppWrapper.value);

</script>

<template>
  <div class="layout-wrapper d-flex flex-row flex-column-fluid " id="app-wrapper" ref="AppWrapper">

    <NavSidebar class="d-flex flex-column"></NavSidebar>

    <div class="d-flex flex-column content-wrapper">

      <!-- <BaseTopbar></BaseTopbar> -->

      <div class="content">
        <RouterView />
      </div>

    </div>
  </div>
</template>

<style lang="scss">
@import "../node_modules/bootstrap/dist/css/bootstrap.css";

body {
  overflow-y: hidden;
}

.layout-wrapper {
  flex: 1 0 auto;
}

.sidebar-minimized .content-wrapper {
    margin-left: $sidebar-minimized-width;
}

.content-wrapper {
  margin-left: $sidebar-open-width;
  flex: 1 auto;
  transition: $layout-transition;
  // padding-top: $topbar-height;

  background: aqua;
  
  .content {
    overflow-y: auto;
    height: 100vh;
  }

 
}



</style>
