using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public Vector3 offsetA;
    public Vector3 offsetB;
    public float period = 2.0f;


    Vector3 ptA;
    Vector3 ptB;

    void Awake() {
        ptA = transform.position + offsetA;
        ptB = transform.position + offsetB;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(ptA,ptB,0.5f+0.5f*Mathf.Sin(2.0f*Mathf.PI*(Time.time/period)));
    }

    void OnDrawGizmosSelected()
    {
        Vector3 editorPtA = transform.position + offsetA;
        Vector3 editorPtB = transform.position + offsetB;
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 1);
        Gizmos.DrawSphere(editorPtA, 0.1f);
        Gizmos.DrawSphere(editorPtB, 0.1f);
        Gizmos.DrawLine(editorPtA, editorPtB);
    }
}
