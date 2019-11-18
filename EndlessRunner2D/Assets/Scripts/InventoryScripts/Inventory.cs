using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
	#region Singleton
	
	public static Inventory instance;
	
    public float angleScale = 0f;				// Angle for the waving movement
    private float angleScaleIncrease = 0.06f;	// Increase of the angle of the waving movement
	
	public float angleRot = 0f;			// Angle for the rotation movement
	private float angleRotIncrease = 2f;	// Increase of the angle of the rotation movement
	
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
            if (pus[0] != null && playerController.instance.CanUsePU(pus[0]) && !Slids.instance.IsFull())
            {
                Remove(0);
            }
		}
        else if (Input.GetButtonDown("UsePU2"))
        {
            if (pus[1] != null && playerController.instance.CanUsePU(pus[1]) && !Slids.instance.IsFull())
            {
                Remove(1);
            }
		}
		
		angleScale = angleScale%360 + angleScaleIncrease;
		angleRot = angleRot%360 + angleRotIncrease;
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

    public void Remove(int i) {

        if (pus[i] == null) { return; }

        pus[i] = null;
		count--;

        slots[i].UsePU();
        slots[i].ClearSlot();
    }
	
}
