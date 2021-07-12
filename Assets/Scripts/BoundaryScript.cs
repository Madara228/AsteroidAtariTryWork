using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private BoxCollider2D selfCollider;
    void Start()
    {
        selfCollider = GetComponent<BoxCollider2D>();
        var sizeByScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0)*1.5f);
        selfCollider.size = new Vector3(sizeByScreen.x,sizeByScreen.y);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision);// TODO: remake to object pool
    }
}
