<template>
  <v-navigation-drawer v-model="drawer" :clipped="$vuetify.breakpoint.lgAndUp" app>    
    <v-list dense>
      <v-list-item
        v-for="item in items"
        :key="item.text"
        link
        @click="item.click"
      >
        <v-list-item-action> 
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>
            {{ item.title }}
          </v-list-item-title>
        </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
</template>
<script>

export default {
    props: {
        drawer: {
            type: Boolean,
            required: true
        }        
    },
    data() {
      return {
        items:[
          { 
            title: 'Alunos', 
            icon: 'mdi-account',
            click: () => {
               this.$router.push("/alunos")
            } 
          }
      ]
      }
    }
}
</script>
