﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int Hp;
	public float Speed;
	public float JumpForce;

	Rigidbody2D m_Body;
	PhotonView m_PhotonView;
    VotingView voteView;
	
	void Awake() 
	{
		//m_Animator = GetComponent<Animator>();
		m_Body = GetComponent<Rigidbody2D>();
		m_PhotonView = GetComponent<PhotonView>();
        voteView = this.gameObject.AddComponent<VotingView>();
        voteView.enabledButtons = false;
	}
	
	void Update() 
	{
	}
	
	void FixedUpdate()
	{
		if( m_PhotonView.isMine == false )
		{
			return;
		}
		
		UpdateMovement();
	}

	void UpdateMovement()
	{
		Vector2 movementVelocity = m_Body.velocity;
		
		if( Input.GetAxisRaw( "Horizontal" ) > 0.5f )
		{
			movementVelocity.x = Speed;
			
		}
		else if( Input.GetAxisRaw( "Horizontal" ) < -0.5f )
		{
			movementVelocity.x = -Speed;
		}
		else
		{
			movementVelocity.x = 0;
		}
		
		m_Body.velocity = movementVelocity;
	}

	public void ReceiveDamages(int atq){
		
	}

	void Vote(){
		#if UNITY_ANDROID 
		
		#endif
	}
    //enable voting
    public void EnableVoting()
    { 
        //show buttons here

        voteView.enabledButtons = true;
    
    }
    /// <summary>
    ///  disable buttons and show place holder instead
    /// </summary>
    public void DisableVoting()
    {
        voteView.enabledButtons = false;
    }
	

}
