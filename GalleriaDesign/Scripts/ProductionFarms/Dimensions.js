function Cascading() {
    //Cascada
    var IDFarm = $("#idFarms").val();
    var data_blo = "id=" + $("#idFarms").val();
    //var B = $("#idBlocks").val();
    //$.post('@Url.Action("DropdownCascading")', { type: 'data', id: IDFarm }, function (result) {

    $.ajax({
        type: "POST",
        url: '@Url.Action("DimensionsController/DropdownCascading")',
        data: data_blo,
        dataType: "json",
        success: function (response) {

            $("#idBlocks").html("");
            var option = "<option>Select Block</option>";
            $("#idBlocks").append(option);
            $.each(response, function (i, block) {
                var option = "<option>" + block.codigoBloque + "</option>";
                $("#idBlocks").append(option);
            });
        }

    });
}