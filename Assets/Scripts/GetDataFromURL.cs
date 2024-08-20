using UnityEngine;

public class GetDataFromURL : MonoBehaviour {

    public TextMesh tm;

	// Use this for initialization
	void Start () {

        int paramter = Application.absoluteURL.IndexOf("?");

        if (paramter != -1)
        {
            
            tm.text = Application.absoluteURL.Split("?"[0])[1];
            Debug.Log("Parameter found "+ tm.text);

        }
        else
        {
            Debug.Log("No Parameter found ");

        }
    }

}
