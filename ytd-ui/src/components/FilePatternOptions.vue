<template>
    <v-radio-group row solo dense hide-details="true" class="mt-0 align-center" mandatory v-model="filenamePattern">
        <template v-slot:label>
            <div class="align-self-center mb-0 mr-2">Nombre del archivo:</div>
        </template>
        <v-radio value="justTitle"     :label="'Título'"                  solo dense hide-details="true" />
        <v-radio value="uploaderTitle" :label="'Usuario Subida - Título'" solo dense hide-details="true" />
    </v-radio-group>
</template>

<script>
import * as AppMutations from '../store/app/app-mutations'
export default {
    // data() {
    //     return {
    //         filenamePattern: ''
    //     }
    // },
    computed: {
        filenamePattern: {
            get() {
                return this.$store.state.app.filePattern;
            },
            set(value) {
                this.$store.commit(AppMutations.UPDATE_FILE_PATTERN, { filePattern: value })
            }
        }
    }
}
</script>

<style>

</style>