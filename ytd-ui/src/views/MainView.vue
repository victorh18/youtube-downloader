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
import axios from "axios";
import VideoPart from "../components/VideoPart.vue";
import * as AppMutations from '../store/app/app-mutations'

export default {
  components: {
    VideoPart
  },
  data() {
    return {
      id: "",
      //url: "",
      dataType: "mp3",
      filenamePattern: "",
      waitingFile: false
    };
  },
  computed: {
    embeddedUrl() {
      return "https://youtube.com/embed/" + this.id;
    },
    baseUrl() {
      return process.env.VUE_APP_API_URL
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
      var sendUrl = this.baseUrl + "/Metadata";
      console.log(process.env);

      const request = {
        method: "get",
        url: sendUrl,
        params: {
          url: pastedData
        }
      };
      
      console.log(request);
      axios(request)
        .then((response) => {
          console.log(response);
          return response.data;
        })
        .then((data) => {
          this.id = data.id;
          console.log(data);
        });
    },
    
  },
};
</script>

<style>
</style>
