var hub = $.connection.chatHub;
hub.client.user = function (innhtml) {
    $('#user').append(innhtml);
}