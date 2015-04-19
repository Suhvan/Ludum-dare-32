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
		private float altLimit = 10;

		private Rectangle rect;

		void Start()
		{
			rect = new Rectangle()
			{
				left = 0,
				top = Screen.height,
				right = Screen.width,
				bottom = 0 + altLimit,
			};
		}

		void Update()
		{
			if (GameCore.instance.onPause)
				return;

			var mousePos = Input.mousePosition;
			var clampedMouse = new Vector3(Mathf.Clamp(mousePos.x, rect.left, rect.right), Mathf.Clamp(mousePos.y, rect.bottom, rect.top), mousePos.z);

            //Debug.Log(mousePos.y);

			var worldPos = Camera.main.ScreenToWorldPoint(clampedMouse);
			worldPos.Set(worldPos.x, worldPos.y, 0);
			this.transform.position = worldPos;
		}
	}
}
