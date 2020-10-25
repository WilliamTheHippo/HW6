using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
	Button button;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(
			() => ReloadScene()
		);
	}

	public static void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		FloorMaker.GLOBAL_TILE_COUNT = 0;
	}
}
