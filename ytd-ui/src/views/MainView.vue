<template>
  <v-content>
    <v-container style="border: black 0px solid; height: 70vh">
      <v-flex style="height: 100%" class="pa-3">
        <p class="my-0">Link del vídeo:</p>
        <v-text-field v-model="url" solo dense @paste="getVideoMetadata" />
        <video-part :embeddedUrl="embeddedUrl" v-if="url"/>
      </v-flex>
    </v-container>
  </v-content>
</template>

<script>
import VideoPart from "../components/VideoPart.vue";
import * as AppMutations from '../store/app/app-mutations'
import MetadataService from '../services/MetadataService'

export default {
  components: {
    VideoPart
  },
  computed: {
    embeddedUrl() {
      return this.$store.getters.embeddedUrl;
    },
    url: {
      get () {
        return this.$store.state.app.url;
      },
      set (value) {
        this.$store.commit(AppMutations.UPDATE_URL, { url: value })
      }
    }
  },
  methods: {
    getVideoMetadata(e) {
      var clipboardData, pastedData;
      clipboardData = e.clipboardData || window.clipboardData;
      pastedData = clipboardData.getData("Text");

      MetadataService.getVideoId(pastedData).then(id => this.id = id);
    },
    
  },
};
</script>

<style>
</style>
