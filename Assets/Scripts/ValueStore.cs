using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueStore : MonoBehaviour
{
	public Slider speedSlider;
	public Slider hallwaySlider;
	public Slider linearitySlider;

	public float hallwayChance;
	public float delay;
	public float tileChance;
	public bool started;

	public List<Transform> tileList;

	public void Start()
	{
		started = false;
		tileList = new List<Transform>();
	}

	public void StoreHallwayChance(float v) {hallwayChance=v;}
	public void StoreDelay(float v) {delay=v;}
	public void StoreTileChance(float v) {tileChance=v;}
	public void SetStarted() {started = true;}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.R)) Reload.ReloadScene();

		if(Input.GetKeyDown(KeyCode.Q)) hallwaySlider.value -= 0.05f;
		if(Input.GetKeyDown(KeyCode.W)) hallwaySlider.value += 0.05f;

		if(Input.GetKeyDown(KeyCode.LeftBracket)) speedSlider.value += 0.05f;
		if(Input.GetKeyDown(KeyCode.RightBracket)) speedSlider.value -= 0.05f;

		if(Input.GetKeyDown(KeyCode.A)) linearitySlider.value -= 0.01f;
		if(Input.GetKeyDown(KeyCode.S)) linearitySlider.value += 0.01f;

		if(GameObject.FindGameObjectsWithTag("FloorMaker").Length == 0 && started)
			foreach(Transform tile in tileList) tile.GetComponent<Tile>().SpawnWalls();
	}
}
