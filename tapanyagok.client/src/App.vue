<script setup>
 import DataTable from 'datatables.net-vue3'
 import DataTablesCore from 'datatables.net-bs5'

 DataTable.use(DataTablesCore);

 const columns = [
   { "data" : "nev" },
   { "data" : "energia" },
   { "data" : "feherje" },
   { "data" : "zsir" },
   { "data" : "szenhidrat" }
 ];

 const ajax = {
   url: 'http://localhost:5176/api/Tapanyagok',
   dataSrc : ''
 };

 const options = {
   language: {
     url: 'https://cdn.datatables.net/plug-ins/1.11.3/i18n/hu.json'
   },
 }

</script>

<template>
  <DataTable :columns="columns"
             :ajax="ajax"
             :options="options"
             class="table table-striped table-hover table-bordered">
    <thead>
      <tr>
        <th><strong>Név</strong></th>
        <th><strong>Energia</strong></th>
        <th><strong>Fehérje</strong></th>
        <th><strong>Zsír</strong></th>
        <th><strong>Szénhidrát</strong></th>
      </tr>
    </thead>
    <tbody class="table-group-divider"></tbody>
  </DataTable>
</template>

<style>
  @import 'datatables.net-bs5';
</style>
