using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeToDie;
    [SerializeField]
    private float timeToOnCollider;
    [SerializeField]
    private GameObject explosion;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();

        StartCoroutine(TimeToDie());
        StartCoroutine(TimeToOnCollider());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(timeToDie);
        OnImpact();
    }

    public void OnImpact()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    private IEnumerator TimeToOnCollider()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(timeToOnCollider);
        collider.enabled = true;
    }
}
