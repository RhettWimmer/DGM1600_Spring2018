using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	void Start () {
		Time.timeScale = 1;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
		}
	}
}
