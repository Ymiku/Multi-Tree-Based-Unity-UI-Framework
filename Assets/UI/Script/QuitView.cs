using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace UIFrameWork
{
	public class QuitContext : BaseContext
	{
		public QuitContext() : base(UIType.Quit)
		{
			
		}

	}

	public class QuitView : AlphaView
	{
		public override void Init ()
		{
			base.Init ();

		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
			UIManager.Instance.isQuit = true;
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit (context);
			UIManager.Instance.isQuit = false;
		}

		public override void OnPause(BaseContext context)
		{
			base.OnPause (context);
		}

		public override void OnResume(BaseContext context)
		{
			base.OnResume (context);
		}
		public override void Excute()
		{
			base.Excute ();
		}
		public void QuitCallBack()
		{
			Application.Quit ();
		}

	}
}
