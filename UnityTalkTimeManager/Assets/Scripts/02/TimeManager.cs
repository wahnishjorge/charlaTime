using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ejemplo02
{
	public class TimeManager : MonoBehaviour
	{
		[SerializeField]
		private float _slowMotion = 0.05f;
		private float _slowMoLenght = 2f;

		public void SlowMo()
		{
			Time.timeScale = _slowMotion;
			Time.fixedDeltaTime = Time.timeScale * _slowMotion;
		}


		protected void Update()
		{
			Time.timeScale += (1f / _slowMoLenght) * Time.unscaledDeltaTime;
			Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
		}
	}
}