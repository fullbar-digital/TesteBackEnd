<template>
  <v-container grid-list-xl fluid>
    <v-layout row wrap align-end justify-end>
        <v-flex d-flex sm9 class="align-top">
          <v-icon>mdi-account</v-icon>
          <h3 class="page-title">Lista de Alunos</h3>
        </v-flex>
        <v-flex d-flex sm3 class="align-top" align-end>
          <v-spacer></v-spacer>
          <v-btn color="success" @click="cadastrarAluno()">
            Cadastrar aluno
          </v-btn>
        </v-flex>
        <v-flex lg12>
          <v-form ref="filtros" v-model="valid">
            <v-card>
              <v-toolbar flat card color="transparent">
                <slot name="widget-header-action">
                  <v-btn icon>
                    <v-icon>mdi-filter</v-icon>
                  </v-btn>
                </slot>  
                <v-toolbar-title>Filtros</v-toolbar-title>
              </v-toolbar>
              <v-divider></v-divider>
              <v-card-text class="white">
                <v-flex d-flex lg12 md12 sm12 xs12>
                  <v-flex d-flex lg6 md6 sm6 xs12>
                    <v-text-field
                      name="nome"
                      label="Nome do aluno"
                      placeholder="Nome"
                      type="text"                    
                      v-model="name"
                      outlined
                    />
                  </v-flex>
                  <v-flex d-flex lg6 md6 sm6 xs12>
                    <v-text-field
                      name="ra"
                      label="Ra do aluno"
                      placeholder="RA"
                      type="text"                    
                      v-model="ra"
                      outlined
                    />
                  </v-flex>
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-select
                      name="Curso"
                      placeholder="Curso"
                      label="Curso"
                      :items="cursos"
                      outlined
                      v-model="cursoId"
                    ></v-select>
                  </v-flex>
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-switch
                      v-model="status"
                      label="Status"
                    ></v-switch>
                  </v-flex>
                  <v-flex d-flex lg2 md2 sm2 xs12>
                    <v-btn color="primary" @click="pesquisarAlunos" style="margin-top: 8px;">
                      <v-icon>mdi-magnify</v-icon> Buscar
                    </v-btn>
                  </v-flex>
                </v-flex>
              </v-card-text>
            </v-card>
          </v-form>        
        </v-flex>
        <v-flex lg12>
          <v-card>
            <v-card-text class="pa-0">
              <v-data-table
                :headers="headers"
                :items="items"
                :page.sync="page"
                :items-per-page="itemsPerPage" 
                class="elevation-1"
                hide-default-footer
              >
              <template v-slot:item.action="{ item }">
                <v-btn class="ma-2" outlined small fab color="indigo" @click="deletarAluno(item)">
                  <v-icon>mdi-delete</v-icon>
                </v-btn>
                <v-btn class="ma-2" outlined small fab color="indigo" @click="editarAluno(item)">
                  <v-icon>mdi-pencil</v-icon>
                </v-btn>
              </template>
              </v-data-table>
              <v-pagination flat v-model="page" :total-visible="6" :length="pageCount" @input="onPageChange"></v-pagination>
            </v-card-text>
          </v-card>
        </v-flex>
    </v-layout>
    <toast ref="toast" />     
  </v-container>
</template>
<script>
import Toast from '../shared/Toast'

export default {
    name: 'List',
    components: {
       Toast
    },
    data: () => ({
      name: '',
      ra: '',
      status: true,
      cursos: [],
      cursoId: 0,
      valid: true,
      itemsPerPage: 15,
      page: 1,
      pageCount: 0,
      headers: [
        { text: 'Nome', value: 'name', sortable: false }, 
        { text: 'Ra', value: 'ra', sortable: false }, 
        { text: 'Periodo Inicial', value: 'initialDate', sortable: false },
        { text: 'Periodo Final', value: 'endDate', sortable: false }, 
        { text: 'Curso', value: 'course', sortable: false },
        { text: 'Nota do Aluno', value: 'grade', sortable: false }, 
        { text: 'Status', value: 'status', sortable: false }, 
        { text: 'Ações', value: 'action', sortable: false }
      ],
      items: []
     }),

     methods: {        
        getUsersList(page = 1, name = '', ra = '', status = true, cursoId = 0) {
            const { $request, $refs } = this
            let endpoint = `/alunos?pagina=${page}`

            if (name.trim() !== '')
              endpoint += `&name:contains=${name}`

            if (ra.trim() !== '')
              endpoint += `&ra:contains=${ra}`

            endpoint += `&status:eq=${status}`;

            if (cursoId > 0)
              endpoint += `&courseId:eq=${cursoId}`;
          
            $request.get(endpoint)
                    .then(({ data }) => {
                      this.items = data.data;
                      this.pageCount = data.totalPages
                    })
                    .catch(() => $refs.toast.showErrorToast('Ocorreu um erro ao buscar os usuários'))
        },

        pesquisarAlunos() {
          this.getUsersList(1, this.name, this.ra, this.status, this.cursoId);
        },

        cadastrarAluno(){
          this.$router.push(`/alunos/cadastrar`);
        },

        editarAluno(item) {
            this.$router.push(`/alunos/${item.id}/editar`);
        },

        deletarAluno(item) {

          this.$confirm("Deseja realmente deletar o aluno?")
            .then(response => {
              if (response) {
                this.$request.delete(`/alunos/${item.id}`)
                  .then(() => {
                    this.refresh();
                  })
                  .catch(({ response }) => {
                    $refs.toast.showErrorToast(response ? response.data : 'Ocorreu um erro inesperado, favor tente novamente!')
                  })        

              }
            })   
        },

       obterCursos() {
          this.$request(`/cursos`)
              .then(({ data }) => {
                this.cursos = data.map(m => ({
                  text: m.name,
                  value: m.id
                }))
              })
       },

        refresh() {
          this.getUsersList()
        },

        onPageChange(page) {
           this.getUsersList(page, this.name, this.ra, this.status, this.cursoId)
        }
     },

     created() {
      this.obterCursos();
      this.getUsersList();
     }
}
</script>