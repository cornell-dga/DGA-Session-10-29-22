using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rate;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0.0f,rate*Time.deltaTime,0.0f);
    }
}
