using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravicapa : MonoBehaviour {

	[SerializeField]
	private float forceValue;

	[SerializeField]
	private GameObject forcePoint;

	[SerializeField]
	private Collider2D rayCollider;

    [SerializeField]
    private float pickUpSpeed;

    // Use this for initialization
	void Start () {
		
	}

	private List<Rigidbody2D> colliders = new List<Rigidbody2D>();

    private List<Rigidbody2D> people = new List<Rigidbody2D>();

	public bool ForceUp
	{
		get;
		set;
	}

	public bool ForceDown
	{
		get;
		set;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
			if (ForceUp && GameCore.instance.stamina > 0)
			{
				AddForceForEachRocket(forceValue);
                PickUpAllPeople();
			}

			if (ForceDown)
			{
                
			}
	}

	private void AddForceForEachRocket(float force)
	{
		foreach (var elem in colliders)
		{
			if (elem != null)
			{
				var forceVector = (forcePoint.transform.position - elem.transform.position);
				var forceVectorNormalized = forceVector.normalized;
				//var distance = forceVector.sqrMagnitude;
				elem.AddForce(forceVectorNormalized * force, ForceMode2D.Force);
			}
		}
	}

    private void PickUpAllPeople()
    {
        foreach (var elem in people)
        {
            if (elem != null)
            {
                elem.transform.position = new Vector3(forcePoint.transform.position.x, elem.transform.position.y, elem.transform.position.z);
                elem.velocity = new Vector2(0, pickUpSpeed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Thrust>() != null)
		{
			colliders.Add(other.GetComponent<Rigidbody2D>());
		}
        if (other.gameObject.GetComponent<Human>() != null)
        {
            other.gameObject.GetComponent<Human>().IsCaptured = true;
            people.Add(other.GetComponent<Rigidbody2D>());
        }
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Thrust>() != null)
		{
			colliders.Remove(other.GetComponent<Rigidbody2D>());
		}
        if (other.gameObject.GetComponent<Human>() != null)
        {
            other.gameObject.GetComponent<Human>().IsCaptured = false;
            people.Remove(other.GetComponent<Rigidbody2D>());
        }
    }
}
