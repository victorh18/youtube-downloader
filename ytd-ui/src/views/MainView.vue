<template>
  <v-content>
    <v-container style="border: black 0px solid; height: 70vh">
      <v-flex style="height: 100%" class="pa-3">
        <p class="my-0">Link del vídeo:</p>
        <v-text-field
          v-model="url"
          solo
          dense
          @paste="getVideoMetadata"
        ></v-text-field>
        <v-flex class="d-flex flex-column" fill-height v-if="url">
          <v-flex class="d-flex justify-center" fill-height>
            <v-sheet
              elevation="5"
              width="100%"
              height="100%"
              class="d-flex flex-column align-center pt-4"
              id="lol"

            >
              <v-flex
                class="d-flex flex-column align-self-stretch px-16 pb-8"
                fill-height
              >
                <v-sheet
                  color="#E5E5E5"
                  width="100%"
                  height="100%"
                  class="mb-2 align-center d-flex justify-center"
                >
                  <iframe
                    width="60%"
                    height="100%"
                    :src="embeddedUrl"
                    title="YouTube video player"
                    frameborder="0"
                    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                    allowfullscreen
                  ></iframe>
                </v-sheet>
                <v-flex class="d-flex">
                  <!-- <div class="align-self-center mb-0 mr-2">Nombre del archivo:</div> -->
                  <v-radio-group row
                    solo
                    dense
                    hide-details="true"
                    class="mt-0 align-center"
                    mandatory
                  >
                  <template v-slot:label>
                    <div class="align-self-center mb-0 mr-2">Nombre del archivo:</div>
                  </template>
                    <v-radio :key=1 :label="'Título'" 
                    solo
                    dense
                    hide-details="true"
                    />
                    <v-radio :key=1 :label="'Título - Usuario subida'"
                    solo
                    dense
                    hide-details="true"
                     />
                  </v-radio-group>
                  <v-spacer></v-spacer>
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
                    v-model="dataType"
                  >
                  </v-select>
                  <!-- <v-btn>audio</v-btn> -->
                  <v-btn
                    color="primary"
                    @click="download(url)"
                    :loading="waitingFile"
                    :disabled="waitingFile"
                    >Descargar</v-btn
                  >
                  
                </v-flex>
              </v-flex>
            </v-sheet>
          </v-flex>
        </v-flex>
      </v-flex>
    </v-container>
  </v-content>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      fileTypes: [
        { text: "Audio", fileType: "mp3" },
        { text: "Video", fileType: "mp4" },
      ],
      id: "",
      url: "",
      dataType: "mp3",
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

      //var sendUrl = "http://localhost:5000/Metadata?url=" + pastedData;
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
        url: "http://ytdapi.victorh18.info/Download",
        responseType: 'blob',
        params: {
          url: url,
          format: this.dataType
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
          //
          // let filename = response.headers["x-filename"];
          // const Fs = require('fs');
          // Fs.createWriteStream(filename);
          // response.data.
        })
        .catch((err) => console.log(err));
    },
  },
};
</script>

<style>
</style>
