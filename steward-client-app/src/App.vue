<script setup lang="ts">
import type { Ref, InjectionKey } from 'vue';
import { isSM } from './utilities/breakpoint.util'
import useLayout from './composables/layout.composable'

const AppWrapper = ref<HTMLElement | undefined>();
const layoutComposable = useLayout();

//provide('AppWrapper', () : Ref<HTMLElement> => document.getElementById("app-wrapper"));
// provide('AppWrapper', (): HTMLElement | undefined => AppWrapper.value);


const wrapperClasses = layoutComposable.classes;

</script>

<template>
  <div ref="AppWrapper" :class="wrapperClasses">
    <!-- <LayoutDefault></LayoutDefault> -->

    <LayoutTopHeader></LayoutTopHeader>
  </div>

</template>

<style lang="scss">
@import "../node_modules/bootstrap/dist/css/bootstrap.css";
@import "./assets/scss/_layout.scss";

</style>
