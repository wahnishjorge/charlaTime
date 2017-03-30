using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerState
{
	public Vector3 Position;
	public int AnimState;
	public bool Direction;

	public PlayerState(Vector3 xPosition, int xAnimState, bool xDirection)
	{
		Position = xPosition;
		AnimState = xAnimState;
		Direction = xDirection;
	}
}

public class Record : MonoBehaviour
{
	[SerializeField]
	private int _keyframe = 5;
	[SerializeField]
	private DummyPlayer _dummyPlayer;

	private Animator _anim;
	private List<PlayerState> _states = new List<PlayerState>();
	private bool _isRecording = true;
	private int _frameCounter = 0;
	private SpriteRenderer _sprite;

	public bool RecordActions
	{
		get { return _isRecording; }
		set { _isRecording = value; }
	}

	protected void Start()
	{
		_anim = GetComponent<Animator>();
		_sprite = GetComponent<SpriteRenderer>();
		_dummyPlayer.gameObject.SetActive(false);
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			_isRecording = false;
			_sprite.enabled = false;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			_isRecording = true;
			_sprite.enabled = true;
			transform.position = _dummyPlayer.gameObject.transform.position;
			_dummyPlayer.gameObject.SetActive(false);

		}
			

	}

	protected void FixedUpdate() //0.02 seconds por default --> 50 veces = 1 seg
	{
		if (_isRecording)
		{
			//10 frames por segundo son los que guardo entonces para no sobrecargar
			if (_frameCounter < _keyframe)
			{
				_frameCounter += 1;
			}
			else
			{
				_frameCounter = 0;
				//Debug.Log(" add state");
				_states.Add(new PlayerState(transform.position,
						_anim.GetCurrentAnimatorStateInfo(0).shortNameHash,
						transform.localScale.x > 0));
			}
		}
		else
		{
			if (_states.Count > 0)
			{
				//Debug.Log(" count " + _states.Count);
				SendState(_states[_states.Count - 1]);
				_states.RemoveAt(_states.Count - 1);
			}
			else
			{
				_isRecording = true;
				_sprite.enabled = true;
				transform.position = _dummyPlayer.gameObject.transform.position;
				_dummyPlayer.gameObject.SetActive(false);
			}
		}

		if (_states.Count > 200)
		{
			_states.RemoveAt(0);
		}
	}

	private void SendState(PlayerState xPlayerState)
	{
		_dummyPlayer.gameObject.SetActive(true);
		_dummyPlayer.SetState(xPlayerState);
	}
}
