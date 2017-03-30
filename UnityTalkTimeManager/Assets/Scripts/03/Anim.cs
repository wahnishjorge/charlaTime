using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ejemplo01;

public class Anim : MonoBehaviour
{
	private Animator _anim;

	protected void Start()
	{
		_anim = GetComponent<Animator>();
	}

	protected void Update()
	{
		_anim.speed = TimeManager.GetInstance().TimeScale;
	}
}
