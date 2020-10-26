using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public Transform wallPrefab;

	ValueStore valueStore;
	SpriteRenderer sr;

	void Start()
	{
		valueStore = GameObject.Find("ValueStore").GetComponent<ValueStore>();
		sr = GetComponent<SpriteRenderer>();
		if(valueStore.easterEggActive) EasterEgg();
	}

	public void SpawnWalls()
	{
		RaycastHit2D up = Physics2D.Raycast(transform.position, transform.up, 0.8f);
		RaycastHit2D down = Physics2D.Raycast(transform.position, -transform.up, 0.8f);
		RaycastHit2D left = Physics2D.Raycast(transform.position, -transform.right, 0.8f);
		RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, 0.8f);
		if(up.collider == null)
			Instantiate(wallPrefab, transform.position + transform.up/2, Quaternion.identity);
		if(down.collider == null)
			Instantiate(wallPrefab, transform.position - transform.up/2, Quaternion.identity);
		if(left.collider == null)
			Instantiate(wallPrefab, transform.position - transform.right/2, Quaternion.Euler(0,0,90));
		if(right.collider == null)
			Instantiate(wallPrefab, transform.position + transform.right/2, Quaternion.Euler(0,0,90));
	}

	public void EasterEgg()
	{
		sr.sprite = valueStore.easterEgg;
		sr.color = new Color(1f,1f,1f);
		if(Random.Range(0f,1f) > 0.5f) sr.flipX = !sr.flipX;
	}
}
