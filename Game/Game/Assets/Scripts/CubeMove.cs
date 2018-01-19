using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {

	public float transX;
	public float transY;
	public float transZ;

	public float rotX;
	public float rotY;
	public float rotZ;

/*
	public int number = 10;
	private float percent = 0.25f;
	private double cheeseBurger = 0.5;
	public string firstName;
*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transX, transY, transZ);
		transform.Rotate(rotX, rotY, transZ);
		
	}
}
