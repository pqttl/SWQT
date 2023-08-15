
$(document).ready(function () {

    document.getElementById("idADownload").addEventListener("click", function (event) {
        event.preventDefault();

        // Generate download of hello.txt file with some content
        var text = document.getElementById("idTextareaScript").value;

        var dt = new Date();
        var yyyy = dt.getFullYear().toString();
        var mm = (dt.getMonth() + 1).toString(); // getMonth() is zero-based
        var dd = dt.getDate().toString();
        var strDate = yyyy + " " + (mm[1] ? mm : "0" + mm[0]) + " " + (dd[1] ? dd : "0" + dd[0]);
        //var strDate = dt.getFullYear() + "" + (dt.getMonth() + 1) + "" + dt.getDate();
        var strTime = dt.getHours() + "h" + dt.getMinutes() + "m" + dt.getSeconds();
        var filename = "scriptAhk " + strDate + " " + strTime +".ahk";
        filename = "WindowAutoHotkeyScript.ahk";

        funcDownloadText(filename, text);
    }, false);

    $("div a.classABtnHide").on("click", function (event) {
        event.preventDefault();

        //$(this).closest('td').find("div pre.preMaxHeight200").collapse('show');
        //$(this).closest('td').find("div pre.preMaxHeight200").collapse('toggle');

        //$(this).closest('td').find("div pre.preMaxHeight200").each(function (intIndex) {
        //    //console.log(intIndex + ": " + $(this).attr("title"));
        //    //strOutput += "" + $(this).attr("title");
        //    var blnVisible = $(this).is(":visible");
        //    if (blnVisible == true) {
        //        //$(this).collapse('show');
        //        $(this).collapse('toggle');
        //        continue;
        //    }
        //});

        var objListTemp = $(this).closest('td').find("div pre.preMaxHeight200");
        var blnVisible = objListTemp.first().is(":visible");
        if (blnVisible == true) {
            objListTemp.collapse('hide');
            $(this).closest('td').find("div a.classABtnShow").first().collapse('show');
            $(this).collapse('hide');
        }

    });
    
    $("div a.classABtnShow").on("click", function (event) {
        event.preventDefault();

        //$(this).closest('td').find("div pre.preMaxHeight200").collapse('show');
        //$(this).closest('td').find("div pre.preMaxHeight200").collapse('toggle');
        //$(this).closest('td').find("div pre.preMaxHeight200").collapse('toggle');

        var objListTemp = $(this).closest('td').find("div pre.preMaxHeight200");
        var blnVisible = objListTemp.first().is(":visible");
        if (blnVisible == false) {
            objListTemp.collapse('show');
            $(this).closest('td').find("div a.classABtnHide").first().collapse('show');
            $(this).collapse('hide');
        }

    });
    
    $("#idAHideAll").on("click", function (event) {
        event.preventDefault();

        $(this).closest('div.card').find("a.classABtnHide").click();

    });
    
    $("#idAShowAll").on("click", function (event) {
        event.preventDefault();

        $(this).closest('div.card').find("a.classABtnShow").click();

    });
    
    $("#idAMatchCode").on("click", function (event) {
        event.preventDefault();

        var strOutput = "";
        $('#infoTable tbody tr td div p').each(function (intIndex) {
            //console.log(intIndex + ": " + $(this).attr("title"));

            var objTemp = $(this).closest('td').find("div input.classInputCheckboxSuDung").first();
            var blnChecked = false;
            blnChecked = objTemp.is(':checked');
            if (blnChecked == false) {
                return;
            }

            strOutput += "" + $(this).attr("title");
        });

        $("#idDivScriptOutput").collapse('show');

        $("#idTextareaScript").val(strOutput);
        $("#idTextareaScript").trigger("input");

        $("#idDivButtonDownload").collapse('show');

        setTimeout(function () {

            $("#idADownload").focus();

        }, 200);

    });

    //$("#idACollapseCode").on("click", function (event) {
    //    event.preventDefault();

    //    $("#idADownload").collapse('toggle');
    //    $("#idDivScriptOutput").collapse('toggle');

    //});

    $('#infoTable tbody tr td input[type=radio]').on('change', function (event) {
        event.preventDefault();

        //var index = $("#infoTable tbody tr").index($(this).parent(".classTrMultitext"));
        //var index = $(this).parent(".classTrMultitext").index("#infoTable tbody tr");
        //var mm = $(this);
        //var mmh = mm.parentsUntil("tbody");
        //var index = mmh.index();
        //console.log("index la " + index);

        //var rowIndex = $('#infoTable tbody tr').index($(this).closest('tr'));
        //console.log("index la " + rowIndex);

        //var rowIndex2 = $('#infoTable tbody tr').index($(this).closest('.classTrMultitext'));
        //console.log("index la " + rowIndex2);

        //var rowIndex3 = $('#infoTable tbody tr td div.classDivRadioButton').index($(this).closest('.classDivRadioButton'));
        //console.log("index la " + rowIndex3);

        var strCode = $(this).closest('.classDivRadioButton').find("pre code").first().text();
        //console.log("val la " + strCode);

        $(this).closest('td').find("div p").first().attr("title", strCode);
    });

    //$(window).on("load", function () {

    //    $("#idADownload").collapse('hide');
    //    $("#idDivScriptOutput").collapse('hide');

    //});

    //setTimeout(function () {

    //    $("#idACollapseCode").click();

    //    $("#idADownload").collapse('toggle');
    //    $("#idDivScriptOutput").collapse('toggle');

    //}, 1000);

    //$(window).load(function () {

    //    $("#idADownload").collapse('hide');
    //    $("#idDivScriptOutput").collapse('hide');

    //});

    setTimeout(function () {

        $("#idAHideAll").click();

    }, 200);

});
