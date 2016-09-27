using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace UIFrameWork
{
	public class LevelSelectContext : BaseContext
	{
		public LevelSelectContext() : base(UIType.LevelSelect)
		{

		}
	}

	public class LevelSelectView : AnimateView
	{



		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
			gameObject.SetActive (true);
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit(context);
			gameObject.SetActive (false);
		}

		public override void OnPause(BaseContext context)
		{
			
		}

		public override void OnResume(BaseContext context)
		{
			
		}
		public void SelectCallBack(int i)
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			if (i >= 0) {
				UIManager.Instance.StartBlackTrans ();
				UIManager.Instance.StartAndResetUILine (UIManager.UILine.LevelMenu);
				UIManager.Instance.Push (new LevelOptionContext ());
				LevelManager.Instance.LevelStart (i);
			}
		}
		public override void PopCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.StartBlackTrans ();
			UIManager.Instance.Pop ();
		}
	}
}
