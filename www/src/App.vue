<script setup>
import LinkGenerator from './components/LinkGenerator.vue'
</script>

<template>
  <div id="app">
    <nav class="navbar fixed-top navbar-dark" style="background-color: #2B404E;">
      <div class="container-fluid">
          <a class="navbar-brand" href="#">fllr.art</a>
            <ul class="navbar-nav justify-content-end">
                <li class="nav-item">
                    <a class="nav-link" target="_blank" href="https://github.com/maccettura/Fllr"> <img src="/img/GitHub-Mark-Light-32px.png"> </a>
                </li>
            </ul>
      </div>
    </nav>
    <header class="masthead">
      <div class="container h-100">
          <div class="row h-100 align-items-center">
              <div class="col-12 text-center">
                  <h1 class="display-1">fllr.art</h1>
                  <p class="lead">An image generation API for all your FPO image needs</p>
              </div>
          </div>
      </div>
    </header>
    <LinkGenerator />
  </div>
</template>

<style scoped>
body {
  background-color: #FCFCFC;
}

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

.masthead {
    height: 20vh;
    min-height: 300px;
}
</style>
