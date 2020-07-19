<template>
    <header class="masthead">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12 text-center">
                    <h1 class="display-1">{{ Heading }}</h1>
                    <p class="lead">{{ Subheading }}</p>
                </div>
            </div>
        </div>
    </header>
</template>

<script>
export default {
  name: 'Masthead',
  props: {
      Heading: String,
      Subheading: String
  }
}
</script>

<style scoped>
    .masthead {
        height: 20vh;
        min-height: 300px;
    }
</style>