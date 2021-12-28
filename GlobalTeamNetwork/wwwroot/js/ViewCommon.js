//List of common functions used in Views
//function waitSeconds(iMilliSeconds) {
//function digitsOnly(checkStr) {
//function decimalsOnly(checkStr) {
//function alphaOnly(checkStr) {
//function removeRow(evt) {
//function getCBhtml(bChecked, bDisabled) {
//function decodeHtml(html) {
//function changeSaveButton(changeTo, selCurr ) {

//Button type enum
const buttonType = {
    SAVECHANGES: 0,
    ADD: 1
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
