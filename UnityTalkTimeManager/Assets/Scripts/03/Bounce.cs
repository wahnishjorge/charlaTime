using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ejemplo01;

public class Bounce : MonoBehaviour
{
	private Rigidbody _rb;
	private Vector3 _velocity;

	protected void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	protected void FixedUpdate()
	{
		_rb.AddForce(Physics.gravity * TimeManager.GetInstance().TimeScale);

		_velocity = _rb.velocity * TimeManager.GetInstance().TimeScale;

		_rb.velocity = _velocity;
	}
}
