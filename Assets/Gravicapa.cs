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

	[SerializeField]
	private FixHeight fixHeight;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Color activeColor;

	[SerializeField]
	private AudioSource audioSource;

	private Color defaultColor;

    // Use this for initialization
	void Start () {
		defaultColor = spriteRenderer.color;
	}

	private List<Rigidbody2D> colliders = new List<Rigidbody2D>();

    private List<Rigidbody2D> people = new List<Rigidbody2D>();

	private bool m_ForceUp;
	public bool ForceUp
	{
		get { return m_ForceUp; }
		set 
		{ 
			m_ForceUp = value; 
			if (value)
			{
				Hashtable tweenParams = new Hashtable();
				tweenParams.Add("from", spriteRenderer.color);
				tweenParams.Add("to", activeColor);
				tweenParams.Add("time", 0.3f);
				tweenParams.Add("onupdate", "OnColorUpdated");
				iTween.ValueTo(gameObject, tweenParams);
				audioSource.Play();
			}
			else
			{
				iTween.Stop(gameObject);

				Hashtable tweenParams = new Hashtable();
				tweenParams.Add("from", spriteRenderer.color);
				tweenParams.Add("to", defaultColor);
				tweenParams.Add("time", 0.1f);
				tweenParams.Add("onupdate", "OnColorUpdated");
				iTween.ValueTo(gameObject, tweenParams);
				audioSource.Stop();
			}
		}
	}

	private void OnColorUpdated(Color color)
	{
		spriteRenderer.color = color;
	}

	public bool ForceDown
	{
		get;
		set;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
			fixHeight.gpPosition = forcePoint.transform.position;

			fixHeight.gameObject.SetActive(ForceUp);

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
