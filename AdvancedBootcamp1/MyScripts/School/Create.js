$(document).ready(function () {

    $("#categoryform").validate(
        {
            rules: {
                //Name: { required: true },
                //Description: { required: true },
                //SchoolCategoryId: { required: true }
            },
            messages: {
                //Name: "Prepei na doseis onoma",
                //Description: "Dose description",
            },
            submitHandler: function (e) {
                //Ajax Logic

                let RequestCls = {
                    Name: $("#SchoolName").val(),
                    Description: $("#SchoolDescription").val(),
                    DepsId: $("#Departments").val(),
                    CatId: $("#SchoolCategories").val()
                }

                console.log(RequestCls);

                let UrlApi = '/api/Schools'

                $.ajax({
                    type: "Post",
                    url: UrlApi,
                    data: JSON.stringify(RequestCls),
                    headers: {
                        "Content-Type": "application/json"
                    },
                    success: function (response) {

                        $("#datatable").dataTable().fnDestroy();
                        loadSchools();


                    },
                    error: function (xhr) {

                    }
                });






            }
        }

    )

});