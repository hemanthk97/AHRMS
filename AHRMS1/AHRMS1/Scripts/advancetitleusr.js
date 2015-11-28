$(document).ready(function () {
    $('#at').mouseover(function () {
        $(this).stop().animate({ width: "90px" });
        $('#at').text("Advance");
        $('#at').css({ opacity: '2', fontWeight: 'bold', color: 'blue', cursor: 'default' });
    });
    $('#ht').mouseover(function () {
        $(this).stop().animate({ width: "80px" });
        $('#ht').text("Human");
        $('#ht').css({ opacity: '2', fontWeight: 'bold', color: 'green', cursor: 'default' });
    });
    $('#rt').mouseover(function () {
        $(this).stop().animate({ width: "100px" });
        $('#rt').text("Resource");
        $('#rt').css({ opacity: '2', fontWeight: 'bold', color: 'purple', cursor: 'default' });
    });
    $('#mt').mouseover(function () {
        $(this).stop().animate({ width: "130px" });
        $('#mt').text("Management");
        $('#mt').css({ opacity: '2', fontWeight: 'bold', color: 'brown', cursor: 'default' });
    });
    $('#st').mouseover(function () {
        $(this).stop().animate({ width: "80px" });
        $('#st').text("System");
        $('#st').css({ opacity: '2', fontWeight: 'bold', color: 'orange', cursor: 'default' });
    });
    $('.aa').mouseout(function () {
        $(this).stop().animate({ width: "25px" });
        $(this).css({ opacity: '0.8' });
        $('.aa').text("");
        $('#at').text("A");
        $('#ht').text("H");
        $('#rt').text("R");
        $('#mt').text("M");
        $('#st').text("S");

    });
});