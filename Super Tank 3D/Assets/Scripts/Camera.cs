using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private Vector3 offset;

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 dPos = target.position + offset;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, speed * Time.fixedDeltaTime);
            transform.position = sPos;
        }
    }
}
