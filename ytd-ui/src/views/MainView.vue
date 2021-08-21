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

export default {
  components: {
    VideoPart
  },
  data() {
    return {
      fileTypes: [
        { text: "Audio", fileType: "mp3" },
        { text: "Video", fileType: "mp4" },
      ],
      id: "",
      url: "",
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
    download(url) {
      const request = {
        method: "get",
        url: this.baseUrl + "/Download",
        responseType: 'blob',
        params: {
          url: url,
          format: this.dataType,
          filenameFormat: this.filenamePattern
        }
      };
      this.waitingFile = true;
      console.log(request);
      axios(request)
        .then((response) => {
          console.log(response);
          const blob = new Blob([response.data]);
          const link = document.createElement("a");
          link.href = URL.createObjectURL(blob);
          let filename = response.headers["x-filename"];
          console.log(filename);
          link.download = filename;
          link.click();
          URL.revokeObjectURL(link.href);
          this.waitingFile = false;
        })
        .catch((err) => console.log(err));
    },
  },
};
</script>

<style>
</style>
