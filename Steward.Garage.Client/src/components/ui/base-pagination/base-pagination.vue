<script lang="ts" setup>
import { computed } from "vue";

export type TPaginationPlaceholders = {
  first: string;
  prev: string;
  next: string;
  last: string;
};

const props = defineProps<{
  page: number;
  pages: number;
  perPage: number;
  pageNumbers: number;
  total: number;
  textPlaceholders: TPaginationPlaceholders;
  size?: "sm" | "lg";
}>();

const pageButtonNumbers = computed(() => {
  let endPageNumber = Math.ceil(props.page / props.pageNumbers) * props.pageNumbers;
  let startPageNumber = endPageNumber - props.pageNumbers;

  if (endPageNumber > props.pages) {
    endPageNumber = props.pages;
  }
  if (startPageNumber < 0) {
    startPageNumber = 0;
  }

  const pageButtonNumbers = [];
  for (let x = startPageNumber; x < (endPageNumber || 1); x++) {
    const pageNumber = x + 1;
    pageButtonNumbers.push(pageNumber);
  }

  return pageButtonNumbers;
});

const emits = defineEmits(["goToPage"]);
function goToPage(page: number) {
  emits("goToPage", page);
}
</script>

<template>
  <div aria-label="Page navigation">
    <ul class="pagination" :class="`pagination-${size}`">
      <!-- ---------- First Button ---------- -->
      <li class="page-item">
        <button class="page-link" :disabled="page <= 1" @click="goToPage(1)">
          <slot name="first-btn">
            {{ textPlaceholders.first }}
          </slot>
        </button>
      </li>

      <!-- ---------- Prev Button ---------- -->
      <li class="page-item">
        <button class="page-link" :disabled="page <= 1" @click="goToPage(page - 1)">
          <slot name="prev-btn">
            {{ textPlaceholders.prev }}
          </slot>
        </button>
      </li>

      <!-- ---------- Page Button Numbers ---------- -->
      <li class="page-item">
        <button
          v-for="itemPage in pageButtonNumbers"
          :key="itemPage"
          class="page-link d-inline"
          :class="{
            active: page == itemPage,
          }"
          @click="goToPage(itemPage)"
        >
          {{ itemPage }}
        </button>
      </li>

      <!-- ---------- Next Button ---------- -->
      <li class="page-item">
        <button class="page-link" :disabled="page >= pages" @click="goToPage(page + 1)">
          <slot name="next-btn">
            {{ textPlaceholders.next }}
          </slot>
        </button>
      </li>

      <!-- ---------- Last Button ---------- -->
      <li class="page-item">
        <button class="page-link" :disabled="page >= pages" @click="goToPage(pages)">
          <slot name="last-btn">
            {{ textPlaceholders.last }}
          </slot>
        </button>
      </li>
    </ul>
  </div>
</template>

<style lang="scss"></style>
