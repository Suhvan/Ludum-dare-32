using UnityEngine;
using System.Collections;

public class HumanSpawn : MonoBehaviour {

    public GameObject HumanPref;
    public GameObject City;
    public GameObject DestinationPoint;


    public int SpawnLimit = 8;

    int m_spawned = 0;
    int Spawned
    {
        get
        {
            return m_spawned;
        }

        set
        {
            Debug.Log("Spawned " + value);
            m_spawned = value;
        }
    }

    public int CountUnspawned()
    {
        return SpawnLimit - Spawned;
    }

    public float SpawnCooldown = 5;
    public float SpawnDelay = 0;

    public float DestinationSpread = 0;
	// Use this for initialization
    public void OnDamaged()
    {
        ++Spawned;
    }

	void Start () {
	
	}

    void SpawnHuman()
    {
        if (Spawned < SpawnLimit)
        {
            GameObject humanObj = Instantiate(HumanPref, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
            Human human = humanObj.GetComponent<Human>();
            human.SetDestination(DestinationPoint);
            human.gameObject.transform.parent = City.transform;
            ++Spawned;
        }
    }
	
	void Update () {
        SpawnDelay += Time.deltaTime;
        if (SpawnDelay > SpawnCooldown)
        {
            SpawnHuman();
            SpawnDelay = 0;
        }
	}
}
