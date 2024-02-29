
var CurrentMsg = 0;
var UserCurrentMsgtype = "newmsg";
var _UserCurrentMsgtype = "newmsg";

function SidebarOpen() {
    console.log("11");
    $("#Main").removeClass().addClass("Main_Open");
    $("#Sidebar").removeClass().addClass("Sidebar_Open");   
}
function SidebarClose() {
    console.log("00");
    $("#Main").removeClass().addClass("Main_Close");
    $("#Sidebar").removeClass().addClass("Sidebar_Close");  
};

function MessagUpdata(UserCurrentMsgtype){
    CurrentMsg = 0;
    console.log("ok");
    $("#Messages").empty();
    $.ajax({
        url: '/yhu/PersonalUser',
        method: 'POST',
        data: {
            _CurrentMsg: CurrentMsg,
            tapy:UserCurrentMsgtype,
        }, success: function (response) {
            console.log(response);
            for (i = CurrentMsg; i < response.length; i++) {
                let MsgHtml =
                    `<li>
             <p>${response[i].nickname}</p>
             <p>${response[i].description}</p>
             <img src="${response[i].imageURL}" alt="">
             <p>${response[i].title}</p>
            </li>`;
                $('#Messages').append(MsgHtml);
            }
        }
    })
    
};
function Messagloading(UserCurrentMsgtype, CurrentMsg) {
    CurrentMsg += 2;
    $.ajax({
        url: '/yhu/PersonalUser',
        method: 'POST',
        data: {
            _CurrentMsg: CurrentMsg,
            tapy: UserCurrentMsgtype
        },
        success: function (response) {
            for (i = CurrentMsg; i < response.length; i++) {
                let MsgHtml =
                    `<li>
             <p>${response[i].nickname}</p>
             <p>${response[i].description}</p>
             <img src="${response[i].imageURL}" alt="">
             <p>${response[i].title}</p>
            </li>`;
                $('#Messages').append(MsgHtml);
            }
        }
    });
    
} ;

MessagUpdata(_UserCurrentMsgtype, CurrentMsg);

//$("#Main").css({
//    "transition": "0.5s",
//    "transform": "scaleX(0.8)",
//    "transform-origin": "left"
//});
//$("#Sidebar").css({
//    "transition": "0.5s",
//    "transform": "scaleX(1)"
//});
//$("#Main").css({
//    "transition": "0.5s",
//    "transform": "scaleX(1)",
//    "transform-origin": "left"
//});
//$("#Sidebar").css({
//    "transition": "0.3s",
//    "transform": "scaleX(0.1)"
//});