//Image
$(".BrowseImagePost").click(function () {
    var ContainerElement = $(this).parent().prev('.PostImageContainer');
    var finder = new CKFinder();
    finder.selectActionFunction = function (fileUrl) {
        //Lấy file ảnh cuối cùng
        ContainerElement.children('img').attr('src', fileUrl);
        ContainerElement.children('input.hidden').val(fileUrl);        
    };
    finder.popup();
});
//Insert multiple image to ckeditor
//$('#insert_multiple').click(function () {
//    var finder = new CKFinder();

//    finder.selectActionFunction = function (fileUrl, xxx, allFiles) {
//        var CKDATA = CKEDITOR.instances['Content'].getData();
//        allFiles.forEach(function (file) {
//            var img = '<p><img src="' + file.url + '"/></p>';
//            CKDATA += img;
//        });
//        CKEDITOR.instances['Content'].setData(CKDATA);
//    };
//    finder.popup();
//});

//CKEDITOR.replace("Content", {
//    htmlEncodeOutput: true,
//    width: '900px',
//    height: '650px'
//});


////THAM MY Category
//$('#Color').ColorPicker({
//    'onChange': function (hsb, hex, rgb) {
//        $('#Color').val('#' + hex);
//        ActivatePreview();
//        $('#first_post_7 .center-vertical').css('color', $('#Color').val());
//    }
//});

//$('#BackgroundColor').ColorPicker({
//    'onChange': function (hsb, hex, rgb) {
//        $('#BackgroundColor').val('#' + hex);
//        ActivatePreview();
//        $('#first_post_7 .center-vertical').css('background-color', $('#BackgroundColor').val());
//    }
//});

//$("#Browse2").click(function () {
//    var finder = new CKFinder();
//    finder.selectActionFunction = function (fileUrl) {
//        //Lấy file ảnh cuối cùng
//        $("#BackgroundImage").val(fileUrl);
//        document.getElementById("content2").innerHTML = '<img class="img-thumbnail" style="width:200px" type="type/html" src="' + fileUrl + '" ></img>';
//        ActivatePreview();
//        $('#first_post_7 .center-vertical').css('background-image', 'url(' + $("#BackgroundImage").val() + ')');
//    };
//    finder.popup();
//});
//$('#Browse2_cancel').click(function () {
//    $("#BackgroundImage").val('');
//    $('#content2').html('');
//    $('#first_post_7 .center-vertical').css('background-image', '');
//});
//function ActivatePreview() {
//    $('#preview_beauty').show();
//    $('#first_post_7>div:first-child>img').attr('src', $("#Image").val())
//}
////end THAM MY Category

////Tab 
//$('.tab-btn').click(function () {
//    if (!$(this).hasClass('active')) {
//        $('.tab-btn.active').removeClass('active');
//        $(this).addClass('active');
//        $('.tab-page').hide();
//        $('#' + $(this).data('page')).show();
//    }
//});

//$('#ActiveDate').datetimepicker({
//    locale: 'vi',
//    inline: true,
//    sideBySide: true,
//    format: 'MM/DD/YYYY HH:mm',
//    useCurrent: false,
//    showClear: true,
//    toolbarPlacement: 'bottom',
//    tooltips: {
//        clear: 'Bỏ chọn'
//    }
//});
////Change Ckeditor default font according to category
//$('#CategoryID').on('change', function () {
//    let selectedValue = $(this).val();
//    let fontSize = $('option[value=' + selectedValue + ']').data('font-size');
//    let fontFamily = $('option[value=' + selectedValue + ']').data('font-family');
//    CKEDITOR.instances.Content.document.$.getElementsByTagName('body')[0].style.fontFamily = fontFamily;
//    CKEDITOR.instances.Content.document.$.getElementsByTagName('body')[0].style.fontSize = fontSize + 'px';
//});
//CKEDITOR.on('instanceReady', function () {
//    $('#CategoryID').change();
//});