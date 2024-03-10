$(function () {

    // �W�ǹϤ��åB�w���\��
    // �ʭ��Ϥ�
    $("#progressbarTWInput").change(function () {
        readURL(this);
    });
    function readURL(input) {

        if (input.files && input.files[0]) {

            var reader = new FileReader();

            reader.onload = function (e) {

                $("#preview_progressbarTW_img").attr('src', e.target.result);

            }

            reader.readAsDataURL(input.files[0]);

        }

    }
});
document.getElementById('upload').addEventListener('change', function () {
    var file = this.files[0];
    if (file) {
        var reader = new FileReader();
        reader.onload = function (event) {
            var img = new Image();
            img.src = event.target.result;
            document.getElementById('preview').innerHTML = '';
            document.getElementById('preview').appendChild(img);
            document.getElementById('preview').style.display = 'block';
        }
        reader.readAsDataURL(file);
    }
});