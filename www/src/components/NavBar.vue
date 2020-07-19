<template>
    <nav class="navbar navbar-expand-lg fixed-top navbar-light bg-light">
      <div class="container-fluid">
          <a class="navbar-brand" href="#">Fllr.art</a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
              aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="#documentation">Documentation</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#try-it">Try it</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Github</a>
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