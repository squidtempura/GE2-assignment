using UnityEngine;

class FollowingLeader : State
{
    OffsetPursue offsetPursue;
    public override void Enter()
    {
        offsetPursue = owner.GetComponent<OffsetPursue>();
        offsetPursue.enabled = true;
        offsetPursue.leader = owner.GetComponent<ShipController>().leader;
    }

    public override void Think()
    {
        string tag;
        if (owner.gameObject.tag == "Enemy")
        {
            tag = "guard";
        }
        else
        {
            tag = "Enemy";
        }
        GameObject[] ships = GameObject.FindGameObjectsWithTag(tag);
        Debug.Log(ships[0]);
        foreach (GameObject ship in ships)
        {
            if (Vector3.Distance(owner.transform.position, ship.transform.position) <= 50)
            {
                ship.GetComponent<ShipController>().target = owner.gameObject;
                ship.GetComponent<StateMachine>().ChangeState(new Fleeing());
                owner.GetComponent<ShipController>().target = ship;
                owner.ChangeState(new Pursuing());
            }
        }
    }

    public override void Exit()
    {
        offsetPursue.enabled = false;
    }
}


class FindStation : State
{
    Pursue pursue;
    public override void Enter()
    {
        pursue = owner.GetComponent<Pursue>();
        pursue.enabled = true;
        owner.GetComponent<ShipController>().target = GameObject.Find("spacestation");
        pursue.target = owner.GetComponent<ShipController>().target.GetComponent<Boid>();

        if (owner.tag == "spacestation")
        {
            owner.GetComponent<NoiseWander>().enabled = true;
        }
    }

    public override void Think()
    {
        string tag;
        if (owner.tag == "spacestation")
        {
            tag = "Enemy";
        }
        else
        {
            if (owner.gameObject.tag == "Enemy")
            {
                tag = "guard";
                if (Vector3.Distance(owner.transform.position, pursue.target.transform.position) < 20)
                {
                    owner.ChangeState(new Pursuing());
                }
            }
            else
            {
                tag = "Enemy";
                if (Vector3.Distance(owner.transform.position, pursue.target.transform.position) < 20)
                {
                    owner.GetComponent<ShipController>().leader = pursue.target;
                    owner.ChangeState(new FollowingLeader());
                }
            }
        }


        GameObject[] ships = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject ship in ships)
        {
            if (Vector3.Distance(owner.transform.position, ship.transform.position) < 20)
            {
                ship.GetComponent<ShipController>().target = owner.gameObject;
                ship.GetComponent<StateMachine>().ChangeState(new Fleeing());
                owner.GetComponent<ShipController>().target = ship;
                owner.ChangeState(new Pursuing());
                break;
            }
        }

    }

    public override void Exit()
    {
        if (owner.tag == "spacestation")
        {
            owner.GetComponent<NoiseWander>().enabled = false;
        }
        pursue.enabled = false;
    }
}

class Pursuing : State
{
    Pursue pursue;
    public override void Enter()
    {
        pursue = owner.GetComponent<Pursue>();
        pursue.enabled = true;
        pursue.target = owner.GetComponent<ShipController>().target.GetComponent<Boid>();
    }

    public override void Think()
    {
        if (pursue.target.GetComponent<ShipController>().health <= 0)
        {
            owner.ChangeState(new FindStation());
        }
        if (pursue.target.gameObject == owner.gameObject)
        {
            owner.GetComponent<ShipController>().target = pursue.target.gameObject;
            owner.GetComponent<StateMachine>().ChangeState(new Fleeing());
        }
        if (Vector3.Distance(owner.transform.position, pursue.target.transform.position) < 2)
        {
            owner.ChangeState(new FindStation());
        }
        if (Vector3.Distance(owner.transform.position, pursue.target.transform.position) < 20)
        {
            owner.GetComponent<StateMachine>().ChangeState(new Attacking());
        }
    }

    public override void Exit()
    {
        pursue.enabled = false;
    }
}


class Fleeing : State
{

    Flee flee;
    GameObject spacestation;
    public override void Enter()
    {
        spacestation = GameObject.Find("spacestation");
        flee = owner.GetComponent<Flee>();
        flee.enabled = true;
        flee.targetGameObject = owner.GetComponent<ShipController>().target;
        int ifPlaySound = Random.Range(0, 5);
    }

    public override void Think()
    {
        if (owner.tag == "spacestation")
        {
            owner.ChangeState(new FindStation());
        }
        else
        {
            if (flee.target == null)
            {
                owner.ChangeState(new FindStation());
            }

            if (Vector3.Distance(owner.transform.position, spacestation.transform.position) > 100)
            {
                owner.ChangeState(new FindStation());
            }
        }

    }

    public override void Exit()
    {
        flee.enabled = false;
    }
}

public class Attacking : State
{
    public override void Enter()
    {
        owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
        }        
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) < 10)
        {
            owner.ChangeState(new Fleeing());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
    }
}

