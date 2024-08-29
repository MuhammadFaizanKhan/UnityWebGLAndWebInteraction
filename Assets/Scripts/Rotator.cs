using UnityEngine;


public class Rotator : MonoBehaviour {

    bool isRotateCube =true;

	void Update () {

        if (isRotateCube) {

            transform.Rotate(Vector3.up * Time.deltaTime * 50f);
        }
	}

    public void IsRotateCube(string rotationText)
    {
        if(rotationText == "cube rotate")
        {
            isRotateCube = true;
        }
        else if (rotationText == "cube stop")
        {
            isRotateCube = false;
        }
        
    }

}
