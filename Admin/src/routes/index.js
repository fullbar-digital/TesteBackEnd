import Vue from 'vue'
import Router from 'vue-router'

import {
    AlunoRegister,
    AlunoEdit, 
    AlunoList 
} from '@/views/alunos'

Vue.use(Router);

const router = new Router({
    routes: [
        {
            path: '/alunos',
            name: 'alunos',
            component: AlunoList
        },
        {
            path: '/alunos/cadastrar',
            name: 'AlunosCadastro',
            component: AlunoRegister
        },
        {
            path: '/alunos/:id/editar',
            name: 'AlunosEdicao',
            component: AlunoEdit
        }
    ]
})

export default router;