using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshToggleFromWeb : MonoBehaviour {

    MeshRenderer mr;

    // Use this for initialization
    void Start () {

       mr = GetComponent<MeshRenderer>();

	}
	
    /// <summary>
    /// This becalled from javascript.
    /// </summary>
    public void MeshToggle()
    {
        mr.enabled = !mr.enabled;
    }
}
