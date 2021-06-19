function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: "nfc-bottom-right",
        showDuration: 4000,
        theme: theme !== "" ? theme : "success"
    })({
        title: title !== "" ? title : "اعلان",
        message: decodeURI(text)
    });
}

$(document).ready(function () {
    var editors = $("[ckeditor]");
    var url = $(location).attr("hostname");
    if (url.indexOf("localhost") >= 0) {
	    url = "http://localhost/ccsc/";
    }
    if (editors.length > 0) {
        $.getScript(url+"js/ckeditor.js", function (data, textStatus, jqxhr) {
            $(editors).each(function (index, value) {
                var id = $(value).attr("ckeditor");
                ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                    {
                        toolbar: {
                            items: [
                                "heading",
                                "|",
                                "bold",
                                "italic",
                                "link",
                                "|",
                                "fontSize",
                                "fontColor",
                                "|",
                                "imageUpload",
                                "blockQuote",
                                "insertTable",
                                "undo",
                                "redo",
                                "codeBlock"
                            ]
                        },
                        language: "fa",
                        table: {
                            contentToolbar: [
                                "tableColumn",
                                "tableRow",
                                "mergeTableCells"
                            ]
                        },
                        licenseKey: "",
                        simpleUpload: {
                            // The URL that the images are uploaded to.
                            uploadUrl: url +"Uploader/UploadImage"
                        }

                    })
                    .then(editor => {
                        window.editor = editor;
                    }).catch(err => {
                        console.error(err);
                    });
            });
        });
    }
});

