<script lang="ts" setup>
defineProps<{
  title?: string;
}>();
</script>

<template>
  <BaseCard>
    <BaseCardBody>
      <BaseCardTitle v-if="title != undefined">{{ title }}</BaseCardTitle>
      <slot></slot>
    </BaseCardBody>
  </BaseCard>
</template>
