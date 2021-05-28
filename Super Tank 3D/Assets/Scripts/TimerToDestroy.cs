using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToDestroy : MonoBehaviour
{
    [SerializeField]
    private float timeToDestoy;

    private void Awake()
    {
        Destroy(gameObject, timeToDestoy);
    }
}
