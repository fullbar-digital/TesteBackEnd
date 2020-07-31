<template>
  <v-container grid-list-xl fluid>
    <v-layout row wrap>
      <page-title title="Edição de Aluno" icon="mdi-account" />
      <v-flex lg12 md12 sm12 xs12>
        <v-card>
          <v-form
            ref="form"
            v-model="valid"
          >
            <v-card-text class="white">
                <v-flex d-flex lg12 md12 sm12 xs12>
                  <v-flex d-flex lg8 md8 sm8 xs12>
                    <v-text-field
                      name="Nome"
                      label="Nome"
                      placeholder="Nome"
                      type="text"
                      v-model="aluno.name"
                      :rules="[x => !!x || 'O campo nome é obrigatório']"
                      outlined
                    />
                  </v-flex>
                  <v-flex d-flex lg8 md8 sm8 xs12>
                    <v-text-field
                      name="Ra"
                      label="Ra"
                      placeholder="Ra do aluno"
                      type="text"
                      v-model="aluno.ra"
                      :rules="[x => !!x || 'O campo ra é obrigatório']"
                      outlined
                    />
                  </v-flex>
                </v-flex>

                <v-flex d-flex lg12 md12 sm12 xs12>
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-text-field
                      name="initialDate"
                      label="Período inicial"
                      placeholder="Período inicial"
                      type="text"
                      v-mask="'##/##/####'"                    
                      v-model="aluno.initialDate"
                      :rules="[x => !!x || 'O campo Periodo inicial é obrigatório']"
                      outlined
                    />
                  </v-flex>
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-text-field
                      name="endDate"
                      label="Período final"
                      placeholder="Período final"
                      type="text"
                      v-mask="'##/##/####'"                    
                      v-model="aluno.endDate"
                      :rules="[x => !!x || 'O campo Periodo final é obrigatório']"
                      outlined
                    />
                  </v-flex>   
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-select
                       :items="cursos"
                        label="Curso"
                        placeholder="Curso"
                        outlined
                        v-model="aluno.courseId"
                        :rules="[x => !!x || 'O campo Curso é obrigatório']"
                    ></v-select>
                  </v-flex>
                </v-flex>

                <v-flex d-flex lg12 md12 sm12 xs12>
                  <v-flex d-flex lg4 md4 sm4 xs12>
                    <v-text-field
                      name="grade"
                      label="Nota"
                      placeholder="Nota"
                      type="number"
                      v-model="aluno.grade"
                      :rules="[x => !!x || 'O campo Nota é obrigatório']"
                      outlined
                      min="0"
                      max="10"
                    />
                  </v-flex>
                  <v-flex d-flex lg4 md4 sm4 xs12 v-if="!isNew">
                    <v-text-field
                      name="status"
                      label="Status"
                      :placeholder="aluno.status"
                      type="text"
                      :disabled="true"
                      outlined
                    />
                  </v-flex>
                </v-flex>

            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="primary" dark @click="voltar">
                <v-icon>mdi-arrow-left</v-icon> Voltar
              </v-btn>
              <v-btn color="success" dark @click="cadastrarAluno" v-if="isNew">
                <v-icon>mdi-floppy</v-icon>
                Cadastrar
              </v-btn>
              <v-btn color="success" dark @click="alterarAluno" v-else>
                <v-icon>mdi-floppy</v-icon>
                Alterar
              </v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-flex>
    </v-layout>
    <toast ref="toast" />
  </v-container>
</template>
<script>

import Toast from '../shared/Toast'
import PageTitle from '../shared/PageTitle'

export default {
    name: 'Edit',
    components: {
       Toast,
       PageTitle
    },
    data: () => ({
      isNew: true,
      perfis: [],
      valid: true,
      cursos: [],
      aluno: {
        id: 0,
        name: '',
        ra: '',
        status: '',
        courseId: 0,
        initialDate: '',
        endDate: '',
        grade: 0
      }
    }),
    methods: {
       obterAluno() {
          const { $refs, $route, $router, $request } = this

          $request(`/alunos/${$route.params.id}`)
              .then(({ data }) => {
                 this.aluno = data;
              })
              .catch(() => {
                  $refs.toast.showErrorToast('ocorreu um erro na busca do aluno, favor tente mais tarde')
                  setTimeout(() => $router.push('/alunos'), 4100)
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

       cadastrarAluno() {
          const { 
            $refs, 
            $request, 
            $router, 
            aluno,
            $route 
          } = this

          if (!$refs.form.validate()) return;

          $request.post('/alunos/', aluno)
          .then((result) => {
              $refs.toast.showSuccessToast(result.data.message)
             setTimeout(() => $router.push('/alunos'), 4100)
          })
          .catch(({ response }) => { 
              if (response && response.data)
                $refs.toast.showErrorToast(response.data)
              else {
                $refs.toast.showErrorToast('Ocorreu um erro ao salvar o aluno, favor tente mais tarde')
                setTimeout(() => $router.push('/alunos'), 4100)
              }
          })        
       },

       alterarAluno() {
          const { 
            $refs, 
            $request, 
            $router, 
            aluno,
            $route 
          } = this

          if (!$refs.form.validate()) return

          const payload = Object.assign({ id: $route.params.id }, aluno)

          $request.put('/alunos/' + $route.params.id, payload)
          .then((result) => {
            this.aluno.status = result.data.status;
            $refs.toast.showSuccessToast(result.data.message)
            setTimeout(() => $router.push('/alunos'), 4100)
          })
          .catch(({ response }) => { 
              if (response && response.data)
                $refs.toast.showErrorToast(response.data)
              else {
                $refs.toast.showErrorToast('Ocorreu um erro ao salvar o aluno, favor tente mais tarde')
                setTimeout(() => $router.push('/alunos'), 4100)
              }
          })        
       },

       voltar() {
          this.$router.push('/alunos')
       }
    },

    async created() {
      this.isNew = this.$route.params.id === undefined;

      this.obterCursos();

      if(!this.isNew){
        await this.obterAluno();
      }
    }
}
</script>
