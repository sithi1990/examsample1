
$(document).ready(function () {
  
    $('#ShowModel11').click(function () {
        $.ajax({
            type: "GET",
            url: "/ExaminationManager/CreatePartialNew",
            datatype: "html",
            success: function (data) {
                $('#new_model1').empty();
                $('#new_model1').html(data);
                $('#myModal').modal();
            }
        });

    });
});