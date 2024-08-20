using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectSmoothly : MonoBehaviour {

    public GameObject target;
    Vector3 offset;

	void Start () {
        offset = this.transform.position - target.transform.position;
    }
	

    private void LateUpdate()
    {
        this.gameObject.transform.position = 
            Vector3.Lerp(this.transform.position, (offset + target.transform.position), Time.deltaTime * 3f);
    }
}
