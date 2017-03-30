using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ejemplo01
{

	public class TimeManager : MonoBehaviour
	{
		private float _timeScale = 1;

		private static TimeManager _instance;

		public float TimeScale
		{
			get { return _timeScale; }
			set { _timeScale = value; }
		}

		public static TimeManager GetInstance()
		{
			return _instance;
		}

		protected void Awake()
		{
			_instance = this;
		}
	}

}