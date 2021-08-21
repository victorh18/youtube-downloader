<template>
    <v-flex class="d-flex flex-column" fill-height>
        <v-flex class="d-flex justify-center" fill-height>
        <v-sheet elevation="5" width="100%" height="100%" class="d-flex flex-column align-center pt-4">
            <v-flex fill-height class="d-flex flex-column align-self-stretch px-16 pb-8">
            <video-frame :embeddedUrl="embeddedUrl" />
            <video-options />
            </v-flex>
        </v-sheet>
        </v-flex>
    </v-flex>
</template>

<script>
import VideoFrame from "../components/VideoFrame.vue";
import VideoOptions from '../components/VideoOptions.vue';

export default {
    components: {
        VideoFrame,
        VideoOptions
    },
    props: {
        embeddedUrl: {
            type: String,
            required: true
        }
    }
    
}
</script>