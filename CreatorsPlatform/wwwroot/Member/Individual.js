

window.onload = () => {
    var image = new Image();
    var canvas = document.getElementById('Preview');
    var ctx = canvas.getContext('2d');
    document.querySelector('#changeAvatarBtn').addEventListener('click', () => {
        var avatar = document.getElementById('Preview').toDataURL('image/png').replace('image/png', 'image/png');
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
                if (x + movementX > 0 || y + movementY > 0 || x + xlen + movementX < 256 || y + ylen + movementY < 256) {
                    return;
                }
                x += movementX;
                y += movementY;
                ctx.drawImage(image, x, y, xlen, ylen);
            }
        });
        canvas.addEventListener('mouseleave', () => {
            document.body.style.overflow = "auto";
        });
        canvas.addEventListener('wheel', (e) => {
            document.body.style.overflow = "hidden";
            console.log(x, y, xlen, ylen)
            dy = e.deltaY;
            var prexlen = xlen;
            var preylen = ylen;
            xlen -=  dy;
            ylen -=  dy;
            var xpos = getMousePos(canvas, e).x;
            var ypos = getMousePos(canvas, e).y;
            if (xlen < 256 || ylen < 256) {
                xlen = 256;
                ylen = 256;
                return;
            }
            if (xpos - (xpos - x) * xlen / prexlen > 0 || ypos - (ypos - y) * ylen / preylen > 0 || xpos - (xpos - x) * xlen / prexlen + xlen < 256 || ypos - (ypos - y) * ylen / preylen + ylen < 256) {
                return;
            }
            x = xpos - (xpos - x) * xlen / prexlen;
            y = ypos - (ypos - y) * ylen / preylen;
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
