using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
	//instances, not prefabs!
	public GameObject[] thingsToStart;
	public Slider[] stop;
	Button button;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(
			() => StartAll()
		);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Space)) StartAll();
	}

	void StartAll()
	{
		foreach(GameObject thing in thingsToStart) thing.SetActive(true);
		foreach(Slider slider in stop) slider.interactable = false;
		this.gameObject.SetActive(false);
	}
}
