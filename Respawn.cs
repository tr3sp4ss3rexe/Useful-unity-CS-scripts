using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleportplayer : MonoBehaviour
{
	public Transform teleportTarget;

	public Gameobject thePlayer;

	private void OnTriggerEnter(Collider other)
	{
		thePlayer.transform.position = teleportTarget.transform.position;
	}
}
