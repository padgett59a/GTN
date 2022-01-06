﻿//List of common functions used in Views
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
