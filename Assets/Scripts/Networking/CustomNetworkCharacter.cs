﻿using UnityEngine;
using System.Collections;

public class CustomNetworkCharacter : MonoBehaviour {

    public bool isVoting = false;

	private Vector3 correctPlayerPos = Vector3.zero; // We lerp towards this
	//private Quaternion correctPlayerRot = Quaternion.identity; // We lerp towards this
	// Update is called once per frame
	void Update()
	{
		/*if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			//transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		}*/
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position);
			//stream.SendNext(transform.rotation);
			Character myC= GetComponent<Character>();
			//stream.SendNext((int)myC._characterState);

		}
		else
		{
			// Network player, receive data
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			//this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
			
			Character myC= GetComponent<Character>();

			//myC._characterState = (CharacterState)stream.ReceiveNext();
		}
	}
}
