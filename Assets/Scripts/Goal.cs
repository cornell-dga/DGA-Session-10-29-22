using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    EverythingElse manager;

    void Awake() {
        manager = GameObject.FindWithTag("GameController").GetComponent<EverythingElse>();
    }
    
    void OnTriggerEnter(Collider collider)
    {
        manager.Reset();
    }
}
