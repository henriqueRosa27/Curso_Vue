<template>
  <div>
    <titulo texto="Professores" :btnVoltar="true"/>
    <table>
      <thead>
        <th>Cod.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="( professor, index) in professores" :key="index">
          <!-- <td>{{index + 1}}</td> -->
          <td class="colPequeno" >{{professor.id}}</td>
          <!-- <td> -->
          <router-link
            :to="'/alunos/' + professor.id"
            tag="td"
            style="cursor:pointer"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>
          <!-- </td> -->
          <td class="colPequeno" >{{professor.qtdAlunos }}</td>
        </tr>
      </tbody>
      <!-- <tfoot v-if="!professores.length">Nenhum Aluno encontrado</tfoot> -->
     <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Aluno encontrado</h5>
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
  data() {
    return {
      professores: [],
      alunos: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/aluno")
      .then(res => res.json())
      .then(aluno => {
        this.alunos = aluno;
        this.CarregarProfessores();
      });
  },
  props: {},
  methods: {
    pegarQtdAlunoPorProfessor() {
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(
            aluno => aluno.professor.id == professor.id
          ).length
        };
        this.professores[index] = professor;
      });
    },
    CarregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(professor => {
          this.professores = professor;
          this.pegarQtdAlunoPorProfessor();
        });
    }
  }
};
</script>

<style scoped>

.colPequeno{
text-align:center; width: 15%
}

</style>