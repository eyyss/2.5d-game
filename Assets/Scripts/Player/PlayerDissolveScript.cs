using UnityEngine;

public class PlayerDissolveScript : MonoBehaviour
{
	public Material playerMaterial;
	public Renderer[] all;
	private void OnValidate()
	{
		foreach (var r in all)
		{
			r.material = playerMaterial;
		}
	}
}
