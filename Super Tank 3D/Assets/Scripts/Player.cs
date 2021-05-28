using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : Tank
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedRotate;

    private Rigidbody rigidbody;
    private UI ui;
    private Level level;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        ui = FindObjectOfType<UI>();
        level = FindObjectOfType<Level>();
    }

    private void Start()
    {
        ui.SetBulletsText(bullets);
        ui.SetHealthText(Health);
    }

    public void Move(Vector3 input)
    {
        rigidbody.AddForce(transform.forward * input.z * speed, ForceMode.VelocityChange);

        rigidbody.AddRelativeTorque(Vector3.up * input.x * speedRotate, ForceMode.VelocityChange);
    }

    public override void Shoot()
    {
        if (canShoot && bullets > 0)
        {
            StartCoroutine(PlayerShooting());
        }
    }

    private IEnumerator PlayerShooting()
    {
        StartShoot();
        int i = 0;
        while (i < timeReload) {
            ui.ChangeReloadTimer(i, timeReload);
            yield return new WaitForSeconds(1);
            i++;
        }
        EndShoot();
    }

    public override void StartShoot()
    {
        base.StartShoot();
        ui.SetBulletsText(bullets);
    }

    public override void EndShoot()
    {
        ui.ChangeReloadTimer(timeReload, timeReload);
        base.EndShoot();
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        ui.SetHealthText(Health);
    }

    public override void Die()
    {
        base.Die();
        level.Lose();
    }
}
