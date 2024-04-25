//$(document).ready(function () {
//    $("#CreateCarWorkShopServicesModal").submit(function (event) {
//        event.preventDefault(); //zabezpieczenie przd domyślnm zachowaniem akcji submit

//        debugger

//        $.ajax({
//            url: $(this).attr('action'),
//            type: $(this).attr('method'),
//            data: $(this).serialize(),
//            success: function (data) {
//                //toastr["success"]("Created carworkshop service")
//                //LoadCarWorkShopServices()
//                console.log("wszystko poszło ok ")
//            },
//            error: function () {
//                //toastr["error"]("Something went wrong")
//                console.log("niestety błędy")
//            }
//        })
//    });
//});

console.log("Jestem !!")
console.log(document)


$(document).ready(function () {
    $("#CreateCarWorkShopServicesModal").submit(function (event) {
        console.log("znalazłem")
        event.preventDefault();

    })

})
//$(document).ready(function () {

//    //LoadCarWorkShopServices()

//    $("#CreateCarWorkShopServicesModal form").submit(function (event) {
//        event.preventDefault();
//        console.log("ggggg")
//        $.ajax({
//            url: $(this).attr('action'),
//            type: $(this).attr('method'),
//            data: $(this).serialize(),
//            success: function (data) {
//                toastr["success"]("Created carworkshop service")
//                LoadCarWorkShopServices()
//            },
//            error: function () {
//                toastr["error"]("Something went wrong")
//            }
//        })
//    });
//});