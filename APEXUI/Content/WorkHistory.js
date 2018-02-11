function InsWorkHistory() {
    
    var iscuurentCompany = 0;
    if (document.getElementById("chkCurentcompany").checked)
        iscuurentCompany = 1;

    var workLocation = {
        street: $("#txtLocation").val(),
        city: $("#txtCity").val(),
        state: $("#txtState").val(),
        country: $("#txtCountry").val()
    }

    var manager = {
        MgrFullName: $("#txtManagerName").val(),
        MgrEmail: $("#txtManagerEmail").val(),
        MgrCountryCode: $("#txtManagerCountryCode").val(),
        MgrMobileNumb: $("#txtMobileNumber").val()
    }

    var WorkRoles = {
        FromDate: $("#txtfromDate").val(),
        ToDate: $("#txtToDate").val(),
        Designation: $("#txtDesignation").val(),
        EmpType: document.getElementById("ddlEmpType").value,
        isCurrentCompany: iscuurentCompany
    }

    var WorkHistoryBO = {
        compId: '',
        compName: $("#txtCompanyName").val(),
        workLocation: workLocation,
        manager: manager,
        WorkRoles: WorkRoles,
        Responsibility: $("#txtRolesResponsibilities").val(),
        EmploymentId: $("#txtEmploymentId").val(),
        EmpId: $('#hdnEmp').val()
    }

    $.ajax({
        url: '/WorkHistory/InsertWorkHistory',
        type: 'post',
        dataType: 'json',
        success: function (data) {
            $('<div class="col-sm-9"><div class="well"><b>' + WorkHistoryBO.WorkRoles.Designation + '</b> in <b>' + WorkHistoryBO.compName + '</b></div></div>').insertAfter("#div1");
            $('#myModal').modal('hide');
        },
        error: function(xhr){
            alert('Request Status: ' + xhr.status + ' Status Text: ' + xhr.statusText + ' ' + xhr.responseText);
        },
        data: WorkHistoryBO
    });

    function closeWorkHistoyModal() {
        $('input[type=text]').each(function () {
            $(this).val('');
        });
        $('#chkCurentcompany').attr('checked', false);
    }


}

$(document).ready(function () {
    $('#chkCurentcompany').click(function () {
        if ($(this).is(':checked')) {
            $('#txtToDate').attr('disabled', 'disabled');

        } else {
            $('#txtToDate').removeAttr("disabled");
        }
    });
});


//$(document).ready(function () {
//    $("a[name = 'delt']").click(function (event) {
//        var id = $(this).attr('id');
//        var WHID = str.substring(4, 1000);

//        alert('called' + WHID);

//        //$.ajax({
//        //    url: '/WorkHistory/DeleteWorkHistory/?id='+WHID,
//        //    type: 'post',
//        //    dataType: 'json',
//        //    success: function (data) {
//        //        alert('success');
//        //    },
//        //    data: WorkHistoryBO
//        //});


//    });
//});
