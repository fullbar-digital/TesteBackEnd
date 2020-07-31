<template>
    <v-snackbar
      :timeout="timeout"
      :color="color"
      v-model="snackbar"
      top
    >
      {{ text }}
      <v-btn text small @click.native="hideToast">Fechar</v-btn>
    </v-snackbar>
</template>
<script>
    export default {
        name: 'Toast',
        props: {
            timeout: {
                type: Number,
                default: 4000
            }
        },
        
        data: () => ({
            snackbar: false,
            text: '',
            color: '',
        }),
        
        methods: {
            showErrorToast(text) {
                this.showToast('error', text)
            },
            
            showSuccessToast(text) {
                this.showToast('success', text)
            },

            showToast(color, text) {
                this.color = color
                this.text = text
                this.snackbar = true
            },

            hideToast() {
                this.color = ''
                this.text = ''
                this.snackbar = false
                this.$emit('onHideToast')
            }
        }
    }
</script>