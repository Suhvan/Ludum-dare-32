using UnityEngine;

namespace Assets
{
	public class Cursor : MonoBehaviour
	{
		void Update()
		{
			if (GameCore.instance.onPause)
				return;

			var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPos.Set(worldPos.x, worldPos.y, 0);
			this.transform.position = worldPos;
		}
	}
}
