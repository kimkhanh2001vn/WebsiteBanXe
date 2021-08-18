let startPair = 100;
$('span.fa-plus').click(function () {
    let inputHTML = '<input class=" form-control pair' + startPair + '" name="postTags[]" />';
    let btnHTML = '<span class="fa fa-close" data-pair="pair' + startPair + '" onclick ="ChainDelete(this)"></span>';
    $('#input_col').append(inputHTML);
    $('#btn_col').append(btnHTML);
    startPair++;
});
function ChainDelete(btn) {
    let pairData = $(btn).data('pair');
    $('.' + pairData).remove();
    $(btn).remove();
}