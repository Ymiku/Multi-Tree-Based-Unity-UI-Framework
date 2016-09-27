using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UIFrameWork
{
	public abstract class EnabledView : BaseView 
	{
		private CanvasGroup _canvasGroup;
		public override void Init ()
		{
			base.Init ();
			_canvasGroup = GetComponent<CanvasGroup> ();
		}
		public override void OnEnter(BaseContext context)
		{
			gameObject.SetActive (true);
		}

		public override void OnExit(BaseContext context)
		{
			gameObject.SetActive (false);
		}

		public override void OnPause(BaseContext context)
		{
			_canvasGroup.blocksRaycasts = false;
		}

		public override void OnResume(BaseContext context)
		{
			_canvasGroup.blocksRaycasts = true;
		}
	}
}
