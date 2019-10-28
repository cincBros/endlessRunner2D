using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	
	public virtual void Interact() {
		Debug.Log("Interacting");
	}
	
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
			Interact();
        }
    }
}
