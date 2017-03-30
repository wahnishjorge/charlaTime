using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ejemplo01;

public class PlayerInput : MonoBehaviour
{
	private TimeManager _timeManager;
	private float _targetScale;
	private float _lerpSpeed = 2;
	private bool _mouseMovement = false;

	protected void Start()
	{
		_timeManager = TimeManager.GetInstance();
	}

	protected void Update()
	{
		float sMouseX = Input.GetAxis("Mouse X");
		float sMouseY = Input.GetAxis("Mouse Y");

		if (sMouseX != 0 || sMouseY != 0)
		{
			_mouseMovement = true;
			_targetScale = 0.5f;
			_lerpSpeed = 10;
		}

		if (Input.anyKey)
		{
			_targetScale = 1;
			_lerpSpeed = 10;
		}
		else if (!_mouseMovement)
		{
			_targetScale = 0;
			_lerpSpeed = 4;
		}

		_timeManager.TimeScale = Mathf.Lerp(_timeManager.TimeScale, _targetScale, Time.deltaTime * _lerpSpeed);

		_mouseMovement = false;
	}
}
