$(document).ready(function () {

    alert('ohhk');
});


//variable
var Batch_Name, Course_Name, Batch_Timing, Instructor_Name, Seats;



//call function

$('#btnbatch').click(function () {

    if (Getvalidation() == false) {

        return false;
    }
});

function Getvalidation() {

    // variable
    var isvalid = true;


    //Get values of text box-

    Batch_Name = $('#batchname').val();
    Batch_Timing = $('#batchtiming').val();
    Instructor_Name = $('#instractorname').val();
    Seats = $('#seats').val();


    //name
    if (Batch_Name == "") {
        $('#erbatchname').text('please select your batch');
        $('#batchname').css('border-color', 'red');
        $('#batchname').focus();
        isvalid = false;
    }
    else {
        $('#erbatchname').text('');
        $('#batchname').css('border-color', 'lightgray');
    }

    if (Batch_Timing == "0") {
        $('#erbatchtiming').text('please select your batch');
        $('#batchtiming').css('border-color', 'red');
        $('#batchtiming').focus();
        isvalid = false;
    }
    else {
        $('#erbatchtiming').text('');
        $('#batchtiming').css('border-color', 'lightgray');
    }

    //fee
    if (Instructor_Name == "") {
        $('#erinstractorname').text('please enter instracture name');
        $('#instractorname').css('border-color', 'red');
        $('#instractorname').focus();
        isvalid = false;
    }
    else {
        $('#erinstractorname').text('');
        $('#instractorname').css('border-color', 'lightgray');
    }

   
    //
    if (Seats == "") {
        $('#erseats').text('please seat number');
        $('#seats').css('border-color', 'red');
        $('#seats').focus();
        isvalid = false;
    }
    else {
        $('#erseats').text('');
        $('#seats').css('border-color', 'lightgray');
    }

    return isvalid;


}