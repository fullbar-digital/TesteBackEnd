<template>
    <v-flex d-flex sm12 class="align-top">
        <v-icon>{{ icon }}</v-icon>
        <h3 class="page-title">{{ title }}</h3>
    </v-flex>
</template>
<script>
    export default {
        name: 'PageTitle',
        props: {
            icon: {
                required: true,
                type: String
            },
            title: {
                required: true,
                type: String
            }
        }
    }
</script>
<style>
    .page-title {
        margin-left: 10px;
    }
</style>