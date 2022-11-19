if (window.Hemanth === undefined) {
    window.Hemanth = {};
}

if (window.Hemanth.WebGrab === undefined) {
    Hemanth.WebGrab = (function () {

        var init = function () {
            $("#URLFrom").validate({
                rules: {
                    UrlInput: "required"
                },
                messages: {
                    UrlInput: "Please enter valid URL"
                }
            });

            $("#FetchBtn").on("click", function (evt) {
                evt.preventDefault();
                resetContent();
                readValue();
            });
        }

        var readValue = function () {
            var isValid = $("#URLFrom").valid();
            if (isValid) {
                $("#ContentDisplay").addClass("invisible")
                $("#Spinner").removeClass("invisible");

                var url = $("#UrlInput").val();
                var params = { "": url };
                ApiAsync("/api/WebGrabApi", "LoadUrl", params, function (jsonData) {
                    displayResponse(jsonData);
                });
            }
        }

        var displayResponse = function (jsonRes) {
            if (jsonRes !== null) {

                //carousel
                var imageUrls = jsonRes.ImageUrls;
                var imgCarousalHtml = "";
                $.each(imageUrls, function (index, image) {
                    var imgClass = index == 0 ? "active" : "";
                    imgCarousalHtml += '<div class="carousel-item ' + imgClass + '"><img src="' + image + '" class="mx-auto d-block"/></div>';
                });
                $("#CaraousalDisplay").html(imgCarousalHtml);

                var myCarousel = document.querySelector('#carouselExampleControls')
                var carousel = new bootstrap.Carousel(myCarousel, {
                    interval: 2000,
                    wrap: false,
                    ride: true
                });

                //Chart
                var words = jsonRes.TopWords;
                var c3Data = [];
                var chartLabels = [];
                var chartData = [];
                chartData.push("Count");                
                $.each(words, function (index, word) {
                    chartLabels.push(word.Word);
                    chartData.push(word.WordCount);

                    var curData = [word.Word, word.WordCount];
                    c3Data.push(curData);
                });

                var chart = c3.generate({
                    bindto: '#chart',
                    data: {
                        columns: [chartData],
                        type: 'bar'
                    },
                    axis: {
                        x: {
                            type: 'category',
                            categories: chartLabels
                        }
                    },
                    legend: {
                        hide: true
                    },                   
                    tooltip: {
                        grouped: false
                    }
                });

                //Display Words Count
                $("#TotalWords").html(jsonRes.AllWordsCount);

                //All Words Count display
                var allWords = jsonRes.AllWords;
                var allWordsHtml = "";
                $.each(allWords, function (index, word) {
                    allWordsHtml += "<li>" + word.Word + " : " + word.WordCount + "</li>";
                });
                $("#AllWordsCount").html(allWordsHtml);

                $("#ContentDisplay").removeClass("invisible");
                $("#Spinner").addClass("invisible");
            }
            else {
                $("#Spinner").addClass("invisible");
                $("#ErrorSection").removeClass("invisible")
            }
        }


        var ApiAsync = function (srvcUrl, pageMethod, parameters, ajaxCallback, headers) {

            var methodUrl = srvcUrl;
            if (pageMethod !== "" && pageMethod !== null)
                methodUrl = methodUrl + "/" + pageMethod;

            if (headers === "" || headers === null)
                headers = {};

            $.ajax({
                async: true,
                type: "POST",
                url: methodUrl,
                data: parameters,
                dataType: "json",
                success: function (data) {
                    ajaxCallback(data)
                },
                error: function (response) {
                    if (response.responseText !== undefined && response.responseText !== null && response.responseText !== "") {

                    }
                },
                failure: function (response) {
                    if (response.responseText !== undefined && response.responseText !== null && response.responseText !== "") {

                    }
                }
            });
        }

        var resetContent = function () {
            $("#ErrorSection").addClass("invisible")
            $("#CaraousalDisplay").html("");
            $("#chart").empty();
            $("#AllWordsCount").html("");
        }

        return {
            Init: function () {
                init();
            }
        }
    })();
}
