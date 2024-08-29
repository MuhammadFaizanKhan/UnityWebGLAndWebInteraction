/**
 * Created by Faizan Khan on 14-Dec-18.
 */

jQuery(document).ready(function() {
    var baseURL = "Server\\GetDataApi.php";
    LoadClickedData();
    setInterval(LoadClickedData,5000);
    jQuery("#WebGLMethodCaller").click(function(){
        WebGLMethodCaller();
    }) ;



    function LoadClickedData(){

        $.get(baseURL,
            { }, function(data)
            {
                var data = JSON.parse(data);
                var html ="<table><tr><td>Object Name</td><td>Position</td><td>DateTime</td></tr>";
                for (var i = 0; i < data.length; i++){
                    html+= "<tr>" +
                        "<td>"+ data[i].objectName+"</td>"+
                        "<td>"+ data[i].Objposition+"</td>"+
                        "<td>"+ data[i].dateTime+"</td>"+
                        "<td></td>"+
                    "</tr>";
                }

                $("#ObjClickedData").html(html);

            });


    }

    function WebGLMethodCaller(){
    console.log("webglmethod caller");
        ToggleCubeMesh();
    }

});