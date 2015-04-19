using UnityEngine;

namespace Assets
{
	public class UfoController : MonoBehaviour
	{
		[SerializeField]
		Rigidbody2D rigidBody;

		[SerializeField]
		Cursor cursor;

		[SerializeField]
		LineRenderer lr;

		[SerializeField]
		float forceScale;

		[SerializeField]
		Gravicapa gravicapa;

        [SerializeField]
        PukingPower pukan;

		void Start()
		{
			
		}

		void Update()
		{
			if (GameCore.instance.onPause)
				return;


			lr.SetPosition(0, transform.position);
			lr.SetPosition(1, cursor.transform.position);

            Vector2 force = (cursor.transform.position - transform.position) * forceScale;

            rigidBody.AddForceAtPosition( force, transform.forward, ForceMode2D.Impulse );

			if (Input.GetMouseButtonDown(0))
				gravicapa.ForceUp = true;

			if (Input.GetMouseButtonUp(0))
				gravicapa.ForceUp = false;

			//Debug.DrawLine(transform.position, cursor.transform.position, Color.red);
            pukan.ApplyThrust(force * -1.0f);
		}
	}
}
