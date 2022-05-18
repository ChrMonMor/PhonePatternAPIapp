const uri = 'api/todoitems';
let beenDone = [];

function drawBoard() {
    let bw = 150;
    let bh = 150;
    let p = 10;
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    context.lineCap = "round";
    context.lineWidth = 10;
    for (let y = 0; y <= bh; y += 75) {

        for (let x = 0; x <= bw; x += 75) {
            context.moveTo(0.5 + x + p, p + y);
            context.lineTo(0.5 + x + p, p + y);
        }
    }


    context.strokeStyle = "black";
    context.stroke();
}