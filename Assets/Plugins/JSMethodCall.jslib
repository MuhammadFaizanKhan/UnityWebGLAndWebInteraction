mergeInto(LibraryManager.library, {

	GameObjectHasClicked: function (objName, pos) {
		var objectPos = Pointer_stringify(pos);
		var objectName = Pointer_stringify(objName);
		window.alert("You have clicked " + objectName + " and its on position " + objectPos);
		GameObjectHasClickedByJSLib(objectName, objectPos);
	},

	UnityWebGLCanvasFocused : function(){
		console.log("UnityWebGLCanvasFocused fn Called form C#/JSLIB ");
		UnityWebGLCanvasFocusedExternal();
	},

	

});