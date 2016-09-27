using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace UIFrameWork
{
	

	public class AView : AnimateView
	{
		public override void Init ()
		{
			base.Init ();

		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);

		}

		public override void OnExit(BaseContext context)
		{

		}

		public override void OnPause(BaseContext context)
		{

		}

		public override void OnResume(BaseContext context)
		{

		}
		public override void Excute()
		{

		}
		public void BackCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.Pop ();
		}

	}

	public class AContext : BaseContext
	{
		public AContext() : base(UIType.LevelComplete)
		{

		}

	}
}
