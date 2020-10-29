<template>
    <div id="app">
        <!--Pinto el componente Home-->
        <Home msg="CRUD ASP.NET WEBAPI 2 CON VUE.JS" />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';

    // Importo el componente Home.vue
    import Home from './components/Home.vue';                

    //Instancio el componente Home
    @Component({
        components: {
            Home
        }
    })
    export default class App extends Vue { }
</script>

<style>
</style>
