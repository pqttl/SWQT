
function funcShowChartByConfig(strId, objConfig) {
    let chartStatus = Chart.getChart(strId); // <canvas> id
    if (chartStatus != undefined) {
        chartStatus.destroy();
        //chartStatus.options = config;
        //chartStatus.update('active');
    }

    let myLineChart = new Chart(document.getElementById(strId), objConfig);
}

function funcThietLapJSChoPVChooseTime() {

    voidSetupDatePickerForId('input.classInputDatepicker');

    $("#idAStartStatistic").on("click", function (event) {
        event.preventDefault();

        var jqoChild = $("div.container-fluid").children();
        if (jqoChild.length > 2) {
            jqoChild.slice(2).remove();
        }

        voidShowLoadingWithTitlePercent("Tải dữ liệu thống kê theo thời gian đã chọn", "40%");

        var arrayStrInput = [];
        arrayStrInput.push($("#idInputStartDate").val());
        arrayStrInput.push($("#idInputEndDate").val());

        var strUrl = $(this).attr("strInput");
        var strUrlPVToShow = "" + $(this).attr("strUrlPVToShow");

        $.ajax({
            type: 'GET',
            url: strUrl,
            traditional: true,
            data: { arrayStrInput: arrayStrInput },
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultJson) {
                if (resultJson.blnStatusJs == false) {
                    funcShowMessage(resultJson.strMess);
                    return;
                }


                $.ajax({
                    url: strUrlPVToShow,
                    success: function (resultJsonHtml) {
                        $("div.container-fluid").append(resultJsonHtml);

                        voidSetupDatePickerForId('input.classInputDatepicker');

                        $("#idInput1StartDate").datepicker('setDate', resultJson.strTimeStart2Week);
                        $("#idInput1EndDate").datepicker('setDate', resultJson.strTimeEnd2Week);

                        $("#idInput2StartDate").datepicker('setDate', resultJson.strTimeStart6Month);
                        $("#idInput2EndDate").datepicker('setDate', resultJson.strTimeEnd6Month);

                        $("#idInput3StartDate").datepicker('setDate', resultJson.strTimeStart6Month);
                        $("#idInput3EndDate").datepicker('setDate', resultJson.strTimeEnd6Month);

                        $("#idInput4StartDate").datepicker('setDate', resultJson.strTimeStart6Month);
                        $("#idInput4EndDate").datepicker('setDate', resultJson.strTimeEnd6Month);

                        funcThietLapJSChoPVManyChart();

                        $('#idDivStaticBackdropLivePopup').modal('hide');

                        setTimeout(function () {

                            $("#idAShowLineChart").click();

                        }, 200);
                    }
                });


            }
        });

    });

    $("div input.classInputRadioTime").on("change", function (event) {
        event.preventDefault();

        var strTitle = $(this).attr("title");
        var d = new Date;
        if (strTitle == "6" || strTitle == "12") {
            d = new Date(2023, 06, 30);
        }

        var datestring = StrDateddmmyyyy(d);

        var dateBeforeNMonth = new Date;
        if (strTitle == "6") {
            //dateBeforeNMonth = new Date(d.setMonth(d.getMonth() - 5));
            dateBeforeNMonth = new Date(2023, 01, 01);
        }
        if (strTitle == "12") {
            dateBeforeNMonth = new Date(d.setMonth(d.getMonth() - 11));
        }
        let strTenp = "01/"
            + ("0" + (dateBeforeNMonth.getMonth() + 1)).slice(-2) + "/" +
            dateBeforeNMonth.getFullYear();
        //strTenp = datestring;

        $("#idInputStartDate").datepicker('setDate', strTenp);
        $("#idInputEndDate").datepicker('setDate', datestring);

        var blnDisable = true;
        if (strTitle == "today") {
            blnDisable = false;
        }
        setDisableAllForIdAndChild(
            $(this).closest('div.divGroupboxMarginTop').find("div.classDiv2Datepicker").first(), blnDisable);

    });

}

function funcThietLapJSChoPVManyChart() {

    $("#idAShowLineChart").on("click", function (event) {
        event.preventDefault();

        var jqoDivMocThoiGian = $(this).closest('div.classDivMocThoiGian');

        var jqoDivOneChart = jqoDivMocThoiGian.siblings().first();
        if (jqoDivOneChart.hasClass("classDivOneChart")) {
            jqoDivOneChart.remove();
        }

        setDisableAllForIdAndChild(
            jqoDivMocThoiGian, true);

        voidShowLoadingWithTitlePercent("Hiển thị thống kê từ đầu tuần trước", "40%");

        var arrayStrInput = [];
        arrayStrInput.push($("#idInput1StartDate").val());
        arrayStrInput.push($("#idInput1EndDate").val());

        var strUrl = $(this).attr("strInput");
        var strUrlPVToShow = "" + $(this).attr("strUrlPVToShow");

        $.ajax({
            type: 'GET',
            url: strUrl,
            traditional: true,
            data: { arrayStrInput: arrayStrInput },
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultJson) {
                if (resultJson.blnStatusJs == false) {
                    funcShowMessage(resultJson.strMess);
                    return;
                }

                $.ajax({
                    url: strUrlPVToShow,
                    success: function (resultJsonHtml) {
                        jqoDivMocThoiGian.parent().prepend(resultJsonHtml);

                        let arrayName = JSON.parse(resultJson.strArrayNameJs);
                        let arrayQuantity = JSON.parse(resultJson.strArrayQuantityJs);
                        let arrayQuantitySang = JSON.parse(resultJson.strArrayQuantitySangJs);
                        let arrayQuantityChieu = JSON.parse(resultJson.strArrayQuantityChieuJs);

                        const config = {
                            type: 'line',
                            data: {
                                labels: arrayName,
                                datasets: [{
                                    label: 'A1',
                                    fill: false,
                                    data: arrayQuantity,
                                    borderWidth: 1,
                                    borderColor: 'rgba(13,110,253,255)',
                                    backgroundColor: 'rgba(13,110,253,255)'
                                }, {
                                    label: 'B2',
                                    fill: false,
                                    borderDash: [5, 5],
                                    hidden: false,
                                    data: arrayQuantityChieu,
                                    borderWidth: 1,
                                    borderColor: 'rgba(4,3,70,255)',
                                    backgroundColor: 'rgba(4,3,70,255)'
                                }, {
                                    label: 'C3',
                                    fill: true,
                                    hidden: false,
                                    data: arrayQuantitySang,
                                    borderWidth: 1,
                                    borderColor: 'rgba(246,228,173,255)',
                                    backgroundColor: 'rgba(246,228,173,255)'
                                }]
                            },
                            options: {
                                responsive: true,
                                maintainAspectRatio: false,
                                scales: {
                                    y: {
                                        beginAtZero: true
                                    }
                                },
                                plugins: {
                                    legend: {
                                        position: 'top',
                                    },
                                    title: {
                                        display: false,
                                        text: 'Tên biểu đồ'
                                    }
                                }
                            }
                        };

                        funcShowChartByConfig("idCanvasLineChart", config);

                        $('#idDivStaticBackdropLivePopup').modal('hide');

                        var jqoTemp = $("#idAShowBarChart");
                        if (jqoTemp.hasClass("disabledElement") == false) {

                            setTimeout(function () {

                                jqoTemp.click();

                            }, 200);
                        }

                    }
                });

            }
        });

    });
    
    $("#idAShowBarChart").on("click", function (event) {
        event.preventDefault();

        var jqoDivMocThoiGian = $(this).closest('div.classDivMocThoiGian');

        var jqoDivOneChart = jqoDivMocThoiGian.siblings().first();
        if (jqoDivOneChart.hasClass("classDivOneChart")) {
            jqoDivOneChart.remove();
        }

        setDisableAllForIdAndChild(
            jqoDivMocThoiGian, true);

        voidShowLoadingWithTitlePercent("Hiển thị thống kê 6 tháng gần nhất", "40%");

        var arrayStrInput = [];
        arrayStrInput.push($("#idInput2StartDate").val());
        arrayStrInput.push($("#idInput2EndDate").val());

        var strUrl = $(this).attr("strInput");
        var strUrlPVToShow = "" + $(this).attr("strUrlPVToShow");

        $.ajax({
            type: 'GET',
            url: strUrl,
            traditional: true,
            data: { arrayStrInput: arrayStrInput },
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultJson) {
                if (resultJson.blnStatusJs == false) {
                    funcShowMessage(resultJson.strMess);
                    return;
                }

                $.ajax({
                    url: strUrlPVToShow,
                    success: function (resultJsonHtml) {
                        jqoDivMocThoiGian.parent().prepend(resultJsonHtml);

                        let arrayName = JSON.parse(resultJson.strArrayNameJs);
                        let arrayQuantity = JSON.parse(resultJson.strArrayQuantityJs);
                        let arrayQuantitySang = JSON.parse(resultJson.strArrayQuantitySangJs);
                        let arrayQuantityChieu = JSON.parse(resultJson.strArrayQuantityChieuJs);

                        const config = {
                            type: 'bar',
                            data: {
                                labels: arrayName,
                                datasets: [{
                                    label: 'A1',
                                    fill: false,
                                    data: arrayQuantity,
                                    borderWidth: 2,
                                    borderRadius: 5,
                                    borderSkipped: false,
                                    borderColor: 'rgba(13,110,253,255)',
                                    backgroundColor: 'rgba(13,110,253,0.5)'
                                }, {
                                    label: 'B2',
                                    type: 'line',
                                    fill: false,
                                    borderDash: [5, 5],
                                    hidden: false,
                                    data: arrayQuantityChieu,
                                    borderWidth: 1,
                                    borderColor: 'rgba(4,3,70,255)',
                                    backgroundColor: 'rgba(4,3,70,255)'
                                }, {
                                    label: 'C3',
                                    type: 'line',
                                    fill: true,
                                    hidden: false,
                                    data: arrayQuantitySang,
                                    borderWidth: 1,
                                    borderColor: 'rgba(246,228,173,255)',
                                    backgroundColor: 'rgba(246,228,173,255)'
                                }]
                            },
                            options: {
                                responsive: true,
                                maintainAspectRatio: false,
                                scales: {
                                    y: {
                                        beginAtZero: true
                                    }
                                },
                                plugins: {
                                    legend: {
                                        position: 'top',
                                    },
                                    title: {
                                        display: false,
                                        text: 'Tên biểu đồ'
                                    }
                                }
                            }
                        };

                        funcShowChartByConfig("idCanvasBarChart", config);

                        $('#idDivStaticBackdropLivePopup').modal('hide');

                        var jqoTemp = $("#idAShowMultiPieChart");
                        if (jqoTemp.hasClass("disabledElement") == false) {

                            setTimeout(function () {

                                jqoTemp.click();

                            }, 200);
                        }

                    }
                });

            }
        });

    });
    
    $("#idAShowMultiPieChart").on("click", function (event) {
        event.preventDefault();

        var jqoDivMocThoiGian = $(this).closest('div.classDivMocThoiGian');

        var jqoDivOneChart = jqoDivMocThoiGian.siblings().first();
        if (jqoDivOneChart.hasClass("classDivOneChart")) {
            jqoDivOneChart.remove();
        }

        setDisableAllForIdAndChild(
            jqoDivMocThoiGian, true);

        voidShowLoadingWithTitlePercent("Hiển thị thống kê theo khách hàng", "40%");

        var arrayStrInput = [];
        arrayStrInput.push($("#idInput3StartDate").val());
        arrayStrInput.push($("#idInput3EndDate").val());

        var strUrl = $(this).attr("strInput");
        var strUrlPVToShow = "" + $(this).attr("strUrlPVToShow");

        $.ajax({
            type: 'GET',
            url: strUrl,
            traditional: true,
            data: { arrayStrInput: arrayStrInput },
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultJson) {
                if (resultJson.blnStatusJs == false) {
                    funcShowMessage(resultJson.strMess);
                    return;
                }

                $.ajax({
                    url: strUrlPVToShow,
                    success: function (resultJsonHtml) {
                        jqoDivMocThoiGian.parent().prepend(resultJsonHtml);

                        let arrayName = JSON.parse(resultJson.strArrayNameJs);
                        let arrayQuantity = JSON.parse(resultJson.strArrayQuantityJs);
                        let arrayColor = JSON.parse(resultJson.strArrayColorJs);

                        let arrayNameCenter = JSON.parse(resultJson.strArrayNameCenterJs);
                        let arrayColorCenter = JSON.parse(resultJson.strArrayColorCenterJs);
                        let arrayQuantityCenter = JSON.parse(resultJson.strArrayQuantityCenterJs);

                        let arrayNameAll = arrayName.concat(arrayName);

                        const config = {
                            type: 'pie',
                            data: {
                                //labels: arrayName,
                                datasets: [{
                                    labels: arrayName,
                                    data: arrayQuantity,
                                    backgroundColor: arrayColor
                                }, {
                                    labels: arrayNameCenter,
                                    data: arrayQuantityCenter,
                                    backgroundColor: arrayColorCenter
                                }]
                            },
                            options: {
                                responsive: true,
                                plugins: {
                                    tooltip: {
                                        callbacks: {
                                            label: function (context) {
                                                const labelIndex = context.dataIndex;
                                                return context.chart.data.datasets[context.datasetIndex].labels[labelIndex] + ': ' + context.formattedValue;
                                            }
                                        }
                                    }
                                }
                            }
                        };

                        $('#idDivStaticBackdropLivePopup').modal('hide');

                        funcShowChartByConfig("idCanvasMultiPieChart", config);

                        document.getElementById('idDivNoteColor').outerHTML = resultJson.strNoteColor;

                        var jqoTemp = $("#idAShowPolarAreaChart");
                        if (jqoTemp.hasClass("disabledElement") == false) {

                            setTimeout(function () {

                                jqoTemp.click();

                            }, 200);
                        }

                    }
                });

            }
        });

    });
    
    $("#idAShowPolarAreaChart").on("click", function (event) {
        event.preventDefault();

        var jqoDivMocThoiGian = $(this).closest('div.classDivMocThoiGian');

        var jqoDivOneChart = jqoDivMocThoiGian.siblings().first();
        if (jqoDivOneChart.hasClass("classDivOneChart")) {
            jqoDivOneChart.remove();
        }

        setDisableAllForIdAndChild(
            jqoDivMocThoiGian, true);

        voidShowLoadingWithTitlePercent("Hiển thị thống kê theo khách hàng", "40%");

        var arrayStrInput = [];
        arrayStrInput.push($("#idInput4StartDate").val());
        arrayStrInput.push($("#idInput4EndDate").val());

        var strUrl = $(this).attr("strInput");
        var strUrlPVToShow = "" + $(this).attr("strUrlPVToShow");

        $.ajax({
            type: 'GET',
            url: strUrl,
            traditional: true,
            data: { arrayStrInput: arrayStrInput },
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (resultJson) {
                if (resultJson.blnStatusJs == false) {
                    funcShowMessage(resultJson.strMess);
                    return;
                }

                $.ajax({
                    url: strUrlPVToShow,
                    success: function (resultJsonHtml) {
                        jqoDivMocThoiGian.parent().prepend(resultJsonHtml);

                        let arrayName = JSON.parse(resultJson.strArrayNameJs);
                        let arrayQuantity = JSON.parse(resultJson.strArrayQuantityJs);
                        let arrayColor = JSON.parse(resultJson.strArrayColorJs);

                        let arrayNameCenter = JSON.parse(resultJson.strArrayNameCenterJs);
                        let arrayColorCenter = JSON.parse(resultJson.strArrayColorCenterJs);
                        let arrayQuantityCenter = JSON.parse(resultJson.strArrayQuantityCenterJs);

                        let arrayNameAll = arrayName.concat(arrayName);

                        const config = {
                            type: 'polarArea',
                            data: {
                                labels: arrayNameCenter,
                                datasets: [{
                                    label: 'Số đơn',
                                    data: arrayQuantityCenter,
                                    backgroundColor: arrayColorCenter
                                }]
                            },
                            options: {
                                responsive: true,
                                plugins: {
                                    legend: {
                                        display: false
                                    }
                                }
                            }
                        };

                        $('#idDivStaticBackdropLivePopup').modal('hide');

                        funcShowChartByConfig("idCanvasPolarAreaChart", config);

                        document.getElementById('idDiv2NoteColor').outerHTML = resultJson.strNoteColor;

                        var strUrlSort = "" + $('#idDivSortMaxToMin').attr("title");
                        $('#idDivSortMaxToMin').load(strUrlSort);

                    }
                });

            }
        });

    });

}

$(document).ready(function () {

    $("ol li.breadcrumb-item.active ").on("click", function (event) {
        event.preventDefault();

        var jqoChild = $("div.container-fluid").children();
        if (jqoChild.length > 1) {
            jqoChild.slice(1).remove();
        }

        var strUrlPVToShow = "" + $(this).attr("strInput");

        $.ajax({
            url: strUrlPVToShow,
            success: function (resultJsonHtml) {
                $("div.container-fluid").append(resultJsonHtml);

                funcThietLapJSChoPVChooseTime();

                $("#strIdRadio").prop("checked", true);
                $("#strIdRadio").trigger("change");

            }
        });  
    });

    $("ol li.breadcrumb-item.active ").trigger("click");

});