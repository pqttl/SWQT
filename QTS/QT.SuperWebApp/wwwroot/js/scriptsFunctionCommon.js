
function StrDateddmmyyyy(d) {
    var datestring = ("0" + d.getDate()).slice(-2) + "/"
        + ("0" + (d.getMonth() + 1)).slice(-2) + "/" +
        d.getFullYear();
    return datestring;
}

function setCollapseForId(jqoInput, blnHideCollapse) {
    jqoInput.removeClass("collapse");
    jqoInput.removeClass("show");

    if (blnHideCollapse == true) {

        jqoInput.addClass("collapse");
        return;
    }

    jqoInput.addClass("collapse");
    jqoInput.addClass("show");
}

function setDisableAllForIdAndChild(jqoInput, blnDisable) {
    if (blnDisable == true) {
        jqoInput.addClass("disabledElement");
    } else {
        jqoInput.removeClass("disabledElement");
    }

    jqoInput.find("*").prop('disabled', blnDisable);

}

function voidShowLoadingWithPercentOnly(strPercent) {

    document.getElementById("idStrPercent").innerHTML = strPercent;

    $("#idDivSpinnerPercent").collapse('show');
    $("#idDivMessage").collapse('hide');

    $("#idDivBtnLoading").collapse('hide');


    $("#idDivStaticBackdropLivePopup").modal('show');

}

function voidShowLoadingWithTitlePercent(strTitle, strPercent) {

    if (strTitle == "") {
        return;
    }

    document.getElementById("idStrTitle").innerHTML = strTitle;
    document.getElementById("idStrPercent").innerHTML = strPercent;

    $("#idDivSpinnerPercent").collapse('show');
    $("#idDivMessage").collapse('hide');

    $("#idDivBtnLoading").collapse('hide');


    $("#idDivStaticBackdropLivePopup").modal('show');

}

function funcShowMessage(strMess) {
    $("#idDivMessage").find("p").first().text(strMess);

    $("#idDivSpinnerPercent").collapse('hide');
    $("#idDivMessage").collapse('show');

    $("#idDivBtnLoading").collapse('show');
    $("#idButtonAccept").collapse('hide');

    $("#idDivStaticBackdropLivePopup").modal('show');

}

function funcShowMessageNoButton(strMess) {
    $("#idDivMessage").find("p").first().text(strMess);

    $("#idDivSpinnerPercent").collapse('hide');
    $("#idDivMessage").collapse('show');

    $("#idDivBtnLoading").collapse('hide');
    //$("#idButtonAccept").collapse('hide');

    $("#idDivStaticBackdropLivePopup").modal('show');

}

function funcShowConfirm(strTitle, strMess) {
    $("#idDivMessage").find("p").first().text(strMess);
    document.getElementById("idStrTitle").innerHTML = strTitle;

    $("#idDivSpinnerPercent").collapse('hide');
    $("#idDivMessage").collapse('show');

    $("#idDivBtnLoading").collapse('show');
    $("#idButtonAccept").collapse('show');

    $("#idDivStaticBackdropLivePopup").modal('show');

}

//https://codepen.io/vsfvjiuv-the-typescripter/pen/mdMeJwL
//https://uxsolutions.github.io/bootstrap-datepicker/?markup=input&format=&weekStart=&startDate=&endDate=&startView=0&minViewMode=0&maxViewMode=4&todayBtn=false&clearBtn=false&language=en&orientation=auto&multidate=&multidateSeparator=&keyboardNavigation=on&forceParse=on#sandbox

function voidSetupDatePickerForId(strId) {
    $("" + strId).datepicker({
        format: "dd/mm/yyyy",
        weekStart: 1,
        todayBtn: "linked",
        clearBtn: true,
        language: "vi",
        daysOfWeekHighlighted: "0",
        autoclose: true,
        todayHighlight: true
    });
}






function funcDownloadText(filename, text) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', filename);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}







