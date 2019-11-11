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
	
	// ATRIBUTES
	public int space = 2;
	public int count = 0;
	public PU[] pus;

    public Transform slotsParent;
    InventorySlot[] slots;


    // METHODS
    void Start() {
        pus = new PU[space];
        slots = new InventorySlot[space];
        for (int i=0; i<space; i++) {
            pus[i] = null;
		}
        count = 0;
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
    }
	
	void Update() {

        if (Input.GetButtonDown("UsePU1"))
        {
            if (pus[0] != null && canUse(pus[0].name))
            {
                Remove(0);
            }
		}
        else if (Input.GetButtonDown("UsePU2"))
        {
            if (pus[1] != null && canUse(pus[1].name))
            {
                Remove(1);
            }
		}
	}
	
	public bool Add(PU pu)
    {
        if (count >= space) {
			return false;
        }

        bool stop = false;
		int i = 0;
		while (i < space && !stop) {
			if (pus[i] == null)
            {
                pus[i] = pu;
                count++;
				stop = true;
			}
			else {
				i++;
			}
        }
        slots[i].AddPU(pus[i]);

        return true;
	}

    bool canUse(string name)
    {
        if (name == "casc")
        {
            return (!playerController.instance.teCasc);
        }
        else if (name == "molles")
        {
            return (!playerController.instance.teMolles);
        }
        else if (name == "pildora")
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

        pus[i] = null;
		count--;

        slots[i].UsePU();
        slots[i].ClearSlot();
    }
	
}
