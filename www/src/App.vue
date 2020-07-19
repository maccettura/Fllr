<template>
  <div id="app">
    <NavBar />
    <Masthead heading="Fllr.art" subheading="An image generation API for all your FPO image needs" />
    <section id="documentation">
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
    font-family: 'Montserrat'
}

.masthead {
    height: 100vh;
    min-height: 500px;
    background-image: url('https://source.unsplash.com/BtbjCFUvBXs/1920x1080');
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
}
</style>
