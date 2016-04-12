/// <reference path="../jquery-2.2.1.js" />
/// <reference path="../jquery.validate.js" />

function EditMenuColumn(PageID) {
    debugger;
    var PageName = $("#FindMenu_" + PageID).find('td').eq(0).text();
    var PageOrder = $("#FindMenu_" + PageID).find('td').eq(1).text();
    var PageURL = $("#FindMenu_" + PageID).find('td').eq(5).text();
    $("#FindMenu_" + PageID).find('td').eq(0).html('<input type="text" id="pagename_' + PageID + '" class="form-control" value="' + PageName + '"/>');
    $("#FindMenu_" + PageID).find('td').eq(1).html('<input type="text" id="pageorder_' + PageID + '" class="form-control" value="' + PageOrder + '"/>');
    $("#FindMenu_" + PageID).find('td').eq(5).html('<input type="text" id="pageurl_' + PageID + '" class="form-control" value="' + PageURL + '"/>');
    $("#hidediv_" + PageID).show();
    $("#actionlinkb_" + PageID).hide();
}


function CancelLink(id) {
    debugger;
    var pagestatus = "";
    var Pagename = $("#pagename_" + id).val();
    var pageorder = $("#pageorder_" + id).val();
    var pageurl = $("#pageurl_" + id).val();
    $("#hidediv_" + id).hide();
    $("#actionlinkb_" + id).show();
    $("#pagename_" + id).hide();
    $("#pageorder_" + id).hide();
    $("#pageurl_" + id).hide();
    $("#FindMenu_" + id).find('td').eq(0).text(Pagename);
    $("#FindMenu_" + id).find('td').eq(1).text(pageorder);
    $("#FindMenu_" + id).find('td').eq(5).text(pageurl);
}
function Updatedata(id) {
    debugger;
    var pagestatus = "";
    var Pagename = $("#pagename_" + id).val();
    var pageorder = $("#pageorder_" + id).val();
    if ($('#pagestatus_' + id).is(':checked')) {
        pagestatus = true;
    }
    else {
        pagestatus = false;
    }
    var pageurl = $("#pageurl_" + id).val();
    $.ajax({
        url: '/Home/UpdateHome/',
        type: 'POST',
        datatype: 'JSON',
        data: { PageName: Pagename, PageOrder: pageorder, PageStatus: pagestatus, PageUrl: pageurl, PageID: id },
        success: function (data) {
            CancelLink(data);

            if (pagestatus == true) {
                $("#FindMenu_" + id).find('td').eq(4).html('<input type="checkbox" name="locationthemes" id="pagestatus_' + id + '" checked="true" />');
            } else {
                $("#FindMenu_" + id).find('td').eq(4).html('<input type="checkbox" name="locationthemes" id="pagestatus_' + id + '" />');
            }
        }
    });

}

$("#UploadBanner").on('submit', (function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Home/BannerImage/",
        type: "POST",
        data: new FormData(this),
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            $("#resetImage").val('');
            e.preventDefault();

        }
    });
}));
$(function () {
    $("#TestimonilaUpload").validate({

    });
});

$("#TestimonilaUpload").on('submit', (function (e) {
    debugger;
    e.preventDefault();
    var $form = $(this);
    if (!$form.valid()) return false;

    $.ajax({
        url: "/Home/Testimonials/",
        type: "POST",
        data: new FormData(this),
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            $("#resetImage").val('');
            e.preventDefault();

        }
    });
}));

function DeleteDestimonial(ID) {
    $.ajax({
        url: "/Home/DeleteDestimonial/",
        type: "POST",
        datatype:"JSON",
        data: {ID:ID},
        success: function (data) {
           
            if (data == 1) {
                $("#Findtesti_" + ID).remove();
            }
        },
        error: function () {
            alert("Error occurs!");
        }
    });
}

function EditTestimonial(ID) {
    debugger;
    $("#hidediv_" + ID).show();
    $("#UpdateTesti_" + ID).hide();
}
function CancelLinkTesti(ID) {
    $("#hidediv_" + ID).hide();
    $("#UpdateTesti_" + ID).show();
}
function UpdateTestimonial(ID) {
    var Testimonialstatus = "";
    if ($('#Testimonialstatus_' + ID).is(':checked')) {
        Testimonialstatus = true;
    }
    else {
        Testimonialstatus = false;
    }
    $.ajax({
        url: "/Home/UpdateTestimonial/",
        type: "POST",
        datatype: "JSON",
        data: { ID: ID,Status:Testimonialstatus },
        success: function (data) {
            $("#hidediv_" + ID).hide();
            $("#UpdateTesti_" + ID).show();
            if (Testimonialstatus == true) {
                $("#Findtesti_" + ID).find('td').eq(3).html('<input type="checkbox" name="locationthemes" id="Testimonialstatus_' + ID + '" checked="true" />');
            } else {
                $("#Findtesti_" + ID).find('td').eq(3).html('<input type="checkbox" name="locationthemes" id="Testimonialstatus_' + ID + '" />');
            }
        },
        error: function () {
            alert("Error occurs!");
        }
    });
}



$(function () {
    $("#BlogUpload").validate({

    });
});

$("#BlogUpload").on('submit', (function (e) {
    debugger;
    e.preventDefault();
    var $form = $(this);
    if (!$form.valid()) return false;

    $.ajax({
        url: "/BlogBackend/AddBlog/",
        type: "POST",
        data: new FormData(this),
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            $("#resetImage").val('');
            e.preventDefault();

        }
    });
}));

