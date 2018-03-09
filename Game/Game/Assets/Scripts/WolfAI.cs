﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {
	public float moveSpeed;
	public Transform target;
	public int damage;

	void onTriggerStay(Collider other){
		if(other.gameObject.name == "Player"){
			transform.LookAt(target);
			transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
		}
	}


void OnCollisionEnter(Collision other){
	print("Wolf is attacking!");
	var hit = other.gameObject;
	var health = hit.GetComponent<PlayerHeath>();

	other.gameObject.GetComponent<PlayerHeath>();

	if(health != null){
		health.TakeDamage(damage);
		}
	}	
}
