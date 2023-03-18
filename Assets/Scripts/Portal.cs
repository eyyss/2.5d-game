using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public GameObject targetPortal;
	public Transform playerExitTransform;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			print("test");
			var player = other.gameObject; // transperntlýgýný kýsarak yap
			StartCoroutine(action());
			IEnumerator action()
			{
				player.GetComponent<PlayerMovementScript>().GetCharacterController().enabled = false;
				yield return new WaitForSeconds(3);
				player.transform.position = targetPortal.GetComponent<Portal>().playerExitTransform.position;
				player.GetComponent<PlayerMovementScript>().GetCharacterController().enabled = true;
			}

		}
	}

}
