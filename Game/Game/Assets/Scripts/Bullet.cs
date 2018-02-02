using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int damage = 1; //how much damage it does
	public int time = 5; //how long it lives before leaving

	void Start () {
		StartCoroutine(DestroyBullet());
	}
	
	void Update () {

		}
		
		IEnumerator DestroyBullet(){
			yield return new WaitForSeconds(time); 
			Destroy(gameObject);	
	}
}
