var dataTable;

$(function () {
    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        console.log('Error al cargar datos:', message);

        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: '¡Ups! Sucedió un problema al recopilar la información.',
        });
    };
    
    dataTable = $("#dataTable").DataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "lengthMenu": [1, 5, 10, 25, 50, 100],
        "pageLength": 5,
        "ajax": {
            url: "/Home/GetPhotos/",
            method: "GET",
        },
        "columns": [
            {
                "orderable": true,
                "render": function (data, type, row) {
                    return 'TITLE:';
                }
            },
            {
                "orderable": true,
                "render": function (data, type, row) {
                    return `${row.title}`;
                }
            },
            {
                "orderable": true,
                "render": function (data, type, row) {
                    
                    var imgElement = "<a href='" + row.url + "' target='_blank'>" +
                        "<img src='" + row.thumbnailUrl + "' width='100' height='100' />" +
                        "</a>";

                    return imgElement;
                }
            }
        ]
    });
})