/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.language = 'en';

    //Cấu hình đường dẫn các loại tập tin khi finter
    config.filebrowserBrowserUrl = "/Areas/Admin/Resources/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Areas/Admin/Resources/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashUrl = "/Areas/Admin/Resources/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/Areas/Admin/Resources/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = "/Areas/Admin/Resources/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/Areas/Admin/Resources/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    config.extraPlugins = 'youtube';
    config.youtube_width = '';
    config.youtube_height = '';
    config.youtube_related = true;
    config.youtube_autoplay = false;
    config.youtube_controls = true;
    config.youtube_responsive = true;
    config.youtube_disabled_fields = ['txtEmbed', 'chkOlderCode', 'txtWidth', 'txtHeight', 'chkResponsive'];

    config.removePlugins = 'image,bgimage,forms,spellchecker,flash';
    //config.removeButtons += ",Styles";

    CKFinder.setupCKEditor(null, '/Areas/Admin/Resources/ckfinder/');
    //config.htmlEncodeOutput = true;
    config.contentsCss = '/Areas/Admin/Resources/ckeditor/fonts.css';
    //the next line add the new font to the combobox in CKEditor
    config.font_names = 'Montserrat;' + 'Roboto-Light;' + 'Roboto-Regular;' + 'Open-Sans;' + 'Arial;' + 'Times New Roman;';
        //config.font_names;

    config.line_height = "1;1.1;1.2;1.3;1.4;1.5;1.6;1.7;1.8;1.9;2";
};
