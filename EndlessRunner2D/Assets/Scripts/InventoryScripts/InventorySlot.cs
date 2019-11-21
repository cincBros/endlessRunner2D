using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	
	public Image icon;
    public PU pu;

    private float scaleIncrease = 0.2f;		// Increase velocity
    private float scaleIncrease2 = 0.02f;	// Deceleration of increase velocity
    private bool waving = false;

    private Vector3 normalSize = new Vector3(1f, 1f, 1f);

    public void AddPU(PU newPU) {
        soundManager.PlaySound("addPU");
        pu = newPU;
		icon.sprite = pu.icon;
		icon.enabled = true;
		
		scaleIncrease = 0.2f;
        icon.transform.localScale = new Vector3(0f, 0f, 0f);
        waving = false;
		
		icon.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Cos(Inventory.instance.angleRot * Mathf.Deg2Rad) * 15f);
    }

    private void Update()
    {
        if (icon.enabled)
        {
            UpdateScale();
			
			icon.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Cos(Inventory.instance.angleRot * Mathf.Deg2Rad) * 15f);
        }
    }
	
	private void UpdateScale()
	{
		float x = icon.transform.localScale.x;
		float y = icon.transform.localScale.y;
		float z = icon.transform.localScale.z;

		if (!waving)
		{
			if (x < normalSize.x && y < normalSize.y)
			{
				x += scaleIncrease;
				y += scaleIncrease;
				scaleIncrease -= scaleIncrease2;
			}
			else
			{
				waving = true;
			}
		}
		else
		{
			scaleIncrease = Mathf.Cos(Inventory.instance.angleScale) * 0.002f;
			x += scaleIncrease;
			y += scaleIncrease;
		}

		icon.transform.localScale = new Vector3(x, y, z);
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
