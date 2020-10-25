using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
	public GameObject ui;
    Button button;

    void Start()
    {
    	button = GetComponent<Button>();
    	button.onClick.AddListener(
    		() => ui.SetActive(!ui.activeInHierarchy)
    	);
    }

    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.Escape)) ui.SetActive(!ui.activeInHierarchy);
    }
}
