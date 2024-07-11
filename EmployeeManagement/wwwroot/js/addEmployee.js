$(document).ready(function () {
  loadDepartments();

  function loadDepartments() {
    $.ajax({
      url: '/api/departments',
      method: 'GET',
      success: function (data) {
        var departmentDropdown = $('#employeeDepartment');
        departmentDropdown.empty();
        $.each(data, function (index, department) {
          var option = `<option value="${department.id}">${department.depName}</option>`;
          departmentDropdown.append(option);
        });
      }
    });
  }

  $('#addEmployeeButton').click(function () {
    $('#employeeModal').show();
  });

  $('#saveEmployeeButton').click(function () {
    var employee = {
      no: $('#employeeNo').val(),
      name: $('#employeeName').val(),
      //age: $('#employeeAge').val(),
      //departmentId: $('#employeeDepartment').val(),
      //salary: $('#employeeSalary').val()
      age: parseInt($('#employeeAge').val(), 10), // Convert to integer
      departmentId: parseInt($('#employeeDepartment').val(), 10), // Convert to integer
      salary: parseFloat($('#employeeSalary').val()) // Convert to float
    };

    $.ajax({
      url: '/api/employees',
      method: 'POST',
      data: JSON.stringify(employee),
      contentType: 'application/json',
      success: function () {
        $('#employeeModal').hide();
        // Optionally, reload employees if needed
        // loadEmployees();
      },
      error: function (xhr, status, error) {
        alert('Error: ' + xhr.responseText);
      }
    });
  });

  $('#closeEmployeeModal').click(function () {
    $('#employeeModal').hide();
  });
});
