using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public int bullets;
    public float timeReload;
    public bool canShoot = true;

    public ParticleSystem shootEffect;
    public Transform placeSpawnBullets;
    public GameObject bulletPrefab;

    [SerializeField]
    private float health;
    [SerializeField]
    private GameObject diedTank;

    public virtual float Health
    {
        get => health;
        set
        {
            health = value;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public virtual void Shoot()
    {
        if (canShoot && bullets > 0)
        {
            StartCoroutine(Shooting());
        }
    }

    public virtual void Die()
    {
        Instantiate(diedTank, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public IEnumerator Shooting()
    {
        StartShoot();
        int i = 0;
        while (i < timeReload)
        {
            yield return new WaitForSeconds(1);
            i++;
        }
        EndShoot();
    }

    public virtual void StartShoot()
    {
        canShoot = false;
        shootEffect.Play();
        bullets--;
        Instantiate(bulletPrefab, placeSpawnBullets.position, placeSpawnBullets.rotation);
    }

    public virtual void EndShoot()
    {
        canShoot = true;
    }
    
    public virtual void GetDamage(float damage)
    {
        Health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            bullet.OnImpact();
            GetDamage(25);
        }
    }
}
