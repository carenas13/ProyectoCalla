// contador de fotos store execution
var cantFSI = 0;
// conador fotos rose program
var cantFRPro = 0;

// contador fotos Consumer Bunch Program
var cantFCBP = 0;

// contador fotos Bouquet program
var cantFBPro = 0;

// contador fotos store execution

var cantFSE = 0;

// Contador de fotos aditiona comments

var cantFAC = 0;

function isTrue() {

    if ($("#innerWrapBP").prop('checked')) {

        $("#innerWrapBP").val("true");
    }



    if ($("#innerWrapRP").prop('checked')) {

        $("#innerWrapRP").val("true");
    }



    if ($("#innerWrapRetail").prop('checked')) {

        $("#innerWrapRetail").val("true");
    }


    if ($("#pick").prop('checked')) {

        $("#pick").val("true");
    }

    if ($("#innerWrapBPR").prop('checked')) {

        $("#innerWrapBPR").val("true");
    }





    //$("#formInspectionSupermarket").find("input[name*='btnCheck']").each(function (ind, respuesta) {

    //    if (respuesta.checked) {

    //        $(respuesta).val("true");
    //    }
    //});


}


function loadFotos(Camera) {

    var input = Camera;
    var file = input.files[0];
    //var inputPicture = $(Camera).closest("div[name^=modalFoto]").find("input[name^=image]");



    if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^=fotoStore]").length != 0) {

        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFSI, "foto");

        cantFSI++;
    }
    else if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^=fotoBunchProgram]").length != 0) {

        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFCBP, "fotoTypeBunchProgram");
        cantFCBP++;
    } else if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^=fotoRoseProgram]").length != 0) {


        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFRPro, "fotoTypeRoseProgram");
        cantFRPro++;
    } else if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^=fotoBouquetProgram]").length != 0) {

        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFBPro, "fotoTypeBouquetProgram");
        cantFBPro++;
    } else if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^fotoStoreExecution]").length != 0) {

        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFSE, "fotoTypeStoreExecutions");
        cantFSE++;
    } else if ($(Camera).closest("div[name^=inspectionSupermarket]").find("input[name^fotosAdditionalComents]").length != 0) {

        drawOnCanvas(file, $(Camera).closest("div[name^=inspectionSupermarket]"), cantFAC, "fotoTypeAdditionalComments");
        cantFAC++;
    }
}




//function guardarFotos(inputFile) {

//    var pictureType = $("#typeImage")[0].cloneNode(true);


//    $(pictureType).attr("name", "[" + cantFotos + "].typeImage");

//    $(pictureType).val($(inputFile).find("input[name^=modalAnterior]").val());


//    $("#maestros").append(pictureType);


//}

function drawOnCanvas(file, inputPicture, cantFotos, typeImagen) {
    var reader = new FileReader();
    var canvas = $(inputPicture).find("canvas[name^='canvas']")[0];
    var ctx = canvas.getContext('2d');
    reader.onload = function (e) {
        var dataURL = e.target.result,

            img = new Image();

        img.onload = function () {
            canvas.width = 400;
            canvas.height = 400;
            ctx.drawImage(img, 0, 0, 354, 354);
            var foto = canvas.toDataURL("image/png").replace('data:image/png;base64,', '');
            var pictureSave = $("#fotoStore")[0].cloneNode(true);
            // $(pictureSave).attr("name", "[" + cantFotos + "].foto");

            $(pictureSave).attr("name", "[" + cantFotos + "]." + typeImagen);
            $("#insSupermarket").append(pictureSave);
            //$(pictureSave).attr("src", foto);
            $(pictureSave).val(foto);


        };

        img.src = dataURL;
    };

    reader.readAsDataURL(file);


}





function takePicture(btnCamera) {


    $(btnCamera).closest("div[name^=inspectionSupermarket]").find("input[name^=image]").click();



}
