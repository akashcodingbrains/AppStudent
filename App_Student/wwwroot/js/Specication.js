$(document).ready(function () {
    alert('ohhk');
});

$('#specificationbtn').click(function () {
    if (Getvalidation() === false) { 
        return false;
    }
});


// variable

var Spec_Name;

function Getvalidation() {
    var isvalid = true;
    // getdata
    Spec_Name = $('#specification').val();
    if (Spec_Name === "") {
        $('#erspecification').text('please enter your specification');
        $('#specification').css('border-color', 'red');
        $('#specification').focus();
        isvalid = false;
    } else {
        $('#erspecification').text('');
        $('#specification').css('border-color', 'lightgray');
    }
    return isvalid;
}
