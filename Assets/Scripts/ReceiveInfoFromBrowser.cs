using UnityEngine;

public class ReceiveInfoFromBrowser : MonoBehaviour
{
    void ToggleGameObject()
    {
        Debug.Log("ToggleGameObject called");
        this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
    }

    /// <summary>
    /// This method will be called through the SendMessage in JS
    /// </summary>
    /// <param name="xyzPos"></param>
    void SetGameObjectPosition(string xyzPos)
    {
        string[] xyz = xyzPos.Split(',');
        Vector3 newPosition = new Vector3(float.Parse(xyz[0]), float.Parse(xyz[1]), float.Parse(xyz[2]));
        Debug.Log("SetGameObjectPosition called with string. New Position: " + newPosition);
        this.gameObject.transform.position = newPosition;
    }

    /// <summary>
    /// This method will be called through the SendMessage in JS
    /// </summary>
    /// <param name="jsonString"></param>
    void SetGameObjectPositionJson(string jsonString)
    {
        var position = JsonUtility.FromJson<Vector3>(jsonString);
        Vector3 newPosition = position;
        Debug.Log("SetGameObjectPositionJson called with json. New Position: " + position);
        this.gameObject.transform.position = newPosition;
    }
}
