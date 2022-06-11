import { useBreakpoints } from '@vueuse/core'

const breakpoints = useBreakpoints({
    xs: 0,
    sm: 576,
    md: 768,
    lg: 992,
    xl: 1200,
    xxl: 1400
})

export const isSM = ref(breakpoints.smaller('md'));
export const isMD = ref(breakpoints.between('md', 'lg'));
export const isLG = ref(breakpoints.between('lg', 'xl'));
export const isXL = ref(breakpoints.between('xl', 'xxl'));
export const isXXL = ref(breakpoints.greater('xxl'));

export default breakpoints