<template>
    <div>
        <table class="table table-sm">
            <thead class="bg bg-dark text-white">
                <tr>
                    <th>Nombre</th>
                    <th>Edad</th>
                    <th>Fecha Alta</th>
                    <th colspan="2">Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="p in Personas">
                    <td>{{p.Nombre}}</td>
                    <td>{{p.Edad}}</td>
                    <td>{{p.FechaN}}</td>
                    <td><button class="btn btn-sm btn-dark" v-on:click="Editar(p)">Editar</button></td>
                    <td><button class="btn btn-sm btn-danger" v-on:click="Eliminar(p)">Eliminar</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    //Clase local para el manejo de datos
    class Persona {
        Id: number;
        Nombre: string;
        Edad: number;
        constructor(id: number, nombre: string, edad: number) {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
        }
    }

    @Component
    export default class Tabla extends Vue {

        //Propiedades (parametros) del componente
        @Prop() public Personas!: Array<any>;

        //Métodos del componente
        //creo y disparo un evento personalizado con un objeto
        Editar(persona: Persona): void {
            this.$emit('editar-persona', persona);
        }

        //creo y disparo un evento personalizado con un objeto
        Eliminar(persona: Persona): void {
            this.$emit('eliminar-persona', persona);
        }
    }
</script>

<style scoped>
    button{
        width:100px;
    }
</style>