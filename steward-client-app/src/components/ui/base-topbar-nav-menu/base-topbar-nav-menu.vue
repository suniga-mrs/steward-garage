<script lang="ts" setup>
import { isSM } from '../../../utilities/breakpoint.util'
</script>

<template>
    <nav class="topbar-nav-menu" v-show="!isSM">
        <ul class="topbar-nav-menu-list">
            <li tabindex="1">Vehicles</li>
            <li tabindex="2">Driver</li>
            <li tabindex="3">References</li>
            <li tabindex="4">Fleet Operations</li>
        </ul>
    </nav>
</template>

<style lang="scss" scoped>





@import '../../../assets/scss/variables';



@include media-breakpoint-up(sm) {
    .topbar-nav-menu {
        height: 100%;

        >.topbar-nav-menu-list {
            list-style: none;
            padding: 0;
            margin: 0;
            height: 100%;
            display: flex;

            >li {
                padding: 0 1em;
                margin: 0 0.5em;
                font-size: 0.95em;
                letter-spacing: 1px;
                font-weight: 600;
                cursor: pointer;
                height: 100%;
                display: flex;
                align-items: center;
                position: relative;


                &::after {
                    content: '';
                    display: block;
                    width: 100%;
                    height: 5px;
                    background-color: transparent;
                    bottom: 0;
                    left: 0;
                    position: absolute;
                    transition: $base-transition;
                }

                //temp active
                &.active,
                &:hover,
                &:active,
                &:focus {
                    &::after {
                        background-color: $color-black;
                    }
                }
            }
        }
    }
}


</style>