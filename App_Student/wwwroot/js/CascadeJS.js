$(document).ready(function () {
    SelectedCountry = $('#countryDropdown').data('student-country');
    SeletedState = $('#stateDropdown').data('student-state');
    SeletedCity = $('#cityDropdown').data('student-city');
    Get_Country();

    $('#countryDropdown').change(function () {

        var id = $(this).val();
        $('#stateDropdown').val('');
        $.ajax({
            url: '/Dashboard/State?id=' + id,
            type: 'Get',
            dataType: 'json',
            cache: false,
            data: {},
            success: function (result) {

                $.each(result, function (i, data) {
                    var optionText = data.state_Name;
                    var optionValue = data.id;
                    var isSelected = '';
                    if (optionValue === SeletedState) {
                        isSelected = 'selected';
                        stateid = optionValue;
                    }

                    $('#stateDropdown').append('<option value=' + optionValue + ' ' + isSelected + '>' + optionText + '</option>');
                });
            }

        });
    });
    $('#stateDropdown').change(function () {

        var id = $(this).val();
        $('#cityDropdown').val('');
        $.ajax({
            url: '/Dashboard/City?id=' + id,
            type: 'Get',
            dataType: 'json',
            data: {},
            success: function (result) {
                $.each(result, function (i, data) {
                    var optionText = data.city_Name;
                    var optionValue = data.id;
                    var isSelected = '';
                    if (optionValue === SeletedCity) {
                        isSelected = 'selected';
                    }

                    $('#cityDropdown').append('<option value=' + optionValue + ' ' + isSelected + '>' + optionText + '</option>');
                });
            }

        });
    });
    
});

//country
var SelectedCountry = null;
var SeletedState = null;
var SeletedCity = null;
var countryid = 0;
var stateid= 0;
function Get_Country() {
    $.ajax({
        url: '/Dashboard/Country',
        type: 'Get',
        dataType: 'json',
        cache: false,
        data: {},
        success: function (result) {
            console.log(result);
            $.each(result, function (i, data) {
                var optionText = data.country_Name;
                var optionValue = data.id;
                var isSelected = '';
                if (optionValue === SelectedCountry) {
                    isSelected = 'selected';
                    countryid = optionValue;
                } 
                $('#countryDropdown').append('<option value=' + optionValue + ' ' + isSelected + '>' + optionText + '</option>');
            });

            Get_State();
        }
    });
}

//State
function Get_State() {   
        $.ajax({
            url: '/Dashboard/State?id=' + countryid,
            type: 'Get',
            dataType:'json',
            cache: false,
            data: {},
            success: function (result) {

                $.each(result, function (i, data) {
                    var optionText = data.state_Name;
                    var optionValue = data.id;
                    var isSelected = '';
                    if (optionValue === SeletedState) {
                        isSelected = 'selected';
                        stateid = optionValue;
                    }   

                    $('#stateDropdown').append('<option value=' + optionValue + ' ' + isSelected + '>' + optionText + '</option>');
                });

                Get_City();
            }

        });
}

//city
function Get_City() {
        $.ajax({
            url: '/Dashboard/City?id=' + stateid,
            type: 'Get',
            dataType: 'json',
            data: {},
            success: function (result) {
                $.each(result, function (i, data) {
                    var optionText = data.city_Name;
                    var optionValue = data.id;
                    var isSelected = '';
                    if (optionValue === SeletedCity) {
                        isSelected = 'selected';
                    }   

                    $('#cityDropdown').append('<option value=' + optionValue + ' ' + isSelected + '>' + optionText + '</option>');
                });
            }

        });
}


