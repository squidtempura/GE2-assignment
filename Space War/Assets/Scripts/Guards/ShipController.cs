using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int health = 10;
    public GameObject target;
    public Boid leader;
    public bool isLeader = false;
    public GameObject[] fireingPoints;
    public GameObject Bullet;
    //public Spawner spawner;
    
    void Start()
    {
        if (tag != "spacestation")
        {
            if (isLeader)
            {
                leader = GetComponent<Boid>();
                GetComponent<StateMachine>().ChangeState(new FindStation());
            }
            else
            {
                if (transform.parent.gameObject.name.Contains("Enemy"))
                {
                    leader = transform.parent.Find("EnemyLeader").gameObject.GetComponent<Boid>();
                }
                else
                {
                    leader = transform.parent.Find("GuardLeader").gameObject.GetComponent<Boid>();
                }

                GetComponent<StateMachine>().ChangeState(new FollowingLeader());
            }
        }

    }

    private void Update()
    {
        if (health <= 0 && tag != "spacestation")
        {
            gameObject.SetActive(false);
        }
    }
}

