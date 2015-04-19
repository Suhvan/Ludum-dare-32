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

        public int lifeState = -1;
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

            if (GameCore.instance.UFODamage != lifeState)
            {
                lifeState = GameCore.instance.UFODamage;
                SwitchPukan();
            }
            pukan.ApplyThrust(force * -1.0f);
		}

        public void SwitchPukan()
        {
            switch (lifeState)
            { 
                case 0:
                    pukan.gameObject.SetActive(false);
                    break;
                case 1:
                    pukan.gameObject.SetActive(true);
                    break;
               case 2:
                    pukan.ps.startSize = 0.5f;
                    break;
                case 3:
                    pukan.ps.startSize = 1f;
                    pukan.ps.startColor = Color.grey;
                    break;
                case 4:
                    pukan.ps.startColor = Color.black;
                    break;
                default:
                    break;
            }
        }
	}
}
