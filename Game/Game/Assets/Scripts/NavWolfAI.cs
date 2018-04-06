﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavWolfAI : MonoBehaviour {

	public Transform player;
	public float speed;
	//Detection
	public float wanderRadius;
	public float wanderTimer;
	public float alertDist;
	public float attackDist;

	private Animator state;
	private Vector3 direction;
	private Transform target;
	private UnityEngine.AI.NavMeshAgent agent;
	private float timer;
	private float distance;

	void OnEnable () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		timer = wanderTimer;
	}
	void Start () {
		state = GetComponent<Animator>();
	}

    void Update(){
		distance = Vector3.Distance(player.position, transform.position);
		//Alert
		if(distance < alertDist && distance > attackDist){
		print("Alert");
			state.SetBool("IsFollowing",true);
			state.SetBool("IsWandering",false);
			state.SetBool("IsAttacking",false);
		}
		//Attacking
		else if(distance <= alertDist){
		print("Attacking");
			direction = player.position - transform.position;
			direction.y = 0;

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),0.09f*Time.deltaTime);
			transform.Translate(Vector3.forward*speed*Time.deltaTime);

			state.SetBool("isFollowing",true);
			state.SetBool("isAttacking",false);
			state.SetBool("isWandering",false);

			if(direction.magnitude <= attackDist){
				state.SetBool("isFollowing",false);
				state.SetBool("isAttacking",true);
				state.SetBool("isWandering",false);
			}
		}
	//wandering
	else if(distance > alertDist){
	print("Wander");
		timer += Time.deltaTime;

			state.SetBool("isFollowing",false);
			state.SetBool("isAttacking",false);
			state.SetBool("isWandering",true);

		if (timer >= wanderTimer){
		Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
		agent.SetDestination(newPos);
		timer = 0;
			}
		}
	}
	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask){
		Vector3 randDirection = Random.insideUnitSphere * dist;
		
		randDirection += origin;
		
		UnityEngine.AI.NavMeshHit navHit;

		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		
		return navHit.position;
	}
}