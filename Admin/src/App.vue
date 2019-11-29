<template>
  <div>
    <template v-if="!$route.meta.allowAnonymous">
      <v-app id="inspire">
        <div class="app-container">
          <navigation-drawer :drawer="drawer" />
          <app-bar @toggleNavigationBar="toggleNavigationBar" />
          <v-content>
            <router-view/>
          </v-content>
        </div>
      </v-app>
    </template>
    <template v-else>
      <transition>
        <keep-alive>
          <router-view></router-view>
        </keep-alive>
      </transition>
    </template>
    <BlockUI v-if="isLoading">
      <v-progress-circular :width="3" indeterminate color="primary"></v-progress-circular>
    </BlockUI>
  </div>
</template>

<script>
  import { eventBus } from '@/common/eventbus'
  import AppBar from '@/views/layout/AppBar'
  import NavigationDrawer from '@/views/layout/NavigationDrawer'

  export default {
    components: {
      AppBar,
      NavigationDrawer       
    },
    data: () => ({
      drawer: true,
      isLoading: false,
      text: '',
      color: '',
      snackbar: false
    }),
    methods: {
        toggleNavigationBar(){
          this.drawer = !this.drawer
        },

        showLoading() {
          this.isLoading = true
        },

        hideLoading() {
          this.isLoading = false
        }
    },

    created() {
      eventBus.$on('onRequest', this.showLoading)
      eventBus.$on('onResponse', this.hideLoading)
      eventBus.$on('onResponseError', this.hideLoading)
    },

    beforeDestroy() {
      eventBus.$off('onRequest', this.showLoading)
      eventBus.$off('onResponse', this.hideLoading)
      eventBus.$off('onResponseError', this.hideLoading)
    }
  }
</script>
