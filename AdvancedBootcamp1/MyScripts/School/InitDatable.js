
loadSchools();

function loadSchools() {

    $("#datatable").DataTable(
        {
            ajax: {
                url: "/api/schools",
                type: "get",
                datatype: "json"
            },
            columns: [
                {
                    data: "Name", name: "Name", width: "50%", className: "bg-danger", render: function (value) {
                        let template = `<button class="btn btn-primary">${value}</button>`

                        return template;
                    }
                },
                {
                    data: "Description", name: "Description", width: "30%"
                },
                {
                    data: "Departments", name: "Departments", autowidth: true, render: function (deps) {
                        let template = `
                                                            <ul>
                                                                ${deps.map(x => '<li>' + x.Name + '</li>').join('')}
                                                            </ul>
                                                        `
                        return template;
                    }
                },
                {
                    data: "SchoolCategory", name: "SchoolCategory", width: "40%", render: function (cat) {
                        let template = `
                                                            ${cat.Name}
                                                        `
                        return template;
                    }
                },

                {
                    data: "SchoolId", name: "Actions", render: function (id) {

                        let template = `
                                                        <a class="EditBtn" href="#">Edit</a>
                                                        <a class="DeleteBtn"    onclick="MyDelete(${id})"     href="#">Delete</a>

                                                    `
                        return template;

                    }
                }

            ],
            processing: true,
            filters: true,

            language: {
                processing: `<div class="spinner-border text-dark" role="status">
                                                <span class="visually-hidden">Loading...</span>
                                            </div>`,
                emptyTable: "Den iparxoun data",
                zeroRecords: "Den iparxoun schools",
                infoFiltered: " - Total number of Schools: _MAX_",
                paginate: { first: "Mprosta", last: "Piso", next: "Epomeno", previous: "Proigoumeno" }
            },
            serverSide: false

        }

    );


}