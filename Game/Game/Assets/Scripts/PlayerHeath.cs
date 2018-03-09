﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;

	public Text hp;
	public Text maxHP;

void Update () {
		hp.text = currentHealth.ToString();
		maxHP.text = maxHealth.ToString();		
}

public void TakeDamage(int amount){
	currentHealth -= amount;
	if(currentHealth <= 0){
		currentHealth = 0;
		print("YOU DIED");
		}
	}
}
