<template>
    <div class="brand-logo">
        <h1>STWRD</h1>
        <h3>GARAGE</h3>
    </div>
</template>

<style lang="scss" scoped>


@import "../../../assets/scss/variables";
@import "../../../../node_modules/bootstrap/scss/bootstrap-utilities.scss";
@import "../../../assets/scss/fonts";

.brand-logo {
    font-family: $font-family-alt;
    color: $color-black;
    width: 100%;
    padding-left: 1.5em;
    font-size: 0.9em;

    h1 {
        font-size: 1.6em;
        font-weight: 700;
        font-style: italic;
        letter-spacing: -1px;
        margin:0;
    }
    h3 {
        font-weight: 400;
        font-size: 1em;
        letter-spacing: 3px;
        margin: 0;
    }
}


@include media-breakpoint-up(sm) {
    .brand-logo {
        padding: 0;
        text-align: center;
        font-size: 1em;
    }
}
</style>