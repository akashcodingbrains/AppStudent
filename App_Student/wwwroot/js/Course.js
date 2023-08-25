
//variable
var Course_Name, Fee;


//Get values of text box-

Course_Name = $('#coursename').val();
Fee = $('#fee').val();


//call function

$('#btncoursh').click(function () {

    if (Getvalidation() == false) {

        return false;
    }
});

function Getvalidation() {

    // variable
    var isvalid = true;

    //name

    if (Course_Name == "") {
        $('#ercoursename').text('please enter your course name');
        $('#coursename').css('border-color', 'red');
        $('#coursename').focus();
        isvalid = false;
    }
    else {
        $('#ercoursename').text('');
        $('#coursename').css('border-color', 'lightgray');
    }

    //fee
    if (Fee == "") {
        $('#erfee').text('please enter your fee');
        $('#fee').css('border-color', 'red');
        $('#fee').focus();
        isvalid = false;
    }
    else {
        $('#erfee').text('');
        $('#fee').css('border-color', 'lightgray');
    }




    return isvalid;


}
//variable
var Course_Name, Fee;




//call function

$('#btncoursh').click(function () {

    if (Getvalidation() == false) {

        return false;
    }
});

function Getvalidation() {

    // variable
    var isvalid = true;

    //Get values of text box-
    Course_Name = $('#coursename').val();
    Fee = $('#fee').val();

    //name
    if (Course_Name == "") {
        $('#ercoursename').text('please enter your course name');
        $('#coursename').css('border-color', 'red');
        $('#coursename').focus();
        isvalid = false;
    }
    else {
        $('#ercoursename').text('');
        $('#coursename').css('border-color', 'lightgray');
    }

    //fee
    if (Fee == "") {
        $('#erfee').text('please enter your fee');
        $('#fee').css('border-color', 'red');
        $('#fee').focus();
        isvalid = false;
    }
    else {
        $('#erfee').text('');
        $('#fee').css('border-color', 'lightgray');
    }




    return isvalid;


}