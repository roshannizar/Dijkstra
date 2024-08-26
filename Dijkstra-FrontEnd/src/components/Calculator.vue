<script setup lang="ts"></script>

<template>
  <div class="row">
    <div class="col-md-2"></div>
    <div class="col-md-4 form-container">
      <h3>Select Path</h3>
      <div class="form-group">
        <label>From Node</label>
        <select v-model="fromNode">
          <option>Select</option>
          <option v-for="node in nodes" :key="node" :value="node">{{ node }}</option>
        </select>
      </div>
      <div class="form-group">
        <label>To Node</label>
        <select v-model="toNode">
          <option>Select</option>
          <option v-for="node in nodes" :key="node" :value="node">{{ node }}</option>
        </select>
      </div>
      <div class="actions">
        <button @click="clear">Clear</button>
        <button @click="calculate">Calculate <i class="fas fa-calculator"></i></button>
      </div>
    </div>

    <div class="col-md-4 form-container" v-if="result">
      <h4>Shortest Path:</h4>
      <p>
        From Node Name : {{ this.fromNode }}, To Node Name: {{ this.toNode }}:
        {{ result.nodeNames.join(', ') }}
      </p>
      <p>Total Distance: {{ result.distance }}</p>
    </div>

    <div class="col-md-4 form-container" v-if="result == null">
      <p>Output Will be here</p>
    </div>

    <div class="col-md-2"></div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      fromNode: '',
      toNode: '',
      nodes: ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'],
      result: null
    }
  },
  methods: {
    clear() {
      this.fromNode = ''
      this.toNode = ''
    },
    async calculate() {
      try {
        const response = await axios.get('https://localhost:44325/api/v1/algorithm', {
          params: {
            fromNode: this.fromNode,
            toNode: this.toNode
          }
        })

        this.result = response.data
      } catch (error) {
        this.result = 'An error occurred while calculating the path. Please try again.'
      } finally {
      }
    }
  }
}
</script>

<style scoped>
label,
h3 {
  color: black;
}
.form-container {
  color: black;
  background-color: #fff;
  padding: 20px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  width: 50%;
  float: left;
  margin: auto;
  height: 300px;
}
h3 {
  margin-bottom: 20px;
}
.form-group {
  margin-bottom: 15px;
}
select {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
}
.actions {
  display: flex;
  margin-right: 10px;
}
button {
  background-color: #ff7733;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-right: 10px;
}
button:first-of-type {
  background-color: #ff7733;
}
</style>
