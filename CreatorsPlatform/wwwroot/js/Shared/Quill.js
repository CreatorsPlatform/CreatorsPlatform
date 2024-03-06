//const container = document.getElementsByClassName('richTextEditor');
//const container = document.getElementsByClassName('richTextEditor');
//console.log(container);
const quill1 = new Quill('#editor1', {
    modules: {
        syntax: true,
        toolbar: '#toolbar-container',
    },
    placeholder: '請輸入文字',
    theme: 'snow',
});
const quill2 = new Quill('#editor2', {
    modules: {
        syntax: true,
        toolbar: '#toolbar-container',
    },
    placeholder: '請輸入文字',
    theme: 'snow',
});