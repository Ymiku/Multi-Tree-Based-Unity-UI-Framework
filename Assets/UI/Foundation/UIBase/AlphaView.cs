using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UIFrameWork
{
	public abstract class AlphaView : BaseView 
	{
		private bool _isEnter = false;
		private CanvasGroup _canvasGroup;
		public override void Init ()
		{
			base.Init ();
			_canvasGroup = GetComponent<CanvasGroup> ();
		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter (context);
			_canvasGroup.alpha = 0f;
			_isEnter = true;
			_canvasGroup.blocksRaycasts = true;
			gameObject.SetActive (true);
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit (context);
			_isEnter = false;
			_canvasGroup.blocksRaycasts = false;
		}

		public override void OnPause(BaseContext context)
		{
			base.OnPause (context);
			_canvasGroup.blocksRaycasts = false;
		}

		public override void OnResume(BaseContext context)
		{
			base.OnResume (context);
			_canvasGroup.blocksRaycasts = true;
		}
		public override void Excute ()
		{
			base.Excute ();
			if (_isEnter && _canvasGroup.alpha < 1f) {
				_canvasGroup.alpha = Mathf.Lerp (_canvasGroup.alpha, 1f, 4f * Time.deltaTime);
			}
			if (!_isEnter) {
				_canvasGroup.alpha = Mathf.Lerp (_canvasGroup.alpha, 0f, 8f * Time.deltaTime);
				if (_canvasGroup.alpha <= 0.01f) {
					gameObject.SetActive (false);
				}
			}
				
			
		}
	}
}
