
$(document).ready(function () {

    $("tr td div a.classADelete").on("click", function (event) {
        event.preventDefault();

        var strId = $(this).attr("strId");
        $('#idButtonAccept').attr('strId', strId);

        var strUrlDelete = $(this).attr("strUrlDelete");
        $('#idButtonAccept').attr('strUrlDelete', strUrlDelete);

        funcShowConfirm("XÓA BÀI VIẾT", "Bạn chắc chắn muốn thực hiện thao tác này?");

        $("#idButtonAccept").on("click", function (event) {
            event.preventDefault();

            voidShowLoadingWithPercentOnly("40%");

            var strId = $(this).attr("strId");

            var arrayStrInput = [];
            arrayStrInput.push(strId);

            var strUrl = $(this).attr("strUrlDelete");

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

                    funcShowMessageNoButton(resultJson.strMess);

                    setTimeout(function () {

                        location.reload();

                    }, 2000);

                }
            });

        });

    });

});
