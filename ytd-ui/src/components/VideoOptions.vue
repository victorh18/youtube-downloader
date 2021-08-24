<template>
  <v-flex class="d-flex">
    <file-pattern-options />
    <v-spacer />
    <v-select
      :items="fileTypes"
      item-text="text"
      item-value="fileType"
      label="Tipo"
      solo
      dense
      hide-details="true"
      cols="auto"
      style="max-width: 15%"
      class="mr-4"
      background-color="#E5E5E5"
      v-model="fileFormat"
    >
    </v-select>
    <v-btn
      color="primary"
      @click="download(url)"
      :loading="waitingFile"
      :disabled="waitingFile"
      >Descargar</v-btn
    >
  </v-flex>
</template>

<script>
import FilePatternOptions from "../components/FilePatternOptions.vue";
import axios from "axios";
import fileTypes from "../constants/DownloadFileTypes";

import * as AppMutations from "../store/app/app-mutations"

export default {
  components: {
    FilePatternOptions,
  },
  props: {

  },
  data() {
    return {
      waitingFile: false,
      dataType: "",
      fileTypes,
    };
  },
  computed: {
      baseUrl() {
      return process.env.VUE_APP_API_URL
    },
    url() {
      return this.$store.state.app.url;
    },
    fileFormat: {
      get() {
        return this.$store.state.app.fileFormat;
      },
      set(value) {
        this.$state.commit(AppMutations.UPDATE_FILE_FORMAT, { fileFormat: value })
      }
    }
  },
  methods: {
    
    download(url){
      const request = {
        method: "get",
        url: this.baseUrl + "/Download",
        responseType: "blob",
        params: {
          url: url,
          format: this.dataType,
          filenameFormat: this.filenamePattern,
        },
      };
      this.waitingFile = true;
      console.log(request);
      axios(request)
        .then((response) => {
          console.log(response);
          const blob = new Blob([response.data]);
          const link = document.createElement("a");
          link.href = URL.createObjectURL(blob);
          let filename = decodeURI(response.headers["x-filename"]);
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