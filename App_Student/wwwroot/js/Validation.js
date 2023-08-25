//$(document).ready(function () {

//    alert('alert');
//});

//variable..

var  Contact_Number, Email_Address, Registration_Id, First_Name, Last_Name, Gender, Dob, Father_Name, Mother_Name, Password, Address, Zip_Code, City, State, Country, Role_Id;
   

//click call funcation
$('#btn_add_data').click(function () {

    if (Getvalidation() == false) {
        return false;
    }
});

//btn on change function

//$('#form_data').on('change', function () {

//    Getvalidation();
//});

function Getvalidation() {

    //globle variable
    var isvalid = true;

    Contact_Number = $('#contactnumber').val();
    Email_Address = $('#email').val();
    Registration_Id = $('#ragistrationid').val();
    First_Name = $('#fname').val();
    Last_Name = $('#lname').val();
    Gender = $('#gender').val();
    Dob = $('#dob').val();
    Father_Name = $('#fathername').val();
    Mother_Name = $('#mothername').val();
    Password = $('#password').val();
    Address = $('#address').val();
    Zip_Code = $('#zipcode').val();
    City = $('#cityDropdown').val();
    State = $('#stateDropdown').val();
    Country = $('#countryDropdown').val();
    Role_Id = $('#role').val();

    //contact number
    if (Contact_Number == "") {
        $('#scontactnumber').text('please enter your contact..');
        $('#contactnumber').css('border-color', 'red');
        $('#contactnumber').focus();
        isvalid = false;
    }
    else {
        $('#scontactnumber').text('');
        $('#contactnumber').css('border-color', 'lightgray');
    }
    //email addresh
    if (Email_Address == "") {
        $('#semail').text('plese enter your email');
        $('#email').css('border-color', 'red');
        $('#email').focus();
        isvalid = false;
    }
    else {
        $('#semail').text('');
        $('#email').css('border-color', 'lightgray');
    }
    //ragistration
    if (Registration_Id == "") {
        $('#sragistrationid').text('please enetr your ragistration id');
        $('#ragistrationid').css('border-color', 'red');
        $('#ragistrationid').focus();
        isvalid = false;
    }
    else {
        $('#sragistrationid').text('');
        $('#ragistrationid').css('border-color', 'lightgray');
    }

    //first name
    if (First_Name == "") {
        $('#sfname').text('please enter your first name');
        $('#fname').css('border-color', 'red');
        $('#fname').focus();
        isvalid = false;
    }
    else {
        $('#fname').text('');
        $('#sfname').css('border-color', 'lightgray')
    }
    //last name
    if (Last_Name == "") {
        $('#slname').text('please enter your first name');
        $('#lname').css('border-color', 'red');
        $('#lname').focus();
        isvalid = false;
    }
    else {
        $('#slname').text('');
        $('#lname').css('border-color', 'lightgray')
    }

    //gender
    if (Gender == "false") {
        $('#sgender').text('please checked Gender');
        $('#gender').css('border-color', 'red');
        $('#gender').focus();
        isvalid = false;
    }
    else {
        $('#sgender').text('');
        $('#gender').css('border-color', 'lightgray');
    }
    //dob
    if (Dob == "") {
        $('#sdob').text('please enter your DOB');
        $('#dob').css('border-color', 'red');
        $('#dob').focus();
        isvalid = false;
    }
    else {
        $('#sdob').text('');
        $('#dob').css('border-color', 'lightgray');
    }
    //father name
    if (Father_Name == "") {
        $('#sfathername').text('please enter your father name');
        $('#fathername').css('border-color', 'red');
        $('#fathername').focus();
        isvalid = false;
    }
    else {
        $('#sfathername').text('');
        $('#fathername').css('border-color', 'lightgray');
    }
    // mother name
    if (Mother_Name == "") {
        $('#smothername').text('please enter your mother name');
        $('#mothername').css('border-color', 'red');
        $('#mothername').focus();
        isvalid = false;
    }
    else {
        $('#smothername').text('');
        $('#mothername').css('border-color', 'lightgray');
    }
    // password
    if (Password == "") {
        $('#spassword').text('please enter your password');
        $('#password').css('border-color', 'red');
        $('#password').focus();
        isvalid = false;
    }
    else {
        $('#spassword').text('');
        $('#password').css('border-color', 'lightgray');
    }
    // addresh
    if (Address == "") {
        $('#saddress').text('please enter your addresh');
        $('#address').css('border-color', 'red');
        $('#address').focus();
        isvalid = false;
    }
    else {
        $('#saddress').text('');
        $('#address').css('border-color', 'lightgray');
    }

    // Zipcode
    if (Zip_Code == "") {
        $('#szipcode').text('please enter your Zip Code');
        $('#zipcode').css('border-color', 'red');
        $('#zipcode').focus();
        isvalid = false;
    }
    else {
        $('#szipcode').text('');
        $('#zipcode').css('border-color', 'lightgray');
    }
    // city
    if (City == "0") {
        $('#scityDropdown').text('please select your city');
        $('#cityDropdown').css('border-color', 'red');
        $('#cityDropdown').focus();
        isvalid = false;
    }
    else {
        $('#scityDropdown').text('');
        $('#cityDropdown').css('border-color', 'lightgray');
    }
    // state
    if (State == "0") {
        $('#sstateDropdown').text('please select your state');
        $('#stateDropdown').css('border-color', 'red');
        $('#stateDropdown').focus();
        isvalid = false;
    }
    else {
        $('#sstateDropdown').text('');
        $('#stateDropdown').css('border-color', 'lightgray')
    }

    // contry

    if (Country == "0") {
        $('#scountryDropdown').text('please select your country');
        $('#countryDropdown').css('border', 'red');
        $('#countryDropdown').focus();
        isvalid = false;

    }
    else {

        $('#scountryDropdown').text('');
        $('#countryDropdown').css('border','lightgray');
    }

    //role id
    if (Role_Id == "0") {
        $('#srole').text('please enter Role');
        $('#role').css('border-color', 'red');
        $('#role').focus();
        isvalid = false;
    }
    else {
        $('#srole').text('');
        $('#role').css('border-color', 'lightgray')
    }
    return isvalid;
}





