using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://indienova.com/u/root/blogread/1766

public class FloorMaker : MonoBehaviour
{
	public Transform floorPrefab;
	public Transform floorMakerPrefab;
	public CameraZoom cameraZoom;
	public float percentTileChance;
	public int maxTiles;

	public static int GLOBAL_TILE_COUNT;

	int myCounter; //how many tiles have we instantiated?

	void Start()
	{
		myCounter = 0;
		cameraZoom = Camera.main.GetComponent<CameraZoom>();
	}

	void Update ()
	{
		if(myCounter < maxTiles && GLOBAL_TILE_COUNT < 500)
		{
			float random = Random.Range(0f,1f);
			if(random < .25f) transform.Rotate(0,0,90); //.1f for long hallways
			else if(random < .5f) transform.Rotate(0,0,-90); //,2f for long hallways
			if(random > 1f-(percentTileChance/100)) Instantiate(floorMakerPrefab, transform.position, Quaternion.identity);
			Instantiate(floorPrefab, transform.position, Quaternion.identity);
			transform.position += transform.up; //already normalized
			myCounter++;
			GLOBAL_TILE_COUNT++;
			cameraZoom.ZoomOut(transform.position);
		}
		else Destroy(this.gameObject);
	}
}

// add some sprites?
// speed slider with IEumerator and lerps?
// variable generation? (hallways vs rooms)

// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// after all floor tiles are placed, add a "wall pass"
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan