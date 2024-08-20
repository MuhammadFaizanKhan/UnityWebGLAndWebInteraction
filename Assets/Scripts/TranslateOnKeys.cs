using UnityEngine;

public class TranslateOnKeys : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Input.GetAxis("Horizontal") * 2 * Time.deltaTime, Input.GetAxis("Vertical") * 2 * Time.deltaTime, 0);
    }
}
