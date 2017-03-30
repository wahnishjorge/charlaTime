using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
	private Animator _anim;

	protected void Start()
	{
		_anim = GetComponent<Animator>();
	}

	public void SetState(PlayerState xPlayerState)
	{
		transform.position = xPlayerState.Position;
		_anim.Play(xPlayerState.AnimState);
		Vector3 sLocalScale = transform.localScale;
		sLocalScale.x = xPlayerState.Direction ? Mathf.Abs(sLocalScale.x) :
			-Mathf.Abs(sLocalScale.x);
		transform.localScale = sLocalScale;
	}
}
