<template>
    <nav class="navbar navbar-expand-lg fixed-top navbar-dark" style="background-color: #2B404E;">
      <div class="container-fluid">
          <a class="navbar-brand" href="#">Fllr.art</a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
              aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" target="_blank" href="https://github.com/maccettura/Fllr"> <img src="github.png" srcset="github-high.png 2x"> </a>
                </li>
            </ul>
        </div>
      </div>
    </nav>
</template>

<script>
export default {
  name: 'NavBar'
}
</script>