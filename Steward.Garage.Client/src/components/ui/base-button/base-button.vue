<script lang="ts" setup>
export type TButtonType = "outline" | "soft" | "ghost" | "link";
export type TButtonSize = "sm" | "lg";
export type TColorTheme =
  | "primary"
  | "accent"
  | "secondary"
  | "success"
  | "danger"
  | "warning"
  | "info"
  | "dark"
  | "light";

export type TColorGradient = "primary" | "accent";

export type TButtonModifier = "pill" | "elevate" | "shadow";

const props = defineProps<{
  // label: string;
  type?: TButtonType;
  size?: TButtonSize;
  theme?: TColorTheme;
  //   gradient?: TColorGradient;
  modifiers?: TButtonModifier[];
  icon?: boolean;
}>();

const classArray = computed(() => {
  let base = ["btn"];

  //TYPE CLASS
  if (props?.type != undefined && props?.theme != undefined) {
    base.push(`btn-${props.type}-${props.theme}`);
  } else {
    //THEME CLASS
    if (props?.theme != undefined) {
      base.push(`btn-${props.theme}`);
    }
  }

  //SIZE CLASS
  if (props?.size != undefined) {
    base.push(`btn-${props.size}`);
  }

  if (props?.modifiers != undefined) {
    props.modifiers.map((modifier) => {
      base.push(`btn-${modifier}`);
    });
  }

  //   if (props?.gradient != undefined) {
  //     base.push(`btn-gradient-${props.gradient}`);
  //   }

  //ICON CLASS
  if (props?.icon != undefined && props.icon == true) {
    base.push("btn-icon");
  }

  return base;
});
</script>

<template>
  <button :class="classArray" type="button">
    <slot></slot>
  </button>
</template>

<style lang="scss">
@import "../../../../node_modules/bootstrap/scss/buttons";

@mixin btn_box_shadow($color) {
  box-shadow: 0 4px 11px rgba($color, 0.35);
}

@mixin btn_gradients_variant($background) {
  background: $background;
}

.btn {
  .disabled,
  :disabled {
    pointer-events: none !important;
    cursor: not-allowed;
  }
}

.btn-pill {
  border-radius: 50rem !important;
}

.btn-icon {
  height: calc(1.5em + 0.722rem + 2px);
  width: calc(1.5em + 0.722rem + 2px);
  position: relative;
  svg {
    // height: 50pxz;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
  }
  // width: calc(1.5em + 0.722rem + 5px);

  &.btn-lg {
    height: calc(1.5em + 0.972rem + 2px);
    width: calc(1.5em + 0.972rem + 2px);
  }
  &.btn-sm {
    height: calc(1.5em + 0.472rem + 2px);
    width: calc(1.5em + 0.472rem + 2px);
  }
}

// scss-docs-start btn-variant-loops
@each $color, $value in $theme-colors {
  // @debug $color;

  .btn-#{$color} {
    @include button-variant(
      $background: $value,
      $border: $value,
      $color: get_inverse_black_or_white($value),
      $hover-color: get_inverse_black_or_white($value),
      $active-color: get_inverse_black_or_white($value)
    );

    &.btn-shadow {
      @include btn_box_shadow($value);
    }

    &.active,
    &:active,
    &:hover,
    &:focus {
      border-color: transparent;
    }

    &:hover {
      @include btn_box_shadow($value);
    }

    &.btn-elevate {
      @include btn_box_shadow($value);
    }
  }

  .btn-outline-#{$color} {
    @include button-outline-variant(
      $value,
      $color-hover: get_inverse_black_or_white($value)
    );
  }

  .btn-ghost-#{$color} {
    background: rgba($color: $value, $alpha: 0);
    border-color: transparent;
    color: $value;

    &.active,
    &:active,
    &:hover,
    &:focus {
      border-color: transparent;
    }

    &:hover {
      color: $value;
      background: rgba($color: $value, $alpha: 0.25);
    }

    &.disabled,
    &:disabled {
      background: transparent;
      color: rgba($color: $value, $alpha: 0.4);
    }
  }

  .btn-soft-#{$color} {
    background: rgba($color: $value, $alpha: 0.25);
    border-color: transparent;
    color: $value;

    &.active,
    &:active,
    &:hover,
    &:focus {
      border-color: transparent;
    }

    &:hover {
      color: get_inverse_black_or_white($value);
      background: $value;
    }

    &.disabled,
    &:disabled {
      background: rgba($color: $value, $alpha: 0.4);
      color: $value;
    }
  }
}
</style>
