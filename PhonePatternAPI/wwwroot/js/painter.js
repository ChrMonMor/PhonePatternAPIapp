const uriPaint = 'api/PhonePatterns/';

let canW = 130;
let canP = 20;
let canC = 0;
let s = '';

const dotPositions = [[0, 0],
    [canP, canP], [canP + (canW / 2), canP], [canP + canW, canP],
    [canP, canP + (canW / 2)], [canP + (canW / 2), canP + (canW / 2)], [canP + canW, canP + (canW / 2)],
    [canP, canP + canW], [canP + (canW / 2), canP + canW], [canP + canW, canP + canW]];

function drawBoard() {
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    context.beginPath();
    context.clearRect(0, 0, 170, 170);
    context.lineCap = "round";
    context.lineWidth = 25;
    for (let y = 0; y <= canW; y += canW/2) {

        for (let x = 0; x <= canW; x += canW/2) {
            context.moveTo(0.5 + x + canP, canP + y);
            context.lineTo(0.5 + x + canP, canP + y);
        }
    }
    context.strokeStyle = "black";
    context.stroke();
    loadFile();
}

function loadFile() {
    fetch(String(uriPaint + canC))
        .then((response) => response.json())
        .then((responseJSON) => { drawLines(responseJSON); document.getElementById("test").innerText = String(responseJSON); })
        .catch(error => console.error('Unable to get items.', error));
}

function drawLines(string) {
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    context.beginPath();
    context.lineWidth = 5;
    let b = Array.from(String(string), Number);
    for (let i = 0; i < b.length; i++) {
        context.moveTo(dotPositions[b[i]][0], dotPositions[b[i]][1]);
        if (i + 1 < b.length) {
            context.lineTo(dotPositions[b[i + 1]][0], dotPositions[b[i + 1]][1]);
        }
    }
    context.strokeStyle = "green";
    context.stroke();
}

function wrongPattern() {
    let kann = false;
    addPatternToList(kann);
    canC++;
    drawBoard();
}

function correctPattern() {
    let kann = true;
    addPatternToList(kann);
    let canvas = document.getElementById("canvas");
    let context = canvas.getContext("2d");
    context.beginPath();
    context.fillStyle = "lightgreen";
    context.fillRect(0, 0, 170, 170);
    context.stroke();
    context.beginPath();
    context.lineCap = "round";
    context.lineWidth = 25;
    for (let y = 0; y <= canW; y += canW / 2) {

        for (let x = 0; x <= canW; x += canW / 2) {
            context.moveTo(0.5 + x + canP, canP + y);
            context.lineTo(0.5 + x + canP, canP + y);
        }
    }
    context.strokeStyle = "black";
    context.stroke();
    loadFile();
}

function jumpForward() {
    const jf = document.getElementById('jump-forward');
    if (jf.value != 0) {
        canC += parseInt(jf.value);
        document.getElementById('jump-forward').value = '';
        drawBoard();
    }
}

function addPatternToList(kann) {
    const pattern = document.getElementById('test');

    const item = {
        status: kann,
        pattern: String(pattern.innerText)
    };

    fetch(uriPaint, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            oldPattern(kann, item.pattern);
        })
        .catch(error => console.error('Unable to add item.', error));
}

function oldPattern(kann, numB) {
    let x = document.createElement("CANVAS");
    x.setAttribute("width",170);
    x.setAttribute("height",170);
    let ctx = x.getContext("2d");
    ctx.beginPath();
    if (kann) {
        ctx.fillStyle = "lightgreen";
    }
    else {
        ctx.fillStyle = "red";
    }
    ctx.fillRect(0, 0, 170, 170);
    ctx.lineCap = "round";
    ctx.lineWidth = 25;
    for (let y = 0; y <= canW; y += canW / 2) {

        for (let x = 0; x <= canW; x += canW / 2) {
            ctx.moveTo(0.5 + x + canP, canP + y);
            ctx.lineTo(0.5 + x + canP, canP + y);
        }
    }
    ctx.strokeStyle = "black";
    ctx.stroke();
    ctx.beginPath();
    ctx.lineWidth = 5;
    let b = Array.from(String(numB), Number);
    for (let i = 0; i < b.length; i++) {
        ctx.moveTo(dotPositions[b[i]][0], dotPositions[b[i]][1]);
        if (i + 1 < b.length) {
            ctx.lineTo(dotPositions[b[i + 1]][0], dotPositions[b[i + 1]][1]);
        }
    }
    ctx.strokeStyle = "green";
    ctx.stroke();
    document.body.appendChild(x);
}

function getPaintings() {
    fetch(String(uriPaint))
        .then((response) => response.json())
        .then((responseJSON) => { _displayPaintings(responseJSON); })
        .catch(error => console.error('Unable to get items.', error));
}

function _displayPaintings(data) {
    data.forEach(item => {
        oldPattern(item.status, item.pattern);
    });
}