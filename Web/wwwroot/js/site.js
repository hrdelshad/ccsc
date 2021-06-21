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

function copyToClipboard(text) {
	var elem = document.createElement('textarea');
	elem.value = text;
	document.body.appendChild(elem);
	elem.select();
	document.execCommand('copy');
	document.body.removeChild(elem);
}

$(document).ready(function () {
    var editors = $("[ckeditor]");
    var url = $(location).attr("hostname");
    if (url.indexOf("localhost") >= 0) {
	    url = "http://localhost/ccsc/";
    } else {
	    url = "http://my.enico.ir/";
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

