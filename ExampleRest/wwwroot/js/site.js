var dataTable;

$(function () {
    
    dataTable = $("#dataTable").DataTable({
        "processing": true,
        "serverSide": true,
        "searching": true,
        "pageLength": 10,
        "ajax": {
            url: "/Home/GetPhotos/",
            method: "GET",
        },
        "columns": [
            {
                "orderable": true,
                "render": function (data, type, row) {
                    /*return `<a href="#" onclick="BuscarContenedor('${row.contenedor}', ${row.idContenedor})">${row.contenedor}</a>`;*/
                    return 'campo 1';
                }
            },
            {
                "orderable": true,
                "render": function (data, type, row) {
                    /*return formatearFecha(row.fechaEstimacion)*/
                    return 'campo 2';
                }
            },
            {
                "orderable": true,
                "render": function (data, type, row) {
                    //if (row.estadoManto == 'Aceptado' && row.currentRoleUser == 'técnico') {
                    //    return `<button class="btn btn-danger text-light" onclick="IniciarMantenimiento(${row.idMantenimiento})" >Trabajando</button>`;
                    //}
                    //if (row.estadoManto == 'Iniciado' && row.currentRoleUser == 'técnico') {
                    //    return `<button class="btn btn-primary text-light" onclick="FinalizeMantenimiento(${row.idMantenimiento})" >Finalizar</button>`;
                    //}
                    //if (row.estadoManto == "Pendiente" && row.currentRoleUser == 'jefatura_mantenimiento') {
                    //    return `<button class="btn btn-success text-light" onclick="AceptarMantenimiento(${row.idMantenimiento})" >Aceptar</button>`;
                    //}

                    return 'campo 3';
                }
            }

        ]
    });

    //$("#BuscarMantenimiento").on('keyup', function () {
    //    var texto = $(this).val();
    //    tableMantenimiento.search(texto).draw();
    //});

    //$('#MantenimientoPatios').on('change', function () {
    //    tableMantenimiento.search('').draw();
    //});
})