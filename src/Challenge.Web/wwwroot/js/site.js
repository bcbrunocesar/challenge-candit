$(function () {
    $("#submit-cotacao").submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: '@Url.Action("Index")',
            data: $(this).serialize(),
            method: "POST"
        }).done(function (data) {
            $("#resultado-cotacao-container").html(data);
            $('html, body').animate({
                    scrollTop: $("#resultad-cotacao").offset().top
                },
                750);
        });
    });
});

$(function () {
    $("#cotacao-container").on("click",
        "#nova-cotacao",
        function () {
            $('html, body').animate({
                    scrollTop: $("#cotacao-container").offset().top
                },
                300);

            $("#submit-cotacao")[0].reset();
            $("#resultad-cotacao").remove();
        });
});