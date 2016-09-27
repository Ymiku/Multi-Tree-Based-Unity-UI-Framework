using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

namespace UIFrameWork
{
    public class UIManager:Singleton<UIManager>
    {
		public enum UILine
		{
			MainMenu,
			LevelMenu
		}
		public UIContext activeContext;
		public Dictionary<UILine,UIContext> _UILineDic = new Dictionary<UILine, UIContext>();

        public Dictionary<UIType, GameObject> _UIDict = new Dictionary<UIType,GameObject>();

        private Transform _canvas;

		public bool isQuit = false;

		public delegate void UIFunc();
		public Queue<UIFunc> funcQueue = new Queue<UIFunc>();
		private BlackEffect _blackEffect;
		public bool isBlackTrans = false;

        private UIManager()
        {
            _canvas = GameObject.Find("Canvas").transform;
			_blackEffect = Camera.main.GetComponent<BlackEffect> ();
            foreach (Transform item in _canvas)
            {
                GameObject.Destroy(item.gameObject);
            }
        }
		public void Push(BaseContext nextContext)
		{
			if (isBlackTrans) {
				funcQueue.Enqueue (delegate() {
					Push (nextContext);
				});
				return;
			}
			activeContext.Push (nextContext);
		}
		public void Pop()
		{
			if (isBlackTrans) {
				funcQueue.Enqueue (delegate() {
					Pop ();
				});
				return;
			}
			activeContext.Pop();
		}
		public void StartUILine(UILine line)
		{
			if (isBlackTrans) {
				funcQueue.Enqueue (delegate() {
					StartUILine (line);
				});
				return;
			}
			if (activeContext != null) {
				activeContext.LineExit ();
			}
			if (!_UILineDic.ContainsKey (line)) {
				_UILineDic.Add (line,new UIContext());
			}
			activeContext = _UILineDic[line];
			activeContext.LineStart ();
		}
		public void StartAndResetUILine(UILine line)
		{
			if (isBlackTrans) {
				funcQueue.Enqueue (delegate() {
					StartAndResetUILine (line);
				});
				return;
			}
			if (activeContext != null) {
				activeContext.LineExit ();
			}
			_UILineDic.AddOrReplace (line,new UIContext());
			activeContext = _UILineDic[line];
		}


        public GameObject GetSingleUI(UIType uiType)
        {
            if (_UIDict.ContainsKey(uiType) == false || _UIDict[uiType] == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(uiType.Path)) as GameObject;
                go.transform.SetParent(_canvas, false);
                go.name = uiType.Name;
                _UIDict.AddOrReplace(uiType, go);
				go.GetComponent<BaseView> ().Init();
                return go;
            }
            return _UIDict[uiType];
        }

        public void DestroySingleUI(UIType uiType)
        {
            if (!_UIDict.ContainsKey(uiType))
            {
                return;
            }

            if (_UIDict[uiType] == null)
            {
                _UIDict.Remove(uiType);
                return;
            }

            GameObject.Destroy(_UIDict[uiType]);
            _UIDict.Remove(uiType);
        }
		public void StartBlackTrans()
		{
			isBlackTrans = true;
		}
		public void Update()
		{
			if (isBlackTrans) {
				_blackEffect.count -= 4f * Time.deltaTime;
				if (_blackEffect.count <= 0f) {
					if (_blackEffect.count <= -1000f) {
						_blackEffect.count = 0f;
						isBlackTrans = false;
						foreach (var item in funcQueue) {
							item ();
						}
						funcQueue.Clear ();
					} else {
						_blackEffect.count -= 1000f;
					}
				}
			} else if(_blackEffect.count<1f&&GameManager.Instance.CanOperate()){
				_blackEffect.count += 4f * Time.deltaTime;
			}
		}
	}
}
