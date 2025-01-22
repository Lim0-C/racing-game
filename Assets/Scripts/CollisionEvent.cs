using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    private GameObject gamemanager;
    private Collider collider;
    private Gas gas;
    
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        gas = other.gameObject.GetComponent<Gas>();
        if (gamemanager.GetComponent<GameManager>().currentGas + gas.gas >= 100f)
        {
            gamemanager.GetComponent<GameManager>().currentGas = 100f;
        }
        else
        {
            gamemanager.GetComponent<GameManager>().currentGas += gas.gas;
        }
        Destroy(other.gameObject);
    }
}
