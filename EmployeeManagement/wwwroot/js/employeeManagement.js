$(document).ready(function () {
  loadEmployees();

  function loadEmployees() {
    $.ajax({
      url: '/api/employees',
      method: 'GET',
      success: function (data) {
        console.log(data);  // Log the data to inspect the structure
        var employeeTableBody = $('#employeeTable tbody');
        employeeTableBody.empty();
        $.each(data, function (index, employee) {
          console.log(employee);  // Log each employee to inspect the structure
          var row = `<tr>
                        <td>${employee.id}</td>
                        <td>${employee.no}</td>
                        <td>${employee.name}</td>
                        <td>${employee.age}</td>
                        <td>${employee.departmentName}</td>
                        <td>${employee.salary}</td>
                    </tr>`;
          employeeTableBody.append(row);
        });
      }
    });
  }
});
