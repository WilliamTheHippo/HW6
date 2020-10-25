using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	//public float zoomSpeed;
	float leftLimit, rightLimit, upLimit, downLimit;

	public ValueStore valueStore;

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
		float vertSize = (upLimit-downLimit)/2 + (9f/16f);
		float horizSize = ((rightLimit-leftLimit) * 9) / 32f;
		//multiplied by 9/16 because aspect ratio
		float size = vertSize > horizSize ? vertSize : horizSize;
		size += 0.2f; //to be safe
		//Camera.main.transform.position = new Vector3(camera_x, camera_y, -10f);
		//Camera.main.orthographicSize = size > 5 ? size : 5;
		StartCoroutine(Pan(camera_x, camera_y));
		StartCoroutine(Zoom(size));
	}

	IEnumerator Pan(float x, float y)
	{
		if(valueStore.delay == 0)
		{
			Camera.main.transform.position = new Vector3(x, y, -10f);
			yield return null;
		}
		else for(float i = 0; i < 1; i += 0.01f)
		{
			Camera.main.transform.position = new Vector3(
				Mathf.Lerp(Camera.main.transform.position.x, x, i),
				Mathf.Lerp(Camera.main.transform.position.y, y, i),
				-10
			);
			yield return new WaitForSeconds(valueStore.delay/100);
		}
	}

	IEnumerator Zoom(float s)
	{
		if(valueStore.delay == 0)
		{
			Camera.main.orthographicSize = s > 5 ? s : 5;
			yield return null;
		}
		else for(float i = 0; i < 1; i += 0.01f)
		{
			Camera.main.orthographicSize = s > 5 ?
				Mathf.Lerp(Camera.main.orthographicSize, s, i) : 5;
			yield return new WaitForSeconds(valueStore.delay / 100);
		}
	}
}
