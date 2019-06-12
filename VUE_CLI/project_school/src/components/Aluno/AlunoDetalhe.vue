<template>
  <div>
    <titulo :texto="`Aluno: ${aluno.nome}`"/>
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
      aluno: {},
      id: this.$route.params.id
    };
  },
  created() {
    this.$http
      .get("http://localhost:3000/aluno/" + this.id)
      .then(res => res.json())
      .then(aluno => (this.aluno = aluno));
  },
  methods: {}
};
</script>

<style lang="scss" scoped>
</style>