using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	public float zoomSpeed;
	public float leftLimit, rightLimit, upLimit, downLimit;

	void Start()
	{
		leftLimit = -8;
		rightLimit = 8;
		upLimit = 4;
		downLimit = -4;
	}

	public void ZoomOut(Vector3 position)
	{
		float x = Mathf.Round(position.x);
		float y = Mathf.Round(position.y);
		if(x < leftLimit) leftLimit = x;
		if(y < downLimit) downLimit = y;
		if(x > rightLimit) rightLimit = x;
		if(y > upLimit) upLimit = y;
		float camera_x = (leftLimit+rightLimit)/2;
		float camera_y = (upLimit+downLimit)/2;
		Camera.main.transform.position = new Vector3(camera_x, camera_y, -10f);
		float vertSize = (upLimit-downLimit)/2 + (9f/16f);
		float horizSize = ((rightLimit-leftLimit) * 9) / 32f;
		//multiplied by 9/16 because aspect ratio
		float size = vertSize > horizSize ? vertSize : horizSize;
		Camera.main.orthographicSize = size > 5 ? size : 5;
	}
}
