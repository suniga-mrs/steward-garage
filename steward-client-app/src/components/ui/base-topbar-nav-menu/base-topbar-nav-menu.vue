<script lang="ts" setup>
import type { ComputedRef, Ref } from 'vue'
import { isSM } from '../../../utilities/breakpoint.util'
import type { INavigationItem } from '../../../ts/navigation'

const props = defineProps<{
    menu: Array<INavigationItem>
}>();

// type-based
const emit = defineEmits<{
    (e: 'navigate', menuItem: INavigationItem): void
}>()

function navigateToMenuItemRoute(item: INavigationItem) {
    emit('navigate', item)
}

</script>

<template>
    <nav class="topbar-nav-menu" v-show="!isSM">
        <ul class="topbar-nav-menu-list">
            <li tabindex="1" v-for="(item, index) in menu" :key="item.route" @click="">
            <!-- {{item.title}} -->
                <BaseLink :to="{ name: item.name }" @click="navigateToMenuItemRoute(item)">{{ item.title }}</BaseLink>
            </li>
        </ul>
    </nav>
</template>

<style lang="scss">




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

            > li {               
                margin: 0 0.5em;
               
                position: relative;

                > a {
                    cursor: pointer;
                    height: 100%;
                    padding: 0 1em;                       
                    font-size: 0.95em;
                    letter-spacing: 1px;
                    font-weight: 600;
                    display: flex;
                    align-items: center;
                }


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