using UnityEngine;
using System.Collections;
using Assets;

public class PseudoParallax : MonoBehaviour {

	[SerializeField]
	UfoController controller;

	[SerializeField]
	private float moveAmplitude;

	Vector3 defaultPos;

	void Awake()
	{
		defaultPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {

		var screenCoords = Camera.main.WorldToScreenPoint(controller.transform.position);

		float relativePos = ((screenCoords.x / Screen.width) - 0.5f) * -2;

		//float relativePos =  ((cursor.clampedMouse.x / Screen.width ) - 0.5f) * 2;

		Vector3 newPos = this.transform.position;

		newPos.Set(defaultPos.x + moveAmplitude * relativePos, newPos.y, newPos.z);

		this.transform.position = newPos;
	}
}
