<template>
  <v-flex class="d-flex">
    <file-pattern-options />
    <v-spacer />
    <v-select
      :items="fileTypes"  item-text="text"        item-value="fileType" label="Tipo"  solo  dense   hide-details="true" 
      cols="auto"         style="max-width: 15%"  class="mr-4"          background-color="#E5E5E5"  v-model="fileFormat"
    >
    </v-select>
    <v-btn color="primary" @click="download()" :loading="waitingFile" :disabled="waitingFile">
      Descargar
    </v-btn>
  </v-flex>
</template>

<script>
import FilePatternOptions from "../components/FilePatternOptions.vue";

import fileTypes from "../constants/DownloadFileTypes";
import DownloadService from "../services/DownloadService";

import * as AppMutations from "../store/app/app-mutations";

export default {
  components: {
    FilePatternOptions,
  },
  props: {},
  data() {
    return {
      waitingFile: false,
      fileTypes,
    };
  },
  computed: {
    fileFormat: {
      get() {
        return this.$store.state.app.fileFormat;
      },
      set(value) {
        this.$store.commit(AppMutations.UPDATE_FILE_FORMAT, {
          fileFormat: value,
        });
      },
    },
  },
  methods: {
    download() {
      this.waitingFile = true;
      DownloadService.downloadVideo().then(() => (this.waitingFile = false));
    },
  },
};
</script>

<style>
</style>