<script lang="ts" setup>
import { useRoute, RouterLink } from "vue-router";
import type { TDatatableOptions } from "../../../components/ui/base-datatable/datatable";
const $route = useRoute();

const dtOptions: TDatatableOptions = {
  data: {
    type: "remote",
    source: {
      url: "/api/vehicles",
      params: {},
      mapApiReponse(rawData) {
        return {
          data: rawData.data,
          pagination: rawData.pagination,
        };
      },
      pagingMap(page, perPage) {
        return {
          page,
          perPage,
        };
      },
    },
  },
  scrollable: true,
  pagination: true,
  layout: {
    height: "275px",
    minHeight: "275px",
    pagination: {
      pageSize: 10,
      pageButtonsNumber: 5,
    },
  },
  columns: [
    {
      field: "vehicleId",
      title: "Id",
    },
    {
      field: "make",
      title: "Make",
    },
    {
      field: "model",
      title: "Model",
    },
    {
      field: "year",
      title: "Year",
    },
    {
      field: "plateNo",
      title: "Plate No.",
    },
    {
      field: "chassisNo",
      title: "Chassis No.",
    },
    {
      field: "engineNo",
      title: "Engine No.",
    },
  ],
};

//Pass data to a state management
</script>
<template>
  <div class="container">
    <BaseDatatable :options="dtOptions"></BaseDatatable>
    <!-- Vehicles List
    <RouterLink :to="{ name: 'vehicle-profile', params: { plateNo: 'sdsd' } }"
      >LINK</RouterLink
    > -->
  </div>
</template>
