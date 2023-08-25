
$(document).ready(function () {
        
    $('#div').hide();
    $('#div1').hide();
    $('#div2').hide();
    $('#div5').hide();

    GetSpecification();
});
    var Batchid = 0;
    //course dropdown binding-
    $('#Specification').on('change',function () {
        var id = $(this).val();

        $.ajax({
            url: '/Dashboard/Coursh?a=' + id,
            type: 'Get',
            dataType: 'json',
            cache: false,
            Data: {},
            success: function (result) {

                $.each(result, function (i, data) {
                    $('#Course').append('<Option value=' + data.course_Id + '>' + data.course_Name + '</Option>');
                });
            }
        });
    });
    //batch dropdown list
$('#Course').on('change',function () {
        $('#div').show();
        var id = $(this).val();
        $.ajax({
            url: '/Dashboard/Batch?a=' + id,
            type: 'Get',
            dataType: 'json',
            cache: false,
            Data: {},
            success: function (result) {

                $.each(result, function (i, data) {
                    $('#batch').append('<Option value=' + data.batch_Id + '>' + data.batch_Name + '</Option>');
                });
            }

        });
        //add list coursh

        $.ajax({
            url: '/Dashboard/Update_course?a=' + id,
            type: 'Get',
            dataType: 'json',
            cache: false,
            Data: {},
            success: function (result) {
                Batchid = result.fee;
                var data = "";
                $('#tblcources').empty();
                data = '<tr>'
                    + '<td><div class="col">' + result.course_Name + '</div></td>'
                    + '<td> <div class="col">' + result.fee + '</div></td>'
                    + '<td> <div class="col">' + (result.live_Class == true ? "Live Class" : "Not Live Class") + "<br/>" + (result.Recorded_Class == true ? "Recording Class" : "Not Recording Class") + "<br/>" + (result.Mock_Test == true ? "Mock Text" : "Not Not Mock Text") + "<br/>" + (result.Doubt_Solving_Session == true ? "Doubt Solving Session" : "Not Doubt Solving Session") + "<br/>" + (result.DPP == true ? "DDP" : "Not DDP") + '</div></td'
                    + '</tr>'
                $('#tblcources').append(data);

            }


        });
    });

    //for batch
    $('#batch').on('change', function () {
        $('#div1').show();
        var id = $(this).val();

        $.ajax({
            url: '/Dashboard/Update_batch?a=' + id,
            type: 'Get',
            dataType: 'json',
            cache: false,
            Data: {},
            success: function (del) {
                var data = "";
                $('#TBLSDS').empty();
                data = '<tr>'
                    + '<td><div class="col">' + del.batch_Name + '</div></td>'
                    + '<td><div class="col">' + del.course_Name + '</div></td>'
                    + '<td> <div class="col">' + del.batch_Timing + '</div></td>'
                    + '<td><div class="col">' + del.instructor_Name + '</div></td>'
                    + '<td><div class="col">' + del.seats + '</div></td>'
                    + '</tr>'

                $('#TBLSDS').append(data);
            }

        });



    });

    //buy course
    $('#btnby').click(function () {
        var s = $('#Specification').val();
        if (s == -1) {
            alert('please select course');
            return false;
        }
        if (s = "checked") {
        $('#div2').show();
        $('#DivPayment').removeClass('hide');

        var gst = (Batchid * 18 / 100) + Batchid;
        var per = "18%";
        var data = "";
        data = '<tr>'
            + '<td><div class="col">' + Batchid + '</div></td>'
            + '<td><div class="col">' + per + '</div></td>'
            + '<td><div class="col">' + gst + '</div></td>'
            + '</tr>'
            $('#tblby').append(data);
        }

    });



//specification
function GetSpecification() {
    $.ajax({
        url: '/Dashboard/Specification',
        type: 'GET',
        dataType: 'json',
        cache: false,
        data: {},
        success: function (result) {
            $('#Specification').val('');
            $.each(result, function (i, data) {
                $('#Specification').append('<Option value=' + data.spec_Id + '>' + data.spec_Name + '</Option>');
            });
        }
    });
}



//$('#payment').on('change', function () {
$('#Upi').click(function () {

        var obj = $('#payment').val();
        if (obj == "-1") {
            alert('please select option');
        }

        else {
            if (obj == "Upi") {
                $('#div5').show();
                $('#divupi').css('display', 'block');
                $('#divnet').css('display', 'none');
                $('#divcheque').css('display', 'none');
                $('#divcash').css('display', 'none');

            }
            else if (obj == "Cash") {
                $('#div5').show();
                $('#divupi').css('display', 'none');
                $('#divnet').css('display', 'none');
                $('#divcheque').css('display', 'none');
                $('#divcash').css('display', 'block');

            }
            else if (obj == "Banking") {
                $('#div5').show();
                $('#divupi').css('display', 'none');
                $('#divnet').css('display', 'block');
                $('#divcheque').css('display', 'none');
                $('#divcash').css('display', 'none');
            }

            else if (obj == "Cheque") {
                $('#div5').show();
                $('#divupi').css('display', 'none');
                $('#divnet').css('display', 'none');
                $('#divcheque').css('display', 'block');
                $('#divcash').css('display', 'none');

            }
        }
    });
    //save transaction on botton click--
$('#btnpayment').click(function () {
        let formData = {
            NETB_Bank_Account_No: $("#netaccount").val(),
            NETB_IFC_Cod: $("#netifc").val(),
            Upi_Id: $("#upi").val(),
            Checqe_No: $("#checkno").val(),
            Cheqe_Account_No: $("#chekaccount").val(),
            Total_Cash: $("#tcash").val()
        }
        console.log(formData)
        $.ajax({
            url: "/Dashboard/Get_transaction",
            type: "POST",
            data: formData,
            dataType:"JSON",
            success: function (response) {
                alert(response);
                //window.location.href ="/Dashboard/Student_insert_data"
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
   
  
});












//validation--

//$('#btnpayment').click(function () {

//    if (Getvalidation() == false) {

//        return false;
//    }

//});
//var NETB_Bank_Account_No, NETB_IFC_Cod, Upi_Id, Checqe_No, Cheqe_Account_No, Total_Cash;

//function Getvalidation() {

//    var isvalid = true;

//    NETB_Bank_Account_No = $('#netaccount').val();
//    NETB_IFC_Cod = $('#netifc').val();
//    Upi_Id = $('#upi').val();
//    Checqe_No = $('#checkno').val();
//    Cheqe_Account_No = $('#chekaccount').val();
//    Total_Cash = $('#tcash').val();

//    //condition
//    if (NETB_Bank_Account_No == "") {
//        $('#netb').text('please enter your contact..');
//        $('#netaccount').css('border-color', 'red');
//        $('#netaccount').focus();
//        isvalid = false;
//    }
//    else {
//        $('#netb').text('');
//        $('#netaccount').css('border-color', 'lightgray');
//    }

//    if (NETB_IFC_Cod == "") {
//        $('#idc').text('please enter your contact..');
//        $('#netifc').css('border-color', 'red');
//        $('#netifc').focus();
//        isvalid = false;
//    }
//    else {
//        $('#idc').text('');
//        $('#netifc').css('border-color', 'lightgray');
//    }


//    if (Upi_Id == "") {
//        $('#up').text('please enter your contact..');
//        $('#upi').css('border-color', 'red');
//        $('#upi').focus();
//        isvalid = false;
//    }
//    else {
//        $('#up').text('');
//        $('#upi').css('border-color', 'lightgray');
//    }

//    if (Checqe_No == "") {
//        $('#cn').text('please enter your contact..');
//        $('#checkno').css('border-color', 'red');
//        $('#checkno').focus();
//        isvalid = false;
//    }
//    else {
//        $('#cn').text('');
//        $('#checkno').css('border-color', 'lightgray');
//    }

//    if (Cheqe_Account_No == "") {
//        $('#ca').text('please enter your contact..');
//        $('#chekaccount').css('border-color', 'red');
//        $('#chekaccount').focus();
//        isvalid = false;
//    }
//    else {
//        $('#ca').text('');
//        $('#chekaccount').css('border-color', 'lightgray');
//    }
//    if (Total_Cash == "") {
//        $('#tc').text('please enter your contact..');
//        $('#tcash').css('border-color', 'red');
//        $('#tcash').focus();
//        isvalid = false;
//    }
//    else {
//        $('#tc').text('');
//        $('#tcash').css('border-color', 'lightgray');

//    }

//    return isvalid;
//}













