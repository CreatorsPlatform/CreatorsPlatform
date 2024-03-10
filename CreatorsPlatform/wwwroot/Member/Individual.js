

window.onload = () => {
    var image = new Image();
    var canvas = document.getElementById('Preview');
    var ctx = canvas.getContext('2d');
    document.querySelector('#changeAvatarBtn').addEventListener('click', () => {
        var avatar = document.getElementById('Preview').toDataURL('image/png').replace('image/png', 'image/octet-stream');
        document.getElementById('Avatar').src = avatar;
    })
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
            canvas.addEventListener('wheel', (e) => {
                console.log(x, y, xlen, ylen)
                dy = e.deltaY;
                var prexlen = xlen;
                var preylen = ylen;
                xlen -= 0.1 * dy;
                ylen -= 0.1 * dy;
                if (xlen < 128 || ylen < 128) {
                    xlen = 128;
                    ylen = 128;
                    return;
                }
                // pixels that overflow = -x + x + xlen - 128
                x += (xlen - prexlen) * x / (xlen - 128);
                y += (ylen - preylen) * y / (ylen - 128);
                ctx.drawImage(image, x, y, xlen, ylen);
            });
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
