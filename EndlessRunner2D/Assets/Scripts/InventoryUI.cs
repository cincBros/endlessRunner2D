using UnityEngine;

public class InventoryUI : MonoBehaviour {
	
	public Transform spParent;
	Inventory inventory;
	InventorySlot[] slots = new InventorySlot[8];
	
    // Start is called before the first frame update
    void Start() {
        inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
		slots = spParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update() {
		
    }
	
	void UpdateUI(int i) {
		if (slots[i].pu == null) {
			slots[i].AddPU(inventory.pus[i]);
		}
		else {
			slots[i].ClearSlot();
		}
	}
	 
}
