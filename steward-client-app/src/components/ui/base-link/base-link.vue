//https://vueschool.io/articles/vuejs-tutorials/extending-vue-router-links-in-vue-3/
<script lang="ts" setup>
import { RouterLink } from 'vue-router';
import type { RouterLinkProps } from 'vue-router';

export interface IBaselinkProps extends RouterLinkProps {}

const props = defineProps<IBaselinkProps>();

const isExternal = computed(() => {
  return typeof props.to === 'string' && props.to.startsWith('http');
});

const stringHref = computed(() => {
  return typeof props.to === 'string' ? props.to : '';
});
</script>

<template>
  <a v-if="isExternal" v-bind="$attrs" :href="stringHref" rel="noopener">
    <slot />
  </a>
  <RouterLink v-else v-bind="$props">
    <slot />
  </RouterLink>
</template>

<style scoped>
a {
  cursor: pointer;
}
</style>
