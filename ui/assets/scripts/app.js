$(function() {
    $("#add-employee-button").on("click", function(event) {
        event.preventDefault();
        var firstName = $("#employeeFirstName").text();
        var lastName = $("#employeeFirstName").text();
        var request = JSON.stringify({
            firstName: firstName,
            lastName: lastName
        });

        $.ajax({
            type: "POST",
            url: 'http://localhost:55492/api/employees',
            data: request,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: appendEmployee
        });
    });
});

function appendEmployee(response) {
    var template = Handlebars.templates["employee.hbs"];
    var markup = template(response);
    var employee = $(markup);
    $("#employees-list").append(employee);
    // enable validation for the added form
    var url = "http://localhost:55492/api/employees/" + response.id + "/dependents";

    var btn = employee.find(".add-dependent-button").first();
    btn.on("click", function(event) {
        event.preventDefault();

        var request = {
            employeeId: employee.find("span.employee-id").text(),
            firstName: employee.find("input.first-name").text(),
            lastName: employee.find("input.last-name").text()
        };
        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(request),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                appendDependent(data, employee);
            }
        });
    });
}

function appendDependent(response, employee) {
    var template = Handlebars.templates["dependent.hbs"];
    var markup = template(response);
    var dependentList = employee.find(".dependent-list").first();
    dependentList.append(markup);
    var annual = employee.find(".employee-annual-benefits-cost ").first();
    var paycheck = employee.find(".employee-per-paycheck-benefits-cost ").first();
    annual.text(response.employeeAnnualBenefitsCost);
    paycheck.text(response.employeeBenefitsCostPerPaycheck);
}
