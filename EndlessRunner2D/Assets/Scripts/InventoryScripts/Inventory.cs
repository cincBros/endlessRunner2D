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
        count = 0;
    }
	
	void Update() {

        if (count == 0) return;

        if (Input.GetButtonDown("UsePU1")) {
			if (canUse(pus[0].name)) Remove(0);
		}
        else if (Input.GetButtonDown("UsePU2")) {
            if (canUse(pus[1].name)) Remove(1);
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
			while (i < space && !stop) {
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

    bool canUse(string namePU)
    {
        Debug.Log("canUse " + playerController.instance.teCasc);
        if (namePU == "casc")
        {
            return (!playerController.instance.teCasc);
        }
        else if (namePU == "molles")
        {
            return (!playerController.instance.teMolles);
        }
        else if (namePU == "pildora")
        {
            return (!playerController.instance.tePildora);
        }
        else
        {
            return true;
        }
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
