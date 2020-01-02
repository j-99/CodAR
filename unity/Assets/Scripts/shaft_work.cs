using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaft_work : MonoBehaviour {

	public Animator anim;

	void Start(){
		anim = gameObject.GetComponent<Animator>();
	}
	void OnTriggerEnter (Collider col){
		if(col.gameObject.tag == "Player"){
			anim.SetBool("activate", true);
		}
		Debug.Log("Motor Connected");
	}

	void OnTriggerExit (Collider col){
		if(col.gameObject.tag == "Player"){
			anim.SetBool("activate", true);
		}
	}
}
