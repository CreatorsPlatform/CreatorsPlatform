

window.onload = () => {
    var image = new Image();
    var canvas = document.getElementById('Preview');
    var ctx = canvas.getContext('2d');

    document.querySelector('#ChooseImage').addEventListener('change', () => {
        const [file] = document.querySelector('#ChooseImage').files;
        image.src = URL.createObjectURL(file);
        x = 0;
        y = 0;
        xlen = 256;
        ylen = 256;
    });

    image.onload = () => {
        ctx.drawImage(image, x, y, xlen, ylen);
        isDragging = false;
        canvas.addEventListener('mousedown', () => {
            isDragging = true;
        });
        canvas.addEventListener('mouseup', () => {
            isDragging = false;
        });
        canvas.addEventListener('mouseout', () => {
            isDragging = false;
        });
        canvas.addEventListener('mousemove', ({ movementX, movementY }) => {
            if (isDragging) {
                console.log(x, y, xlen, ylen);
                x += movementX;
                y += movementY;
                ctx.drawImage(image, x, y, xlen, ylen);
            }
        });
        canvas.addEventListener('wheel', (e) => {
            dy = e.deltaY;
            // x should be equal to x minus xpos in canvas * zoom ratio
            var xlenpre = xlen;
            var ylenpre = ylen;
            xlen -= 0.1 * dy;
            ylen -= 0.1 * dy;
            if (xlen < 256 || ylen < 256) {
                xlen = 256;
                ylen = 256;
            }
            var xpos = getMousePos(canvas, e).x;
            var ypos = getMousePos(canvas, e).y;
            // zoom out
            if (dy > 0) {
                console.log("zoom out")
                x += 0.1 * xpos * xlen / xlenpre
                y += 0.1 * ypos * ylen / ylenpre
            }
            // zoom in
            if (dy < 0) {
                x -= 0.1 * xpos * xlen / xlenpre
                y -= 0.1 * ypos * ylen / ylenpre
            }
            ctx.drawImage(image, x, y, xlen, ylen);
        });
    }
}
function getMousePos(canvas, e) {
    var rect = canvas.getBoundingClientRect();
    scaleX = canvas.width / rect.width;
    scaleY = canvas.height / rect.height;
    return {
        x: (e.clientX - rect.left) * scaleX,
        y: (e.clientY - rect.top) * scaleY
    }
}
