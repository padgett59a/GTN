//List of common functions used in Views
//function waitSeconds(iMilliSeconds) {
//function digitsOnly(checkStr) {
//function decimalsOnly(checkStr) {
//function alphaOnly(checkStr) {
//function removeRow(evt) {
//function getCBhtml(bChecked, bDisabled) {
//function decodeHtml(html) {
//function changeSaveButton(changeTo, selCurr ) {
//function rowSort(tableBody, sortColumn, arrow) 
//function HandleError(e, tName) 
//function getCurrentSort()
//function setSortArrows(sortCol, pSortDir)
//function checkForNull(testStr)
//function phoneOnly(checkStr) 
//function digitsOnly(checkStr) 
//function trimDollar(inStr) 
//function trimDecimal(inStr) 
//function amountsOnly(checkStr) 
//function emailOnly(checkStr) 
//function emptyTrxDefaultPay() 
//function emptyMrxDefaultPay()
//function HandleError(e, keyedTableName, keyedRow) 
//function setUpSemesterDDL(elSemDD) 
//function setUpLangDDL(elLangDD) 
//function scrollToBottom()
//function setUpDdl(pArray, pDdl) 

// *** Location ***
//function initLocationAutocompletes() {
//function initLocationLists() {
//function validateLocationInput()
//function getLocationVal(idx)
// *** End Location ***

//function zeroPad(pVal, pLen)
//function removeTail(pStr)


//Address enum
const addressPart = {
    City: 0,
    State: 1,
    Country: 2
}

//Button type enum
const buttonType = {
    SAVECHANGES: 0,
    ADD: 1
}

const GTNErrors = {
    RKEY_VIOL: -2,
    SQL_ERROR: -99
}

const NOSELECTION = "??";
const REQUIRED = true;
const OPTIONAL = false;

//Sort Arrow enum
const sortArrow = {
    Up: '&#8593;',
    Down: '&#8595;'
}

//START multi select when mouse is down
var isMouseDown = false;
document.addEventListener('mousedown', function () {
    isMouseDown = true;
});
document.addEventListener('mouseup', function () {
    isMouseDown = false;
});
//drag through item check boxes to select/unselect
$(".itemCB").mouseover(function () {
    if (isMouseDown) {
        //if ($(this).is(':checked')) {
        //    $(this).prop('checked', false);
        //} else {
            $(this).prop('checked', true);
        //}
    }
});
//END multi select when mouse is down


function checkForNull(testStr) {
    var retVal;
    if (!testStr) {
        return "";
    }
    else {
        return testStr;
    }
}

//Check for default pay populated - TranslationSteps
function emptyTrxDefaultPay() {

    var emptyPay = false;
    $.ajax({
        type: "GET",
        url: '..\/admin/GetTranslationStepsJson',
        dataType: "json",
        async: false,
        success: function (trxSteps) {
            //alert(JSON.stringify(trxSteps));
            for (var key in trxSteps) {
                if (checkForNull(trxSteps[key].defaultPayDollars).length == 0) {
                    emptyPay = true;
                    break;
                }
            }
        }
    });
    return emptyPay;
}

//Check for default pay populated - MasteringSteps
function emptyMrxDefaultPay() {
    var emptyPay = false;
    $.ajax({
        type: "GET",
        url: '..\/admin/GetMasteringStepsJson',
        dataType: "json",
        async: false,
        success: function (mrxSteps) {
            for (var key in mrxSteps) {
                if (checkForNull(mrxSteps[key].defaultPayDollars).length == 0) {
                    emptyPay = true;
                    break;
                }
            }
        }
    });
    return emptyPay;
}

//On Page Search
$("body").on("input", "#txtSearch", function () {

    rBody = $('#tblMain tbody');
    var searchText = $('#txtSearch').val();
    var loopStop = false;
    $container = $('#divMain');

    if (searchText.length > 2) {

        //find matching rows
        $('#tblMain tbody tr').each(function () {

            //alert(searchText);
            $(this).find('td').each(function () {

                // skip the button Action button tds 
                if (!$(this).html().includes('editItem(')) {

                    if ($(this).html().toLowerCase().includes(searchText.toLowerCase())) {

                        //alert('found!');
                        loopStop = true;
                        return false;
                    }
                }
            });

            if (loopStop) {
                $scrollTo = $(this);
                $container.animate({
                    scrollTop: $scrollTo.offset().top - $container.offset().top + $container.scrollTop()
                });
                return false;
            }
        });

    }
    else {
        $container.animate({
            scrollTop: 0
        });
    }
});

//execute sort on passed qstring value
var setSort = (new URL(location.href)).searchParams.get('sort');

if (setSort != null) {
    var col2Sort = setSort.substring(0, setSort.length - 1)
    var asc = true;
    //alert(setSort.substring(setSort.length - 1, setSort.length).toUpperCase());
    if (setSort.substring(setSort.length - 1, setSort.length).toUpperCase() == "D") { asc = false; }
    var sortDir = asc ? sortArrow.Up : sortArrow.Down;
    setSortArrows($('.columnSort').eq(col2Sort), sortDir);
    rowSort($('#tblMain tbody'), col2Sort, sortDir);
}

//set arrows in UI
function setSortArrows(sortCol, pSortDir) {
    //clear all arrows, show one clicked
    $(".sortArrow").hide();
    $(':nth-child(1)', sortCol).show();
    //set the new sort arrow
    $(':nth-child(1)', sortCol).html(pSortDir);
}

//execute Sorting
$("body").on("click", ".columnSort", function () {

    var newSort = sortArrow.Down; //default
    //alternate arrows
    var currentSort = $(':nth-child(1)', this).html();
    //if both or down, change to up
    if (currentSort.includes(decodeHtml(sortArrow.Down))) {
        newSort = sortArrow.Up;
    }
    //do the sort
    setSortArrows($(this), newSort);
    rowSort($('#tblMain tbody'), $(this).index(), newSort);
});

function rowSort(tableBody, sortColumn, arrow) {

    var sortDirection = 1;
    var $tbody = tableBody;
    if (arrow == sortArrow.Down) { sortDirection = -1 }

    //see if we are sorting a text box
    var isCheckBox = $tbody.find('tr td:eq(' + sortColumn + ') input:checkbox').length > 0

    $tbody.find('tr').sort(function (a, b) {

        if (isCheckBox) {
            var tda = $(a).find('td:eq(' + sortColumn + ') input[type="checkbox"]:checked').length;
            var tdb = $(b).find('td:eq(' + sortColumn + ') input[type="checkbox"]:checked').length;
        }
        else {
            var tda = $(a).find('td:eq(' + sortColumn + ')').text().toLowerCase();
            var tdb = $(b).find('td:eq(' + sortColumn + ')').text().toLowerCase();
        }

        //Numeric Sort if both numbers
        if (!isNaN(tda) && !isNaN(tdb)) {
            return +tda < +tdb ? (-1 * sortDirection)
                : +tda > +tdb ? (1 * sortDirection)
                    : 0;
        }
        //Else Alpha sort
        else {
            return tda < tdb ? (-1 * sortDirection)
                : tda > tdb ? (1 * sortDirection)
                    : 0;
        }

    }).appendTo($tbody);
}

function getCurrentSort() {
    var sortSave = '';
    var sortCol = -1;
    var sortAsc = false;

    $(".sortArrow:visible").each(function (index, value) {
        //find the column that has sorting enabled if any
        if ($(value).html() == decodeHtml(sortArrow.Up) || $(value).html() == decodeHtml(sortArrow.Down)) {
            sortCol = $(value).parent().index();
            if ($(value).html() == decodeHtml(sortArrow.Up)) { sortAsc = true; }
        }
    });

    if (sortCol >= 0) {
        sortSave = '&sort=' + sortCol + (sortAsc ? 'A' : 'D');
    }
    return sortSave;
}

function waitSeconds(iMilliSeconds) {
    var counter = 0
        , start = new Date().getTime()
        , end = 0;
    while (counter < iMilliSeconds) {
        end = new Date().getTime();
        counter = end - start;
    }
}

function phoneOnly(checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp('^[0-9\\.\\-\\s]+$');
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function digitsOnly(checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp('^[0-9]+$');
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function trimDollar(inStr) {
    return inStr.replace('$&nbsp;', '').replace('$ ','');
}


function trimDecimal(inStr) {
    var trimStr = inStr + '00';
    var dotPlace = inStr.indexOf('.');
    if (dotPlace == -1) { return inStr + '.00' }
    else {
        return trimStr.substring(0, dotPlace + 3);
    }
    return trimStr;
}

//^\d{1,5}\.\d{0,2}$
function amountsOnly(checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp("^\\d{0,5}\\.\\d{0,2}$");
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

///^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\.)+([A-Za-z0-9]{2,4}|museum)$/;
function emailOnly (checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp("^[A-Za-z0-9._%+-]+@([A-Za-z0-9-]+\\.)+([A-Za-z0-9]{2,4})$");
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function decimalsOnly(checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp("^\\d\\.\\d{1,2}?$");
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function alphaOnly(checkStr) {
    if (checkStr.length == 0) {
        return true;
    }
    else {
        const reg = new RegExp('^[\\A-Za-z\\-\\s]+$');
        if (reg.test(checkStr)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function removeRow(evt) {
    $(evt).parent().parent().remove();
}

function getCBhtml(bChecked, bDisabled) {
    var cbCode = '<input type="checkbox"';
    if (bDisabled) { cbCode += ' disabled'; }
    if (bChecked) { cbCode += ' checked'; }
    cbCode += '>';
    return cbCode;
}

function decodeHtml(html) {
    var txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
}

//switch the button html
function changeSaveButton(changeTo, selCurr ) {
    //Replace action button
    var cancelButton = "<input type=\"button\" id=\"btnCancel\" value=\"Cancel\" />";
    var saveButton = "<input type=\"button\" data-id=\"" + selCurr + "\" id=\"btnSaveEdit\" value=\"Save Changes\" />";
    var addButton = "<input type=\"button\" id=\"btnAdd\" value=\"Add Another\" />";
    var template = "~~0~~&nbsp;&nbsp;&nbsp;&nbsp;"
    var btnHtml;
    switch (changeTo) {
        case buttonType.ADD:
            btnHtml = template.replace('~~0~~', addButton);
            break;
        case buttonType.SAVECHANGES:
            btnHtml = template.replace('~~0~~', saveButton) + cancelButton;
            break;
    }
    $('#tdBtnCell').html(btnHtml);
    $('#tdBtnCell').attr("nowrap", "nowrap");
}

//Note: keyedTableName MUST exactly match the table to query for foreign keyed tables
function HandleError(e, keyedTableName, keyedRow) {
    switch (e) {
        case GTNErrors.RKEY_VIOL:

            var fkTables;

            //Get names of FK tables
            $.ajax({
                type: "POST",
                url: '../GTNCommon\/GetFKTablesJson',
                dataType: "json",
                data: JSON.stringify(keyedTableName),
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    fkTables = response;
                }
            });

            //could be more than one
            var fkTableStr = "";
            for (var key in fkTables) {
                fkTableStr += fkTables[key].keyedTable + " and ";
                if (fkTableStr.substring(0, 3) == "XXX") {
                    alert("Please contact your system administrator. [HandleError]: Passed table '" + keyedTableName + "' does not exist.");
                    return;
                }
            };
            fkTableStr = fkTableStr.substring(0, fkTableStr.length - 5);
            alert("You must delete all " + fkTableStr + " records referencing '" + keyedRow + "' before removing this record. Please try again.");
            break;

        default:
            alert("A data base error has occurred. Please contact the System Administrator.");
            break;
    }
}

function setUpSemesterDDL(elSemDD, pBoolAll = true) {

    //Set up Semester drop down
    $.ajax({
        type: "GET",
        url: '../Cores\/GetSemestersJson',
        dataType: "json",
        async: false,
        success: function (response) {
            semesters = response;
        }
    });

    //set up Semester drop down code
    if (pBoolAll) {
        $(elSemDD).append($('<option>', {
            value: '??',
            text: 'All'
        }));
    }

    for (var key in semesters) {
        $(elSemDD).append($('<option>', {
            value: semesters[key].SemesterCode,
            text: semesters[key].SemesterName
        }));
    }
    return semesters; //often not needed
}

function setUpLangDDL(elLangDD) {

    //Set up Language drop down
    $.ajax({
        type: "GET",
        url: '../Admin\/GetLanguagesJson',
        dataType: "json",
        async: false,
        success: function (response) {
            languages = response;
        }
    });
    //set up Language drop down code
    for (var key in languages) {
        $(elLangDD).append($('<option>', {
            value: languages[key].langID,
            text: languages[key].LangName
        }));
    }
    return languages;
}

function scrollToBottom() {
    $("html, body").animate({ scrollTop: $(document).height() }, 1000);
    if ($("#divMain").length > 0) {
        $("#divMain").animate({ scrollTop: $('#divMain')[0].scrollHeight }, 1000);
    }
}

function setUpDdl(pArray, pDdl) {
    //pDdl passed as a string
    for (i = 0; i < pArray.length; i++) {
        $(pDdl).append($('<option>', {
            value: i,
            text: pArray[i]
        }));
    }
}

// *** Location ***
let cities = new Array();
let states = new Array();
let countries = new Array();
let cityVal = "";
let stateVal = "";
let countryVal = "";

function initLocationLists () {

    // Get locations lists
    $.ajax({
        type: "GET",
        url: '../Persons\/GetLocationsJson',
        dataType: "json",
        async: false,
        success: function (response) {
            locations = response;
        }
    });

    locations.forEach(loc => {
        if (!cities.includes(loc.city)) {
            cities.push(loc.city);
        }
        if (!states.includes(loc.state)) {
            states.push(loc.state);
        }
        if (!countries.includes(loc.country)) {
            countries.push(loc.country);
        }
    });
}

function initLocationAutocompletes() {
    $("#ddlCities").autocomplete({
        source: cities
    });
    $("#ddlStates").autocomplete({
        source: states
    });
    $("#ddlCountries").autocomplete({
        source: countries
    });
}

//on change set up the location values
$('#ddlCities').on('autocompleteselect', function (e, ui) {
    cityVal =  ui.item.value;
});
$('#ddlStates').on('autocompleteselect', function (e, ui) {
    stateVal = ui.item.value;
});
$('#ddlCountries').on('autocompleteselect', function (e, ui) {
    countryVal = ui.item.value;
});

function validateLocationInput(pRequired) {

    //if any entered, all must be entered
    //because of autocomplete, could be a selection or a typed in value
    let cityValue = getLocationVal(addressPart.City);
    let stateValue = getLocationVal(addressPart.State);
    let countryValue = getLocationVal(addressPart.Country);

    if (pRequired) {
        if (cityValue.length === 0 || stateValue.length === 0 || countryValue.length === 0) {
            alert("Please fill all location values before proceeding");
            return false;
        }
        else {
            return true;
        }
    }
    else {

        if ((cityValue.length > 0 || stateValue.length > 0 || countryValue.length > 0)
            && (cityValue.length === 0 || stateValue.length === 0 || countryValue.length === 0)) {
            alert("Please fill all location values before proceeding");
            return false;
        }
        else {
            return true;
        }
    }
}

//because of autocomplete, could be a selection or a typed in value
function getLocationVal(idx) {
    let retVal = '';
    switch (idx) {
        case addressPart.City:
            //note: prefer the ddl values over the autocomplete control values
            retVal = $('#ddlCities').val().trim().length === 0 ? cityVal.trim() : $('#ddlCities').val().trim();
            break;
        case addressPart.State:
            retVal = $('#ddlStates').val().trim().length === 0 ? stateVal.trim() : $('#ddlStates').val().trim();
            break;
        case addressPart.Country:
            retVal = $('#ddlCountries').val().trim().length === 0 ? countryVal.trim() : $('#ddlCountries').val().trim();
            break;
    }
    //alert(idx + ': ' + retVal)
    return retVal;
}

function clearLocationAutocompletes() {
    $('.locationSet').autocomplete('close').val('');
}

// *** End Location ***


// pLen is the total length of zero padded return value
function zeroPad(pVal, pLen) {
    while (pVal.length < pLen) {
        pVal = '0' + pVal;
    }
    return pVal;
}

function removeTail(pStr) {
    return pStr.substring(0, pStr.length - 1);
}
