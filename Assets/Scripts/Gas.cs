using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public float gas = 30f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up, gas * Time.deltaTime);
    }
}
