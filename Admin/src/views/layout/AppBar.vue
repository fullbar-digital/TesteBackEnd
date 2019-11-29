<template>
  <v-app-bar :clipped-left="$vuetify.breakpoint.lgAndUp" app color="blue darken-3" dark>
    <v-toolbar-title style="width: 400px" class="ml-0 pl-4">
      <v-app-bar-nav-icon @click.stop="toggleNavigationBar"></v-app-bar-nav-icon>
      <span class="hidden-sm-and-down">Teste - FullBar</span>
    </v-toolbar-title>
    <div class="flex-grow-1"></div>
  </v-app-bar>
</template>
<script>
export default {
    methods: {
        toggleNavigationBar() {
            this.$emit('toggleNavigationBar');
        }
    }
}
</script>