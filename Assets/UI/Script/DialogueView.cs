using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
	public class DialogueContext :BaseContext
	{
		public string[] noticeArray;
		public  DialogueContext(string[] sArray) : base(UIType.Dialogue)
		{
			noticeArray = sArray;
		}
	}

	public class DialogueView : EnabledView
	{
		private DialogueContext _context;
		public GameObject noticePanel;
		private float alpha = 0f;
		private Image _noticeBack;
		private Text _noticeText;
		public bool hasNotice = false;
		private Queue<string> noticeQueue = new Queue<string>();
		public override void Init ()
		{
			base.Init ();
			noticePanel = transform.Find("Dialogue").gameObject;
			noticePanel.SetActive (false);
			_noticeBack = noticePanel.GetComponent<Image> ();
			_noticeText = noticePanel.transform.Find ("Text").GetComponent<Text> ();
		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
			_context = context as DialogueContext;
			for (int i = 0; i < _context.noticeArray.Length; i++) {
				noticeQueue.Enqueue (_context.noticeArray[i]);
			}
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit(context);
		}

		public override void OnPause(BaseContext context)
		{
			base.OnPause(context);
			string[] sTemp = new string[noticeQueue.Count];
			for (int i = 0; i < noticeQueue.Count; i++) {
				sTemp [i] = noticeQueue.Dequeue ();
			}
			_context.noticeArray = sTemp;
		}

		public override void OnResume(BaseContext context)
		{
			base.OnResume(context);
			_context = context as DialogueContext;
			for (int i = 0; i < _context.noticeArray.Length; i++) {
				noticeQueue.Enqueue (_context.noticeArray[i]);
			}
		}
		public override void Excute ()
		{
			base.Excute ();
			if (hasNotice) {
				if (noticePanel.activeSelf == false) {
					alpha = 0f;
					_noticeText.text = noticeQueue.Dequeue ();
					noticePanel.SetActive (true);
				}
				alpha = Mathf.Lerp (alpha,1f,10f*Time.deltaTime);
				SetNoticeAlpha (alpha);
				if (Input.GetMouseButtonDown (0)) {
					if (noticeQueue.Count > 0) {
						_noticeText.text = noticeQueue.Dequeue ();
					} else {
						hasNotice = false;
					}
				}
				return;
			} else {
				if (noticePanel.activeSelf == true) {
					alpha = Mathf.Lerp (alpha,0f,10f*Time.deltaTime);
					SetNoticeAlpha (alpha);
					if(alpha<=0.001f)
						noticePanel.SetActive (false);
				}
			}
		}
		private void SetNoticeAlpha(float a)
		{
			_noticeBack.color = new Color(_noticeBack.color.r,_noticeBack.color.g,_noticeBack.color.b,a);
			_noticeText.color = new Color(_noticeText.color.r,_noticeText.color.g,_noticeText.color.b,a);
		}
		public void AddNotice(string s)
		{
			noticeQueue.Enqueue (s);
		}
		public void StartNotice()
		{
			hasNotice = true;
		}
	}
}

