using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;

	public Text hp;
	//public Text maxHP;
	public Text lossText;
void Start(){
	lossText.GetComponent<Text>().enabled = false;
}
void Update () {
		hp.text = currentHealth.ToString();
		//maxHP.text = maxHealth.ToString();		
}

public void TakeDamage(int amount){
	currentHealth -= amount;
	if(currentHealth <= 0){
		currentHealth = 0;
		print("YOU DIED");
		}
	}

	public void Loss(){
		if(currentHealth == 0){
			print("Dead");
			lossText.GetComponent<Text>().enabled = true;
			Time.timeScale=0;
		}
	}
}
