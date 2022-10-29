using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    EverythingElse manager;

    void Awake() {
        manager = GameObject.FindWithTag("GameController").GetComponent<EverythingElse>();
        manager.Register(gameObject);
    }
    
    void OnTriggerEnter(Collider collider)
    {
        manager.OnPickedUp();
        gameObject.SetActive(false);
    }
}
