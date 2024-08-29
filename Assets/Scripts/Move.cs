using UnityEngine;

public class Move : MonoBehaviour
{
    void Update()
    {

        var horizontal = Input.GetAxis("Horizontal") * 2 * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * 2 * Time.deltaTime;
        this.transform.Translate(horizontal, vertical, 0);

    }
}
