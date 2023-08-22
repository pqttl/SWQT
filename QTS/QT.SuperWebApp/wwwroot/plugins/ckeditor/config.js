/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

  //config.extraPlugins = 'syntaxhighlight';
  config.syntaxhighlight_lang = 'csharp';
  config.syntaxhighlight_hideControls = true;

  //config.pasteFromWordPromptCleanup = true;
  //config.pasteFromWordRemoveFontStyles = false;
  //config.pasteFromWordRemoveStyles = false;

  config.language = 'vi';

  config.htmlEncodeOutput = false;
  config.ProcessHTMLEntities = false;
  config.entities = false;
  config.entities_latin = false;
  config.ForceSimpleAmpersand = true;

  config.filebrowserBrowseUrl = '/Assets/admin/plugins/ckfinder/ckfinder.html';
  config.filebrowserImageBrowseUrl = '/Assets/admin/plugins/ckfinder.html?Type=Images';
  config.filebrowserFlashBrowseUrl = '/Assets/admin/plugins/ckfinder.html?Type=Flash';
  config.filebrowserUploadUrl = '/Assets/admin/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
  config.filebrowserImageUploadUrl = '/Data';
  config.filebrowserFlashUploadUrl = '/Assets/admin/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

  CKFinder.setupCKEditor(null, '/Assets/admin/plugins/ckfinder/');
};
