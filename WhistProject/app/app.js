var hub = $.connection.chatHub;
hub.client.message = function (msg) {
    $("#message").append("<li>" + msg + "</li>")
}
hub.client.user = function (innhtml) {
    $('#user').append(innhtml);
}
hub.client.updateCounter = function (counter) {
    $('#counter').text(counter);
}
function () {
    $("#send").click(function () {
        hub.server.send($("#txt").val());
        $("#txt").val(" ");
    });
};