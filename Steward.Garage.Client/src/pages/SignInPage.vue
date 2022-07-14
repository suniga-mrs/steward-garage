<script lang="ts" setup></script>

<template>
  <div class="wrapper">
    <div class="inner-wrapper">Inner</div>
  </div>

  <!-- <div id="box" ref="elBox" class=" mb-4">Hello</div> -->
</template>

<style lang="scss" scoped>
#box {
  height: 100px;
  width: 100px;
  resize: both;
  background-color: antiquewhite;
  overflow: auto;
}
.wrapper {
  // margin-top: 100px;
  height: 100vh;
  width: 100vw;
  background-color: aquamarine;
  display: flex;
  align-items: center;

  .inner-wrapper {
    margin: 0 auto;
    height: 600px;
    width: 300px;
    background-color: bisque;
  }
}
</style>
