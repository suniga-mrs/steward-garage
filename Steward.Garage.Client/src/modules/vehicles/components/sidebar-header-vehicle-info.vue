<script lang="ts" setup>
import { useVehicleStore } from "../vehicle.store";
const storeVehicle = useVehicleStore();
</script>

<template>
  <div class="vehicle-sidebar-header">
    <picture class="vehicle-img">
      <!-- <source media="(max-width: 799px)" srcset="elva-480w-close-portrait.jpg">
  <source media="(min-width: 800px)" srcset="elva-800w.jpg"> -->
      <img src="https://via.placeholder.com/80" alt="Profile" />
    </picture>
    <div class="vehicle-info">
      <p class="vehicle-info-item vehicle-info-make">{{ storeVehicle.vehicle?.make }}</p>
      <p class="vehicle-info-item vehicle-info-model-year">
        {{
          storeVehicle.vehicle?.year != 0 && storeVehicle.vehicle?.model != ""
            ? `${storeVehicle.vehicle?.model} | ${storeVehicle.vehicle?.year} `
            : ""
        }}
      </p>
      <p class="vehicle-info-item vehicle-info-plateno">
        {{ storeVehicle.vehicle?.plateNo }}
      </p>
    </div>
  </div>
</template>

<style lang="scss">
.vehicle-sidebar-header {
  height: 80px;
  border-style: solid;
  border-width: 2px;
  border-color: $content-bg;
  border-right-color: transparent;
  border-radius: 20px 0 0 20px;
  padding: 5px;
  display: flex;

  .vehicle-img {
    height: 66px;
    width: 66px;
    overflow: hidden;
    border-radius: 14px;

    img {
      height: 100%;
      width: auto;
    }
  }

  .vehicle-info {
    padding: 0 8px;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;

    .vehicle-info-item {
      margin: 0;
      font-size: 0.7rem;
    }

    .vehicle-info-make,
    .vehicle-info-model-year {
      font-weight: 600;
    }

    .vehicle-info-plateno {
      font-size: 0.6rem;
      text-transform: uppercase;
    }
  }
}
</style>
