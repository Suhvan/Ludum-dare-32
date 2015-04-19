using UnityEngine;
using System.Collections;

public class FixHeight : MonoBehaviour {

	private float fixedHeight;

	void Awake()
	{
		fixedHeight = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var oldPos = this.transform.position;
		oldPos.Set(oldPos.x, fixedHeight, oldPos.z);
		this.transform.position = oldPos;
	}
}
