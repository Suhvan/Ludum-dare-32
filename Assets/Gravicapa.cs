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

	// Use this for initialization
	void Start () {
		
	}

	private List<Rigidbody2D> colliders = new List<Rigidbody2D>();

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
	void Update () 
	{
			if (ForceUp)
			{
				AddForceForEachRocket(forceValue);
			}

			if (ForceDown)
			{

			}
	}

	private List<Rigidbody2D> GetRocketsInside()
	{

		//rayCollider.OverlapPoint()
	}

	private void AddForceForEachRocket(float force)
	{
		foreach (var elem in colliders)
		{
			elem.AddForce((forcePoint.transform.position - elem.transform.position) * force, ForceMode2D.Force);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Thrust>() != null)
		{
			colliders.Add(other.GetComponent<Rigidbody2D>());
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Thrust>() != null)
		{
			colliders.Remove(other.GetComponent<Rigidbody2D>());
		}
	}
}
