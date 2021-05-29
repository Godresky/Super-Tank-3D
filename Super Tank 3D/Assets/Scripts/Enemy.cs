using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Tank
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float radiysViewField;
    [SerializeField]
    private float timeSearching;
    [SerializeField]
    private bool itSearch = false;
    [SerializeField]
    private bool itShootOfPlayer = false;
    [SerializeField]
    private List<Transform> placeDestinations;
    [SerializeField]
    private float speed;
    private int currentDestinations = 0;
    private bool inDestination = false;

    public UnityEvent DieEvent;

    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (player)
        {
            if (Vector3.Distance(transform.position, player.position) < radiysViewField)
            {
                transform.LookAt(player, Vector3.up);
                itShootOfPlayer = true;
                Shoot();
            }
            else if (itShootOfPlayer && !itSearch)
            {
                StopCoroutine(Searching());
                StartCoroutine(Searching());
            }

            if (!itShootOfPlayer && !itSearch)
            {
                if (inDestination)
                {
                    currentDestinations = ChooseDestination();
                    inDestination = false;
                }
                else
                {
                    transform.LookAt(placeDestinations[currentDestinations], Vector3.up);
                    transform.position = Vector3.MoveTowards(transform.position, placeDestinations[currentDestinations].position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, placeDestinations[currentDestinations].position) < 2)
                    {
                        inDestination = true;
                    }
                }
            }
        }
    }

    private int ChooseDestination()
    {
        int i = Random.Range(0, placeDestinations.Count);

        if (i == currentDestinations)
            i = ChooseDestination();

        return i;
    }

    public override void Die()
    {
        base.Die();
    }

    private IEnumerator Searching()
    {
        itShootOfPlayer = false;
        itSearch = true;
        yield return new WaitForSeconds(timeSearching);
        itSearch = false;
    }

    private void OnDestroy()
    {
        DieEvent.Invoke();
    }
}
