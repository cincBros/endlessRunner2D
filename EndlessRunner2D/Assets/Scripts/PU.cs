using UnityEngine;

[CreateAssetMenu(fileName = "New PU", menuName = "Inventory/PU")]
public class PU : ScriptableObject {
	
	public new string name = "New PU";
	public Sprite icon = null;
    public float time = 0.0f;


}
