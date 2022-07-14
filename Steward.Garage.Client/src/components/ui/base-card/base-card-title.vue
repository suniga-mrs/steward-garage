<script lang="ts" setup>
withDefaults(
  defineProps<{
    tag?: "h1" | "h2" | "h3" | "h4" | "h5" | "h6";
  }>(),
  {
    tag: "h5",
  }
);
</script>

<template>
  <component :is="tag" class="card-title"><slot></slot></component>
</template>
