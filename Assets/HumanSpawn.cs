using UnityEngine;
using System.Collections;

public class HumanSpawn : MonoBehaviour {

    public GameObject HumanPref;
    public GameObject City;
    public GameObject DestinationPoint;

    public int SpawnLimit = 10;
    int Spawned = 0;

    public float SpawnCooldown = 5;
    public float SpawnDelay = 0;

    public float DestinationSpread = 0;
	// Use this for initialization
	void Start () {
	
	}

    void SpawnHuman()
    {
        GameObject humanObj = Instantiate(HumanPref, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        Human human = humanObj.GetComponent<Human>();
        human.SetDestination(DestinationPoint);
        human.gameObject.transform.parent = City.transform;
    }
	
	void Update () {
        SpawnDelay += Time.deltaTime;
        if (SpawnDelay > SpawnCooldown && ++Spawned <= SpawnLimit)
        {
            SpawnHuman();
            SpawnDelay = 0;
        }
	}
}
