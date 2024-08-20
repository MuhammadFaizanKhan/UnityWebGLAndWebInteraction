using System.Runtime.InteropServices;
using UnityEngine;
/// <summary>
/// This class will help you to consume keyboard input. You can call its function to allow or not allow webgl canvas to consume keyboard input.
/// </summary>
public class WebGLCanvasFocus : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void UnityWebGLCanvasFocused();


	void Start () {
    #if (UNITY_WEBGL) && !UNITY_EDITOR
        UnityWebGLCanvasFocused();    
    #endif

    }

    public void FocusWebGLCanvas(int isFocus)
    {
        Debug.Log("FocusWebGLCanvas fn Called form C# "+ isFocus);
        if (isFocus == 0)
        {
            Debug.Log("captureAllKeyboardInput false");
            WebGLInput.captureAllKeyboardInput = false;
        }
        else
        {
            Debug.Log("captureAllKeyboardInput true");
            WebGLInput.captureAllKeyboardInput = true;
        }
    }
}
