using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://indienova.com/u/root/blogread/1766

public class FloorMaker : MonoBehaviour
{
	public Transform floorPrefab;
	public Transform floorMakerPrefab;
	
	public int maxTiles;
	public static int GLOBAL_TILE_COUNT;

	CameraZoom cameraZoom;
	ValueStore valueStore;

	int myCounter; //how many tiles have we instantiated?

	void Start()
	{
		myCounter = 0;
		cameraZoom = Camera.main.GetComponent<CameraZoom>();
		//tileList = new List<Transform>();
		valueStore = GameObject.Find("ValueStore").GetComponent<ValueStore>();
		valueStore.SetStarted();
		StartCoroutine("SpawnFloor");
	}

	IEnumerator SpawnFloor()
	{
		while(myCounter < maxTiles && GLOBAL_TILE_COUNT <= 500)
		{
			float random = Random.Range(0f,1f);
			float c = 0.38f - valueStore.hallwayChance;
			if(random < c) transform.Rotate(0,0,90); //.1f for long hallways
			else if(random < c*2) transform.Rotate(0,0,-90); //,2f for long hallways
			if(random > 1f-valueStore.tileChance) Instantiate(floorMakerPrefab, transform.position, Quaternion.identity);
			valueStore.tileList.Add(Instantiate(floorPrefab, transform.position, Quaternion.identity));
			transform.position += transform.up; //already normalized
			myCounter++;
			GLOBAL_TILE_COUNT++;
			cameraZoom.ZoomOut(transform.position);
			yield return new WaitForSeconds(valueStore.delay);
		}
		//foreach(Transform tile in tileList) tile.GetComponent<Tile>().SpawnWalls();
		Destroy(this.gameObject);
	}
}

// speed slider with IEumerator and lerps?