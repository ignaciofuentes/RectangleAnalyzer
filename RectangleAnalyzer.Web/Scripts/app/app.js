var app = {

    clearCanvas: function () {
        var canvas = document.getElementById("myCanvas");
        var ctx = canvas.getContext("2d");
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    },

    drawRectangles: function () {
        var canvas = document.getElementById("myCanvas");
        var ctx = canvas.getContext("2d");
        var rec1x = $("#Rectangle1_X").val();
        var rec1y = $("#Rectangle1_Y").val();
        var rec1width = $("#Rectangle1_Width").val();
        var rec1height = $("#Rectangle1_Height").val();
        var rec2x = $("#Rectangle2_X").val();
        var rec2y = $("#Rectangle2_Y").val();
        var rec2width = $("#Rectangle2_Width").val();
        var rec2height = $("#Rectangle2_Height").val();

        ctx.beginPath();
        ctx.lineWidth = "1";
        ctx.strokeStyle = "red";
        ctx.rect(rec1x, rec1y, rec1width, rec1height);
        ctx.stroke();


        ctx.beginPath();
        ctx.lineWidth = "1";
        ctx.strokeStyle = "blue";
        ctx.rect(rec2x, rec2y, rec2width, rec2height);
        ctx.stroke();

    }



};