//List of common functions used in Views
//function waitSeconds(iMilliSeconds) {
//function digitsOnly(checkStr) {
//function decimalsOnly(checkStr) {
//function alphaOnly(checkStr) {
//function removeRow(evt) {
//function getCBhtml(bChecked, bDisabled) {
//function decodeHtml(html) {
//function changeSaveButton(changeTo, selCurr ) {
//function rowSort(tableBody, sortColumn, arrow) {

//Button type enum
const buttonType = {
    SAVECHANGES: 0,
    ADD: 1
}

//Sort Arrow enum
const sortArrow = {
    Up: '&#8593;',
    Down: '&#8595;'
}

//execute Sorting
$("body").on("click", ".columnSort", function () {

    //default value
    var newSort = sortArrow.Down;

    //clear all arrows, show one clicked
    $(".sortArrow").hide();
    $(':nth-child(1)', this).show();
    var currentSort = $(':nth-child(1)', this).html();
    if (currentSort.includes(decodeHtml(sortArrow.Down))) {
        $(':nth-child(1)', this).html(sortArrow.Up);
        newSort = sortArrow.Up;
    }
    else if (currentSort.includes(decodeHtml(sortArrow.Up))) {
        $(':nth-child(1)', this).html(sortArrow.Down);
    }
    //do the sort 
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

function waitSeconds(iMilliSeconds) {
    var counter = 0
        , start = new Date().getTime()
        , end = 0;
    while (counter < iMilliSeconds) {
        end = new Date().getTime();
        counter = end - start;
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
        const reg = new RegExp('^[A-Za-z]+$');
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
}
