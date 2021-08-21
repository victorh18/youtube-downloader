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
        v-model="dataType"
        >
        </v-select>
        <v-btn color="primary" @click="download(url)" :loading="waitingFile" :disabled="waitingFile">Descargar</v-btn>
    </v-flex>
</template>

<script>
import FilePatternOptions from "../components/FilePatternOptions.vue"
export default {
    components: {
        FilePatternOptions
    },
    data() {
        return {
            url: '',
            waitingFile: false
        }
    }
}
</script>

<style>

</style>