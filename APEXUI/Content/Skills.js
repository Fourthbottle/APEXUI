function InsSkills() {

    var SkillsBO = {
        Skill: $("#txtSkillName").val(),
        UsedExperience: $('#ddlyears option:selected').text() + '.' + $('#ddlmonths option:selected').text()
    }

    $.ajax({
        url: '/Skill/InsertSkills',
        type: 'post',
        dataType: 'json',
        success: function (data) {
            location.reload();
            //$('<td>' + SkillsBO.Skill + '</td><td>' + SkillsBO.UsedExperience + '</td>').insertAfter($('#hdnSkillRow').val());
           
            $('#myModal').modal('hide');
        },
        data: SkillsBO
    });
}


function closeWorkHistoyModal() {
    $('input[type=text]').each(function () {
        $(this).val('');
    });
    $('#chkCurentcompany').attr('checked', false);
}