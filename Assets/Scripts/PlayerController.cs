using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }
    
}
