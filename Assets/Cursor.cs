using UnityEngine;

namespace Assets
{
	public class Rectangle
	{
		public float top {get;set;}
		public float left {get; set;}
		public float bottom {get; set;}
		public float right{get; set;}
	}

	public class Cursor : MonoBehaviour
	{
		[SerializeField]
		private float altLimit = 0;

        private Vector3 bottomLeft;
        private Vector3 topRight;

		void Start()
		{
            bottomLeft = Camera.main.ScreenToWorldPoint( new Vector3( 0, 0, 0) ) + new Vector3(0,altLimit,0);
            topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));			
		}

		//public Vector3 clampedMouse { get; set; }

		void Update()
		{
			if (GameCore.instance.onPause)
				return;

            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var worldPos = new Vector3(Mathf.Clamp(mousePos.x, bottomLeft.x, topRight.x), Mathf.Clamp(mousePos.y, bottomLeft.y, topRight.y), mousePos.z);

            //Debug.Log(mousePos.y);

			//var worldPos = clampedMouse;
			worldPos.Set(worldPos.x, worldPos.y, 0);
			this.transform.position = worldPos;
		}
	}
}
