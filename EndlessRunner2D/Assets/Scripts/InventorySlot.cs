using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	
	public Image icon;
    public PU pu;
	
	public void AddPU(PU newPU) {
        pu = newPU;
		icon.sprite = pu.icon;
		icon.enabled = true;
	}
	
	public void ClearSlot() {
        pu = null;
		icon.sprite = null;
		icon.enabled = false;
	}

    public void UsePU()
    {
        if (pu != null)
        {
            pu.Use();
        }
    }
}
