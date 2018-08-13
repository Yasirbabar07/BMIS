function deleteFn(element, col)
{
   
    var column = col - 1;
    $(".uni-delete-form").empty();
    $(".uni-delete-form").append('<div class="delete-dialog"> ' +
            '<div class="row">' +
                '<div class="col-sm-12 has-feedback"> ' +
                    '<input type="text" name="Id" id="Id" hidden="hidden" value=' + $(element).closest("tr").find("td:eq(" + column + ")").text() + '>' +
                    '<h5 style="display:inline">Delete this record ?</h5>' +
                    '<button type="button" class="btn text-right close-del-dialog btn-sm">No</button>' +
                    '<input type="submit" class="btn text-right" id="Submit3" value="Yes"/>' +
                '</div>' +
            '</div>' +
    '</div>');
    if ($(window).width() <= 350) {
        $(".delete-dialog").css({
            top: $(element).closest("tr").offset().top - 110,
            left: $(element).closest("tr").offset().left - 78
        });
    } else {
        $ww = $(window).width();
        $eleOff = $(element).closest("tr").find(".fa-times").offset().left;
        $dia_box = $(".delete-dialog").width();
        $total = $eleOff + $dia_box;
        $left = $total > $ww ? ($total - $ww)  : 0;
        console.log(($eleOff - $left));
        $(".delete-dialog").css({
            top: $(element).closest("tr").offset().top - 55,
            left: ($eleOff - ( $left + 220 ))
        });
    }
    $(".delete-dialog").removeClass("animated fadeOutOutDown").addClass("animated bounceIn").show();
}
$(function () {
    $(document).on("click", ".close-del-dialog", function () {
        $(".delete-dialog").removeClass("animated bounceIn").fadeOut();
    });
});