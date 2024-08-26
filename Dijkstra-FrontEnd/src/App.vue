<script setup lang="ts">
import Calculator from './components/Calculator.vue'
</script>

<template>
  <header>
    <div class="row">
      <div class="col-md-12 heading-column">
        <h1>Dijkstra’s Algorithm Calculator</h1>
        <p>Discovering Optimal Routes Through Nodes Using Dijkstra’s Method</p>
      </div>
      <div class="col-md-12 content">
        <Calculator />
      </div>
    </div>
  </header>
</template>

<style scoped>
.heading-column {
  text-align: center;
  margin-top: 50px;
  width: 100%;
}
.content {
  margin-left: 20px;
}
</style>
