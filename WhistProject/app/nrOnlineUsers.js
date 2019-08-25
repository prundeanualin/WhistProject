var hub = $.connection.chatHub;
var users;
hub.client.updateCounter = function (counter) {
    $('#counter').text(counter);
    users = counter;
}
$.connection.hub.start();
$(document).ready(function () {
    if (users <= 1) {
        $("#buttonPlay").hide();
    }
    else {
        $("#buttonPlay").show();
    }
});
