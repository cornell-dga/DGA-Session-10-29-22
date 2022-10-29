using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float distance;
    public float lift;
    public Transform player;
    void Update()
    {
        // don’t try this at home
        Vector3 liftedPlayerPos = player.position + Vector3.up*lift;
        Vector3 delta = transform.position - liftedPlayerPos;
        delta = delta.normalized;
        delta *= distance;
        transform.position = liftedPlayerPos + delta;

        Vector3 realDelta = transform.position - player.position;
        transform.rotation = Quaternion.LookRotation(-realDelta, Vector3.up);
    }
}
