<template>
  <div id="app">
    <NavBar />
    <Masthead heading="Fllr.art" subheading="An image generation API for all your FPO image needs" />
    <section id="documentation">
      <div>

      </div>
    </section>
    <section id="try-it">
      <LinkGenerator />
    </section>
  </div>
</template>

<script>
import NavBar from './components/NavBar.vue'
import Masthead from './components/Masthead.vue'
import LinkGenerator from './components/LinkGenerator.vue'

export default {
  name: 'App',
  components: {
    NavBar,
    Masthead,
    LinkGenerator
  }
}
</script>

<style>
h1,
h2,
h3 {
    font-family: 'Montserrat';
    color: #262321;
}

h4,
h5,
h6 {
  color: #397AA3;
}

body {
  background-color: #FCFCFC;
}
</style>
