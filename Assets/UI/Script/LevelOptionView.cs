using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
	
	public class LevelOptionView : AlphaView
	{
		private LevelOptionContext _context;
		private Image _fill;

		private bool _isShown = false;
		private Transform _shownTrans;
		private Transform _backTrans;
		private Transform _ResetTrans;
		private Text _count;
		private float _maxTime;
		private float _time;
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
			_context = context as LevelOptionContext;
			_maxTime = _context.time;
			_time = _maxTime;
			_fill = transform.Find ("Fill").GetComponent<Image>();
			_count = transform.Find ("Text").GetComponent<Text>();
			_shownTrans = transform.Find ("Shown");
			_backTrans = transform.Find ("Back");
			_ResetTrans = transform.Find ("Reset");
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit(context);
			_isShown = false;
		}

		public override void OnPause(BaseContext context)
		{
			base.OnPause(context);
		}

		public override void OnResume(BaseContext context)
		{
			base.OnResume(context);
		}
		public override void Excute ()
		{
			base.Excute ();
			_time -= Time.deltaTime;
			_fill.fillAmount = _time / _maxTime;
			_count.text = ((int)(_fill.fillAmount * 100)).ToString();
			if (_time <= 0f) {
				UIManager.Instance.Push (new LevelCompleteContext (0));
			}
			if (_isShown) {
				_backTrans.localScale = Vector3.Lerp (_backTrans.localScale,new Vector3(-1f,1f,1f),10f*Time.deltaTime);
				_ResetTrans.localScale = Vector3.Lerp (_ResetTrans.localScale,Vector3.one,10f*Time.deltaTime);
				_shownTrans.localEulerAngles = Vector3.Lerp (_shownTrans.localEulerAngles,new Vector3(0f,0f,90f),10f*Time.deltaTime);

			} else {
				_backTrans.localScale = Vector3.Lerp (_backTrans.localScale,Vector3.zero,10f*Time.deltaTime);
				_ResetTrans.localScale = Vector3.Lerp (_ResetTrans.localScale,Vector3.zero,10f*Time.deltaTime);
				_shownTrans.localEulerAngles = Vector3.Lerp (_shownTrans.localEulerAngles,new Vector3(0f,0f,0f),10f*Time.deltaTime);
			}
		}
		public void ShownCallBack()
		{
			_isShown = !_isShown;
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
			UIManager.Instance.StartUILine (UIManager.UILine.LevelMenu);
			UIManager.Instance.funcQueue.Enqueue (delegate(){
				LevelManager.Instance.Reset ();
			});
		}

	}
	public class LevelOptionContext :BaseContext
	{
		public float time;
		public  LevelOptionContext(float t = 60f) : base(UIType.LevelOption)
		{
			time = t;
		}
	}
}

