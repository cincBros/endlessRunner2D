using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
	#region Singleton
	
	public static Inventory instance;
	
	void Awake() {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
		
		instance = this;
	}
	
	#endregion
	
	// TRIGGER
	public delegate void OnItemChanged(int i);
	public OnItemChanged onItemChangedCallback;
	
	
	// ATRIBUTES
	public int space = 2;
	public int count = 0;
	public PU[] pus;
	
	
	// METHODS
	void Start() {
        pus = new PU[space];
		for (int i=0; i<space; i++) {
            pus[i] = null;
		}
	}
	
	void Update() {
        
        if (Input.GetButtonDown("UsePU1")) {
			Remove(0);
		}
        else if (Input.GetButtonDown("UsePU2")) {
			Remove(1);
		}
	}
	
	public bool Add(PU pu) {
		if (!pu.isDefault) {
			if (count >= space) {
				Debug.Log("Not enough room.");
				return false;
			}
			
			//sps.Add(sp);
			bool stop = false;
			int i = 0;
			while (i < pus.Length && !stop) {
				if (pus[i] == null) {
                    pus[i] = pu;
					count++;
					stop = true;
				}
				else {
					i++;
				}
			}
			
			if (i < pus.Length && onItemChangedCallback != null) {
				onItemChangedCallback.Invoke(i);
			}
		}
		return true;
	}
	
	public void Remove(int i) {
		
		if (pus[i] == null) { return; }
		
		Debug.Log("Using " + pus[i].name);
        pus[i] = null;
		count--;
		
		if (i < pus.Length && onItemChangedCallback != null) {
			onItemChangedCallback.Invoke(i);
		}
	}
	
}
