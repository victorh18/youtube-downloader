<template>
    <v-sheet color="#E5E5E5" width="100%" height="100%" class="mb-2 align-center d-flex justify-center" >
        <iframe
            width="60%" height="100%" :src="embeddedUrl" title="YouTube video player" frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowfullscreen
        ></iframe>
    </v-sheet>
</template>

<script>
export default {
    computed: {
        embeddedUrl() {
            return this.$store.getters.embeddedUrl;
        },
    }
}
</script>

<style>

</style>