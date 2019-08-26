var hub = $.connection.chatHub;
hub.client.message = function (msg) {
    $("#message").append("<li>" + msg + "</li>")
}
hub.client.user = function (innhtml) {
    //$("#user").html("");
    $('#user').html(innhtml);
}
hub.client.updateCounter = function (counter) {
    $('#counter').text(counter);
}
$.connection.hub.start().done(function () {
    $("#send").click(function () {
        hub.server.send($("#txt").val());
        $("#txt").val(" ");
    });
});