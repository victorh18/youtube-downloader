<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      light
      class="d-flex justify-center"
    >
      <v-app-bar-title class="font-weight-bold">Descargador de YouTube</v-app-bar-title>
    </v-app-bar>

    <v-main class="pa-2">
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
