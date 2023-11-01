function MyDelete(MyId) {
    var settings = {
        "url": "https://localhost:44318/api/Schools/" + MyId,
        "method": "DELETE",
        "timeout": 0,
    };

    $.ajax(settings).done(function (response) {

        $("#datatable").dataTable().fnDestroy();
        loadSchools();
    });



}