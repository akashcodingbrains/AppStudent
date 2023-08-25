$(document).ready(function () {



//Add fields
var i = 1;
$("#btnAddField").click(function () {
    $("#table_data").append("<tr>"
        //+ "<td><input name='list_tbl_Qualifications[" + i + "].Student_Id' class='form-control' id='Student_Id" + i + "' />"
        //+ "<span class='text-danger'></span ></td>"
        + "<td><input name='list_tbl_Qualifications[" + i + "].Qualifiaction_Name' class='form-control' id='txtQualifiaction_Name" + i + "' />"
        + "<span class='text-danger'></span ></td>"
        + "<td><input name='list_tbl_Qualifications[" + i + "].University' class='form-control' id='txtUniversity" + i + "' />"
        + "<span class='text-danger' ></span ></td>"
        + "<td><input name='list_tbl_Qualifications[" + i + "].Term_Year' class='form-control' id='txtTerm_Year" + i + "' />"
        + "<span class='text-danger'></span ></td>"
        + "<td><input name='list_tbl_Qualifications[" + i + "].Completation_Year' class='form-control' id='txtCompletation_Year" + i + "' />"
        + "<span class='text-danger'></span ></td>"
        + "<td><input name='list_tbl_Qualifications[" + i + "].Percentage' class='form-control' id='txtPercentage" + i + "' />"
        + "<span class='text-danger'></span ></td>"
        + "<td><span id='row_delete" + i + "'><i class='fa fa-trash-o' style='font-size:24px'></i></span></td"
        + "</tr > ");
    i++;
});


});
$(document).on("click", "#btn_add_data", function () {

    var data = $('#form_data').serialize();

    $.ajax({
        method: "POST",
        url: "/Dashboard/Student_insert_data",
        data: data,
        dataType: "JSON",
        success: function (data) {
            window.location.href = "/Dashboard/Student_show_data";
        }
    });
});

//update add new row
var i = 1;
$(document).on("click", "#updatebtn", function () {
    $("#table_update_row").append(
        "<tr>" +
        //"<td><input name='list_tbl_Qualifications[" + i + "].Std_Qli_Id' class='form-control' id='Std_Qli_Id" + i + "' />" +
        //"<span class='text-danger'></span></td>" +
        //"<td><input name='list_tbl_Qualifications[" + i + "].Student_Id' class='form-control' id='Student_Id" + i + "' />" +
        //"<span class='text-danger'></span></td>" +
        "<td><input name='list_tbl_Qualifications[" + i + "].Qualifiaction_Name' class='form-control' id='txtQualifiaction_Name" + i + "' />" +
        "<span class='text-danger'></span></td>" +
        "<td><input name='list_tbl_Qualifications[" + i + "].University' class='form-control' id='txtUniversity" + i + "' />" +
        "<span class='text-danger'></span></td>" +
        "<td><input name='list_tbl_Qualifications[" + i + "].Term_Year' class='form-control' id='txtTerm_Year" + i + "' />" +
        "<span class='text-danger'></span></td>" +
        "<td><input name='list_tbl_Qualifications[" + i + "].Completation_Year' class='form-control' id='txtCompletation_Year" + i + "' />" +
        "<span class='text-danger'></span></td>" +
        "<td><input name='list_tbl_Qualifications[" + i + "].Percentage' class='form-control' id='txtPercentage" + i + "' />" +
        "<span class='text-danger'></span></td>" +
        /*"<td><a><i class='fa fa-trash-o' style='font-size:24px'></i></a>" + "<a><i class='fa fa-edit' style='font-size:24px'></i></a></td" +*/

        "</tr>"
    );
    i++;
});



//delete row of student insert
jQuery("body").on("click", "#row_delete", () => {
    jQuery("#removerowid").remove();
})