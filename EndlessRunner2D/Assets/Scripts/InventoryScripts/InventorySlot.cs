using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	
	public Image icon;
    public PU pu;

    private float scaleIncrease = 0.2f;
    private float scaleIncrease2 = 0.02f;
    private float angle = 0f;
    private float angleIncrease = 0.06f;
    private bool waving = false;

    const float factor = 0.002f;

    private Vector3 normalSize;

    public void Start()
    {
        normalSize = new Vector3(1f, 1f, 1f);
        icon.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void AddPU(PU newPU) {
        pu = newPU;
		icon.sprite = pu.icon;
		icon.enabled = true;
        icon.transform.localScale = new Vector3(0f, 0f, 0f);
        angle = 0f;
        scaleIncrease = 0.2f;
        waving = false;
    }

    public void Update()
    {
        if (icon.enabled)
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
                scaleIncrease = Mathf.Cos(angle) * factor;
                angle += angleIncrease;
                x += scaleIncrease;
                y += scaleIncrease;
            }

            //Debug.Log(x + " " + y + " " + scaleIncrease);
            icon.transform.localScale = new Vector3(x, y, z);
        }
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
