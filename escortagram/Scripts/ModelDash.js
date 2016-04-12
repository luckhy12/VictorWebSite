/// <reference path="jquery-2.2.1.js" />

$(function () {

    $("#UpdateProfile").validate({
        rules: {

            Email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 5
            },
            MobileNo: {
                required: true,
                minlength: 10,
                maxlength: 10
            }


        },
        messages: {

            password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            email: "Please enter a valid email address",
            MobileNo: "Please enter a valid Mobile no."
        },
    });
});
function SavedSuccess(data) {
    if (data != null) {

        $("#ShowSuccess").show().fadeOut(2500);
    }
}

Dropzone.options.myDropzone = {

    // Prevents Dropzone from uploading dropped files immediately
    autoProcessQueue: false,

    init: function () {
        var submitButton = document.querySelector("#submit-all")
        myDropzone = this; // closure

        submitButton.addEventListener("click", function () {

            debugger;
            myDropzone.processQueue(); // Tell Dropzone to process all queued files.
        });

        // You might want to show the submit button only when 
        // files are dropped here:
        this.on("addedfile", function () {
            // Show submit button here and/or inform user to click it.
        });

    }
};

function SetBannerImage(Guid) {
    $.ajax({
        url: "/ModelDashboard/SetBannerImage/",
        type: "POST",
        dataType: "JSON",
        data: { Guid: Guid },
        success: function (data) {

            var UID = $("#myHiddenVar").val();
            $("#SetNewBanner").html("");
            $("#SetNewBanner").attr("src", "/Upload/ModelImages/" + UID + "/" + data + ".jpg");
        }
    });
}

$("#UploadprofilePic").on('submit', (function (e) {
    e.preventDefault();
    $.ajax({
        url: "/ModelDashboard/ProfilePic/", 
        type: "POST",             
        data: new FormData(this), 
        contentType: false,       
        cache: false,             
        processData: false,       
        success: function (data)   
        {
            e.preventDefault();

            $("#picupload").val('');
            var UID = $("#myHiddenVar").val();
            var d = new Date();
            //$(".changepic").attr('src', "");
            $(".changepic").attr('src', "/Upload/ModelImages/" + UID + "/" + data + ".jpg?" + d.getTime());
        }
    });
}));