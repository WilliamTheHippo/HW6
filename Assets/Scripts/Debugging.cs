using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.D))
    	{
    		Debug.Log(Physics2D.Raycast(transform.position, transform.up).collider.name);
    		Debug.Log(Physics2D.Raycast(transform.position, -transform.up).collider.name);
    	}
    }
}
