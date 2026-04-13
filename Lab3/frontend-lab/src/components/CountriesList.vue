```vue
<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de países</h1>
            <div class="row justify-content-end">
        <div class="col-2">
            <a href="/country">
                <button type="button" class="btn btn-outline-secondary float-right"> 
                    Agregar pais
                </button>
            </a>
        </div>
    </div>

        <table class="table table-bordered table-striped table-hover">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(country, index) of countries" :key="index">
                    <td>{{ country.name }}</td>
                    <td>{{ country.continent }}</td>
                    <td>{{ country.language }}</td>
                    <td>
                        <button class="btn btn-secondary btn-sm me-2">
                            Editar
                        </button>
                        <button class="btn btn-danger btn-sm"
                                v-on:click="deleteCountry(index)">
                            Eliminar
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</template>

<script>
    import axios from "axios";

    export default {
        name: "CountriesList",

        data() {
            return {
                countries: [

                ] 
            };
        },

        methods: {
            getCountries() {
                axios.get("https://localhost:7167/api/Country")
                    .then((response) => {
                        this.countries = response.data;
                    })
                    .catch((error) => {
                        console.error("Error al obtener países:", error);
                    });
            },

            deleteCountry(index) {
                this.countries.splice(index, 1);
            }
        },

        created: function () {
            this.getCountries();
        }
    }
</script>

<style lang="scss" scoped>
</style>
```
