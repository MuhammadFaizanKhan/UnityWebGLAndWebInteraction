using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    bool isRotateCube =true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotateCube) {

            transform.Rotate(Vector3.up * Time.deltaTime * 50f);

        }

	}

    public void IsRotateCube(string rotationText)
    {
        if(rotationText == "cube rotate" || rotationText == "Cube Rotate" || rotationText == "Cube rotate" || rotationText == "cube Rotate")
        {
            isRotateCube = true;
        }
        else if (rotationText == "cube stop" || rotationText == "stop" || rotationText == "Cube Stop")
        {
            isRotateCube = false;
        }
        
    }

}
