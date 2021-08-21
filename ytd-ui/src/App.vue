<template>
  <v-app id="app">
    <v-app-bar
      app
      color="primary"
      class="d-flex justify-center"
    >
      <v-app-bar-title class="font-weight-bold">Descargador de YouTube</v-app-bar-title>
    </v-app-bar>

    <v-main class="pa-2" color="background">
      <main-view/>
    </v-main>
  </v-app>
</template>

<script>
//import HelloWorld from './components/HelloWorld';
import MainView from './views/MainView.vue';
// Just modified this
// Modified again
export default {
  name: 'App',

  components: {
    //HelloWorld,
    MainView
  },

  data: () => ({
    //
  }),
};
</script>

<style>
.theme--light.v-application {
  background-color: var(--v-background-base, white) !important;
}
</style>
