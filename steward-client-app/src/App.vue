<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import BaseSidebar from './components/ui/base-sidebar/base-sidebar.vue'
import BaseTopbar from './components/ui/base-topbar/base-topbar.vue'

</script>

<template>


  <div class="layout-wrapper d-flex flex-row flex-column-fluid ">
    <BaseSidebar class="d-flex flex-column"></BaseSidebar>
    <div class="d-flex flex-column content-wrapper">

      <BaseTopbar></BaseTopbar>

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
