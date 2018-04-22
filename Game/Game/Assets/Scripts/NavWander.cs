﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavWander : MonoBehaviour {

	public float wanderRadius;
	public float wanderTimer;

	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;
	private float timer;

	public Transform enemy;
	public Transform chickenPen;

	public int  points; 
	public bool isWandering = true;


	void OnEnable(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> () ;
		timer = wanderTimer;
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= wanderTimer){
			Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
			agent.SetDestination(newPos);
			timer = 0;
		}
	}
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask){
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		UnityEngine.AI.NavMeshHit navHit;

		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}
	// 	//Chicken Interaction
	// 	void OnTriggerStay(Collider other){
	// 	if(other.gameObject.name == "Player"){
	// 		Debug.Log("Player has entered chickens trigger");
	// 		transform.LookAt(target);
	// 		transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);
	// 	}
		
	// }
	// void OnCollisionEnter(Collision other){
	// 	if(other.gameObject.name == "Player"){
	// 		transform.position = chickenPen.position;
	// 		transform.rotation =chickenPen.rotation;
	//	}


}
