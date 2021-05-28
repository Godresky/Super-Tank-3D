using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private bool canDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            bullet.OnImpact();
            if (canDestroy)
                Destroy(gameObject);
        }
    }
}
