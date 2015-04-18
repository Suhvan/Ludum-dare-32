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

		void Start()
		{
			
		}

		void Update()
		{
			lr.SetPosition(0, transform.position);
			lr.SetPosition(1, cursor.transform.position);

			rigidBody.AddForceAtPosition((cursor.transform.position - transform.position) * forceScale, transform.forward, ForceMode2D.Impulse);

			//Debug.DrawLine(transform.position, cursor.transform.position, Color.red);
		}
	}
}
