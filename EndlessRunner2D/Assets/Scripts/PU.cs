using UnityEngine;

[CreateAssetMenu(fileName = "New PU", menuName = "Inventory/PU")]
public class PU : ScriptableObject {
	
	new public string name = "New PU";
	public Sprite icon = null;
	public bool isDefault = false;
	
    public void Use()
    {
        Debug.Log("Using " + name);
    }

}
