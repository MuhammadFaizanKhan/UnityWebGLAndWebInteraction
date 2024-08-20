using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// This script will send object information to Browser javascript when you click on the object.
/// </summary>
public class SendInfoToBrowserJS : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void GameObjectHasClicked(string objectName, string pos);
    
    private void OnMouseDown()
    {
        Debug.Log("object clicked" + this.name);
        GameObjectHasClicked(this.name, this.transform.position.ToString());
    
    }


}
