<template>
    <div class="home">
        <h1>{{msg}}</h1>
        <!--Pinto el componente Formulario
            v-on:submit     -> Escucha un evento personalizado llamado submit
            v-bind:Persona  -> Paso el "modelo" al componente
        -->
        <Formulario v-on:submit="defineMethod"
                    v-bind:Persona="Persona">
        </Formulario>

        <!--Pinto el componente Tabla
            v-bind:Personas         -> paso el "modelo" al componente
            v-on:eliminar-persona   -> Escucha un evento personalizado llamado eliminar-persona
            v-on:editar-persona     -> Escucha un evento personalizado llamado editar-persona
        -->
        <Tabla v-bind:Personas="Lista"
               v-on:eliminar-persona="deleteMethod"
               v-on:editar-persona="editMethod">
        </Tabla>

        <!--<b-table striped hover :items="Lista"></b-table>-->
        <p>
            Welcome to your new single-page application, built with
            <a href="https://vuejs.org" target="_blank">Vue.js</a> and
            <a href="http://www.typescriptlang.org/" target="_blank">TypeScript</a>.
        </p>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    //Importo los componentes Tabla y formulario 
    import Formulario from '../components/Formulario.vue'
    import Tabla from '../components/Tabla.vue';

    //Clase local para el manejo de personas
    class Datos {
        Id: number;
        Nombre: string;
        Edad: number;
        constructor(id: number, nombre: string, edad: number) {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
        }
    }

    //Instancio los componentes
    @Component({
        components: {
            Formulario,
            Tabla
        }
    })

    export default class Home extends Vue {

        //Propiedades "parametros" del componente
        @Prop() msg!: string;

        //Atributos del componente
        Lista: Array<any> = new Array<any>();
        Persona: Datos = new Datos(0, '', 0);

        //Métodos del componente
        //created() es similar al $(function(){}); de JQUERY
        created(): void {
            this.getPersonas();
        }

        //Invoco el método GET del API y guardo el resultado en el atributo Lista
        getPersonas(): void {
            this.axios.get('https://localhost:44397/api/Home')
                .then(response => {
                    this.Lista = response.data
                });
        }

        //Invoco el método POST del API e invoco el método GET en la respuesta
        postMethod(persona: Datos): void {
            this.axios.post('https://localhost:44397/api/Home', persona)
                .then(response => {
                    this.getPersonas();
                    this.Persona = new Datos(0, '', 0);
                });
        }

        //Invoco el método PUT del API e invoco el método GET en la respuesta
        putMethod(persona: Datos): void {
            this.axios.put('https://localhost:44397/api/Home/' + persona.Id, persona)
                .then(response => {
                    this.getPersonas();
                    this.Persona = new Datos(0, '', 0);
                });
        }

        //Invoco el método DELETE del API e invoco el método GET en la respuesta
        deleteMethod(persona: Datos): void {
            this.axios.delete('https://localhost:44397/api/Home/' + persona.Id)
                .then(response => {
                    this.getPersonas();
                    this.Persona = new Datos(0, '', 0);
                });
        }

        //Defino el método a usar cuando se dispara el evento submit del componente Formulario
        defineMethod(persona: Datos): void {

            //Valido si es nuevo o si se cargaron datos al formulario
            if (persona.Id == 0) {
                this.postMethod(persona);
            } else {
                this.putMethod(persona);
            }
        }

        //Cargo los datos del registro a editar en el formulario
        editMethod(persona: Datos): void {

            //Pasando un nuevo objeto quita la reactividad en la tabla
            this.Persona = new Datos(persona.Id, persona.Nombre, persona.Edad);
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
