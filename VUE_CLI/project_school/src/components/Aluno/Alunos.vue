<template>
  <div>
    <titulo :texto="professorId != undefined ? 'Professor: ' + professor.nome : 'Todos Alunos'"/>
    <div v-if="professorId != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="AddAluno()">
      <button class="btn btn-input" @click="AddAluno()">Adicionar Aluno</button>
    </div>
    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="( aluno, index) in alunos" :key="index">
          <!-- <td>{{index + 1}}</td> -->
          <td class="colPequeno">{{aluno.id}}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer"
          >{{aluno.nome}} {{aluno.sobrenome}}</router-link>
          <td>
            <button class="btn btn-danger" @click="Remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <!-- <tfoot v-if="!alunos.length">Nenhum Aluno encontrado</tfoot> -->
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Professor encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo
  },
  //name: "Aluno",
  data() {
    return {
      titulo: "Aluno",
      professorId: this.$route.params.prof_id,
      nome: "",
      alunos: [],
      professor: {}
    };
  },
  created() {
    if (this.professorId) {
      this.CarregarProfessores();
      this.$http
        .get("http://localhost:5000/api/Aluno/ByProfessor/" + this.professorId)
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/api/aluno")
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    AddAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        dataNasc: "",
        idProfessor: this.professor.id
      };

      this.$http
        .post("http://localhost:5000/api/aluno", _aluno)
        .then(res => res.json())
        .then(aluno => {
          this.alunos.push(aluno);
          this.nome = "";
        });

      //this.alunos.push(_aluno);
      /*console.log("---------------");
      this.alunos.forEach(aluno => {
        console.log(aluno);
      });*/
      //this.nome = "";
    },
    Remover(aluno) {
      this.$http.delete(`http://localhost:5000/api/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
    CarregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professor/" + this.professorId)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor;
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #677f7f;
  display: inline;
}
.btn-input {
  width: 150px;
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btn-input:hover {
  padding: 20px;
  margin: 0px;
  border: 0;
}
</style>
