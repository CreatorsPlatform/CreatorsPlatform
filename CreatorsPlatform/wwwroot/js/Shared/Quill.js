const quill = new Quill('#editor', {
    modules: {
        syntax: true,
        toolbar: '#toolbar-container',
    },
    placeholder: '請輸入文字',
    theme: 'snow',
});