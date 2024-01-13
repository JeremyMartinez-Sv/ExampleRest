var dataTable;

$(function () {
    
    dataTable = $("#dataTable").DataTable({
        "processing": true,
        "serverSide": true,
        "searching": false,
        "pageLength": 10,
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
                    var imageSize = "width='100' height='100'"; 
                    
                    var imgElement = "<img src='" + row.thumbnailUrl + "' " + imageSize + " />";
                    
                    return imgElement;
                }
            }

        ]
    });
})