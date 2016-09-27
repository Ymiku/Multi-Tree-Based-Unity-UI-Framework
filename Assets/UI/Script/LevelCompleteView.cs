using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace UIFrameWork
{
	public class LevelCompleteContext : BaseContext
	{
		public int starNum = 1;
		public LevelCompleteContext() : base(UIType.LevelComplete)
		{
			starNum = 3;
		}
		public LevelCompleteContext(int i) : base(UIType.LevelComplete)
		{
			starNum = i;
		}
	}

	public class LevelCompleteView : AnimateView
	{
		private Transform _star1;
		private Transform _star2;
		private Transform _star3;
		private LevelCompleteContext _context;
		public override void Init ()
		{
			base.Init ();

		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
			gameObject.SetActive (true);
			_context = context as LevelCompleteContext;
			_star1 = transform.Find ("Star1");
			_star2 = transform.Find ("Star2");
			_star3 = transform.Find ("Star3");
			_star1.gameObject.SetActive (false);
			_star2.gameObject.SetActive (false);
			_star3.gameObject.SetActive (false);
			if (_context.starNum >= 1) {
				_star1.gameObject.SetActive (true);
			}
			if (_context.starNum >= 2) {
				_star2.gameObject.SetActive (true);
			}
			if (_context.starNum >= 3) {
				_star3.gameObject.SetActive (true);
			}
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
		public override void Excute()
		{
			
		}
		public void BackCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.StartBlackTrans ();
			UIManager.Instance.StartUILine (UIManager.UILine.MainMenu);
			UIManager.Instance.funcQueue.Enqueue (delegate() {
				LevelManager.Instance.LevelEnd ();
			});
		}
		public void ResetCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.StartBlackTrans ();
			UIManager.Instance.StartAndResetUILine (UIManager.UILine.LevelMenu);
			UIManager.Instance.Push (new LevelOptionContext ());
			UIManager.Instance.funcQueue.Enqueue (delegate() {
				LevelManager.Instance.Reset ();
			});
		}
		public void NextCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.StartBlackTrans ();
			UIManager.Instance.StartAndResetUILine (UIManager.UILine.LevelMenu);
			UIManager.Instance.Push (new LevelOptionContext ());
			UIManager.Instance.funcQueue.Enqueue (delegate() {
				LevelManager.Instance.LoadNext ();
			});
		}
	}
}
