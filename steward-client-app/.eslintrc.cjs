/* eslint-env node */
require('@rushstack/eslint-patch/modern-module-resolution');

module.exports = {
  root: true,
  extends: [
    'plugin:vue/vue3-essential',
    'plugin:vue/vue3-recommended',
    'plugin:vue/vue3-strongly-recommended',
    'eslint:recommended',
    '@vue/eslint-config-typescript/recommended',
    '@vue/eslint-config-prettier',
    // "plugin:storybook/recommended",
  ],
  env: {
    'vue/setup-compiler-macros': true,
    browser: true,
    amd: true,
    node: true,
  },
  rules: {
    'prettier/prettier': [
      'warn',
      {
        singleQuote: true,
        tabWidth: 2,
        useTabs: false,
        endOfLine: 'auto',
      },
    ],
    'import/named': 'off',
    // TS
    '@typescript-eslint/ban-ts-comment': [
      'error',
      {
        'ts-ignore': 'allow-with-description',
      },
    ],
    '@typescript-eslint/member-delimiter-style': [
      'error',
      {
        multiline: {
          delimiter: 'semi',
        },
      },
    ],
    '@typescript-eslint/type-annotation-spacing': ['error', {}],
    '@typescript-eslint/consistent-type-imports': [
      'error',
      {
        prefer: 'type-imports',
        disallowTypeAnnotations: false,
      },
    ],
    '@typescript-eslint/consistent-type-definitions': ['error', 'interface'],
    '@typescript-eslint/consistent-indexed-object-style': ['error', 'record'],
    '@typescript-eslint/prefer-ts-expect-error': 'error',
    // Override JS
    'no-useless-constructor': 'off',
    indent: ['warn', 2],
    '@typescript-eslint/indent': ['warn', 2],
    'no-unused-vars': 'off',
    '@typescript-eslint/no-unused-vars': [
      'error',
      {
        argsIgnorePattern: '^_',
      },
    ],
    'no-redeclare': 'off',
    '@typescript-eslint/no-redeclare': 'error',
    'no-use-before-define': 'off',
    '@typescript-eslint/no-use-before-define': [
      'error',
      {
        functions: false,
        classes: false,
        variables: true,
      },
    ],
    'brace-style': 'off',
    '@typescript-eslint/brace-style': [
      'error',
      'stroustrup',
      {
        allowSingleLine: true,
      },
    ],
    'comma-dangle': 'off',
    '@typescript-eslint/comma-dangle': ['warning', 'always-multiline'],
    'object-curly-spacing': 'off',
    '@typescript-eslint/object-curly-spacing': ['error', 'always'],
    semi: ['error', 'always'],
    '@typescript-eslint/semi': ['error', 'always'],
    quotes: ['error', 'single'],
    '@typescript-eslint/quotes': ['error', 'single'],
    'space-before-blocks': 'off',
    '@typescript-eslint/space-before-blocks': ['error', 'always'],
    'space-before-function-paren': 'off',
    '@typescript-eslint/space-before-function-paren': [
      'error',
      {
        anonymous: 'always',
        named: 'never',
        asyncArrow: 'always',
      },
    ],
    'space-infix-ops': 'off',
    '@typescript-eslint/space-infix-ops': 'error',
    'keyword-spacing': 'off',
    '@typescript-eslint/keyword-spacing': [
      'error',
      {
        before: true,
        after: true,
      },
    ],
    'comma-spacing': 'off',
    '@typescript-eslint/comma-spacing': [
      'error',
      {
        before: false,
        after: true,
      },
    ],
    'no-extra-parens': 'off',
    '@typescript-eslint/no-extra-parens': ['error', 'functions'],
    'no-dupe-class-members': 'off',
    '@typescript-eslint/no-dupe-class-members': 'error',
    'no-loss-of-precision': 'off',
    '@typescript-eslint/no-loss-of-precision': 'error',
    'lines-between-class-members': 'off',
    '@typescript-eslint/lines-between-class-members': [
      'error',
      'always',
      {
        exceptAfterSingleLine: true,
      },
    ],
    // The following rule overrides require a parser service, aka. require a `typescript.json` path.
    // This needs to be done individually for each project, and it slows down linting significantly.
    // 'no-throw-literal': 'off',
    // '@typescript-eslint/no-throw-literal': 'error',
    // 'no-implied-eval': 'off',
    // '@typescript-eslint/no-implied-eval': 'error',
    // 'dot-notation': 'off',
    // '@typescript-eslint/dot-notation': ['error', { allowKeywords: true }],
    // off
    '@typescript-eslint/naming-convention': 'off',
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/explicit-member-accessibility': 'off',
    '@typescript-eslint/no-explicit-any': 'off',
    '@typescript-eslint/parameter-properties': 'off',
    '@typescript-eslint/no-empty-interface': 'off',
    '@typescript-eslint/ban-ts-ignore': 'off',
    '@typescript-eslint/no-empty-function': 'off',
    '@typescript-eslint/no-non-null-assertion': 'off',
    '@typescript-eslint/explicit-module-boundary-types': 'off',
    '@typescript-eslint/ban-types': 'off',
    '@typescript-eslint/no-namespace': 'off',
    '@typescript-eslint/triple-slash-reference': 'off',
  },
};
