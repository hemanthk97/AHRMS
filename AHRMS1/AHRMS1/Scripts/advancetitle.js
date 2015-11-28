$(document).ready(function () {
    $('#at').mouseover(function () {
        $(this).stop().animate({ width: "120px" });
        $('#at').text("Advance");
        $('#at').css({ opacity: '2', color: 'blue', fontWeight: 'bold', cursor: 'default' });
    });
    $('#ht').mouseover(function () {
        $(this).stop().animate({ width: "100px" });
        $('#ht').text("Human");
        $('#ht').css({ opacity: '2', color: 'green', fontWeight: 'bold', cursor: 'default' });
    });
    $('#rt').mouseover(function () {
        $(this).stop().animate({ width: "130px" });
        $('#rt').text("Resource");
        $('#rt').css({ opacity: '2', color: 'purple', fontWeight: 'bold', cursor: 'default' });
    });
    $('#mt').mouseover(function () {
        $(this).stop().animate({ width: "180px" });
        $('#mt').text("Management");
        $('#mt').css({ opacity: '2', color: 'brown', fontWeight: 'bold', cursor: 'default' });
    });
    $('#st').mouseover(function () {
        $(this).stop().animate({ width: "100px" });
        $('#st').text("System");
        $('#st').css({ opacity: '1', color: 'orange', fontWeight: 'bold', cursor: 'default' });
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