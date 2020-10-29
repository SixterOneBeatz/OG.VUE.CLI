<template>
    <div>
        <form v-on:submit="submitMethod">
            <input type="hidden" v-model="Persona.Id" />
            <div class="form-gropup">
                <input type="text"
                       class="form-control"
                       placeholder="Nombre..."
                       v-model="Persona.Nombre"
                       required>
            </div>
            <div class="form-gropup">
                <input type="number"
                       class="form-control"
                       placeholder="Edad..."
                       v-model="Persona.Edad"
                       required>
            </div>
            <input type="submit" value="Guardar" class="btn btn-primary" />
        </form>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    //Clase local para el manejo de datos 
    class Datos {
        Id: number;
        Nombre: string;
        Edad: number;
        constructor(id: number, nombre: string,edad:number) {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
        }
    }

    @Component
    export default class Formulario extends Vue {

        //Propiedades (parametros) del componente
        @Prop() public Persona!: Datos;

        //Métodos del componente
        submitMethod(e: any): void {

            //preventDefault impide que se ejecute la acción del form y dispara mi evento personalizado
            e.preventDefault();

            //$emit se crea y dispara un evento personalizado con un objeto
            this.$emit('submit', this.Persona);
        }
    }
</script>

<style scoped>
</style>