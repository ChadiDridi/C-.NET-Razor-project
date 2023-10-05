$(document).ready(function () {

});
function GetProducts() {
    $.ajax({
        url: '/Controllers/GetEmployers',
        type: 'get',
        datatype: 'json',
        contentType: 'applicaton/json;charset=utf-8',
        sucess: function (response) {
            if (response == null || response = undefined || response.length == 0){
        var object = '';
        object += <tr>;
object+=>'<td class="colspan="6">'+ 'Employer not avaiable'+ '</td>';
        object +=</tr >;
        $('#tblBody').html(object);
    }
else {
        var object = '';
        $.each(response, function (key, item) {
            object += '<tr>';
            object += '<td>' + item.EmployerName + '</td>';
            object += '<td>' + item.EmployerAddress + '</td>';
            object += '<td>' + item.EmployerPhone + '</td>';
            object += '<td>' + item.EmployerEmail + '</td>';
            object += '<td>' + item.Services + '</td>';
            object += '<td>  <a href="#" class="btn btn-danger btn-sm" onclick="Edit(' + item.EmployerId + ')">Edit</a> | <a href="#" class="btn btn-danger btn-sm" onclick="Delete(' + item.EmployerId + ')">Delete</a></td>';
        });

        $('tblBody').html(object);
    }
},
error: function() {
    alert("unable to load data");
}
});
}