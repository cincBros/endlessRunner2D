using UnityEngine;

[CreateAssetMenu(fileName = "New PU", menuName = "Inventory/PU")]
public class PU : ScriptableObject {
	
	public new string name = "New PU";
	public Sprite icon = null;
    public float time = 0.0f;


    public void Use()
    {
        if (name == "casc")
        {
            soundManager.PlaySound("getCasc");
            playerController.instance.activarCasc(true);
        }
        else if (name == "molles")
        {
            playerController.instance.activarMolles(true);
            Slids.instance.AddSlider(this);
        }
        else if (name == "pildora")
        {
            soundManager.PlaySound("getPildora");
            playerController.instance.activarPildora(true);
            Slids.instance.AddSlider(this);
        }
        else if (name == "relantitzador")
        {
            playerController.instance.activarRelan(true);
            spawnerH.instance.speed *= 0.5f;
            spawnerH.instance.respawnTime *= 2.0f;
            Slids.instance.AddSlider(this);
        }

    }

}
