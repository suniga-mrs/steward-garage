<script lang="ts" setup>
import { useRoute, useRouter, RouterLink } from "vue-router";
import type { TDatatableOptions } from "../../../components/ui/base-datatable/datatable";

const $router = useRouter();

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
    height: "480px",
    minHeight: "480px",
    pagination: {
      pageSize: 20,
      pageButtonsNumber: 5,
    },
  },
  columns: [
    {
      field: "options",
      title: "Options",
      width: "80px",
    },
    // {
    //   field: "vehicleId",
    //   title: "Id",
    //   width: "70px",
    //   template(row) {
    //     return "#" + row.vehicleId;
    //   },
    // },
    {
      field: "make",
      title: "Make",
      width: "160px",
      template(row) {
        return row.make.toUpperCase();
      },
    },
    {
      field: "model",
      title: "Model",
      width: "160px",
      template(row) {
        return row.model.toUpperCase();
      },
    },
    {
      field: "year",
      title: "Year",
      width: "100px",
    },
    {
      field: "plateNo",
      title: "Plate No.",
      width: "150px",
      template(row) {
        return row.plateNo.toUpperCase();
      },
    },
    {
      field: "chassisNo",
      title: "Chassis No.",
      width: "250px",
    },
    {
      field: "engineNo",
      title: "Engine No.",
      width: "250px",
    },
  ],
};

const goToView = (data: any) => {
  $router.push({
    name: "vehicle-profile",
    params: {
      plateNo: data.plateNo.toUpperCase(),
    },
  });
};
</script>
<template>
  <div class="container">
    <CardContainer>
      <BaseDatatable :options="dtOptions">
        <template #body-cell-options="{ rowData }">
          <BaseButton theme="primary" size="sm" @click="goToView(rowData)">
            View
          </BaseButton>
        </template>
      </BaseDatatable>
    </CardContainer>

    <!-- Vehicles List
    <RouterLink :to="{ name: 'vehicle-profile', params: { plateNo: 'sdsd' } }"
      >LINK</RouterLink
    > -->
  </div>
</template>
