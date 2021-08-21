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
export default {
    data() {
        return {
            filenamePattern: ''
        }
    },
    methods: {
        
    }
}
</script>

<style>

</style>