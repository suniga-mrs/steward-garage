<script lang="ts" setup>
import type { ComputedRef, Ref } from 'vue'
import { isSM } from '../../../utilities/breakpoint.util'
import type { INavigationItem } from '../../../ts/navigation'

const props = defineProps<{
    menu: Array<INavigationItem>
}>();


</script>

<template>
    <nav class="topbar-nav-menu" v-show="!isSM">
        <ul class="topbar-nav-menu-list">
            <slot name="navMenuItem" :menu="menu"></slot>        
        </ul>
    </nav>
</template>

<style lang="scss">





@import '../../../assets/scss/variables';

@mixin topbar-menu-link-active-style {
    color: $color-black;

    &::after {
        background-color: $color-black;
    }
}


@include media-breakpoint-up(sm) {



    .topbar-nav-menu {
        height: 100%;

        >.topbar-nav-menu-list {
            list-style: none;
            padding: 0;
            margin: 0;
            height: 100%;
            display: flex;

            > li {               
                margin: 0 0.5em;               
                position: relative;

                > a,
                > .topbar-menu-link {
                    cursor: pointer;
                    height: 100%;
                    padding: 0 1em;                       
                    font-size: 0.95em;
                    letter-spacing: 1px;
                    font-weight: 600;
                    display: flex;
                    align-items: center;

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
                        @include topbar-menu-link-active-style;
                    }
                }
            
                &.parent-active {
                    > a,
                    > .topbar-menu-link {
                        @include topbar-menu-link-active-style;
                    }
                }

            }
        }
    }
}


</style>