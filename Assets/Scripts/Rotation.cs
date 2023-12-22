using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotSpeed = 1.0f;
    
    void FixedUpdate() 
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed));
    }
}
