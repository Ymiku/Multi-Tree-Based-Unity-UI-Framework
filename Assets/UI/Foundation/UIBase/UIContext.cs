using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UIFrameWork
{
    public class UIContext
    {
        private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

		public void LineStart()
		{
			if (_contextStack.Count == 0)
				return;
			BaseView temp;
			foreach (BaseContext item in _contextStack) {
				temp = UIManager.Instance.GetSingleUI (item.ViewType).GetComponent<BaseView> ();
				temp.OnEnter (item);
				temp.OnPause (item);
			}

			BaseContext lastContext = _contextStack.Peek();
			BaseView curView = UIManager.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
			curView.OnResume(lastContext);
		}
		public void LineExit()
		{
			foreach (BaseContext item in _contextStack) {
				UIManager.Instance.GetSingleUI(item.ViewType).GetComponent<BaseView>().OnExit(item);
			}
		}
        public void Push(BaseContext nextContext)
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                BaseView curView = UIManager.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnPause(curContext);
            }
            _contextStack.Push(nextContext);
            BaseView nextView = UIManager.Instance.GetSingleUI(nextContext.ViewType).GetComponent<BaseView>();
			nextView.transform.SetAsLastSibling ();
            nextView.OnEnter(nextContext);
        }

        public void Pop()
        {
			
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                _contextStack.Pop();

                BaseView curView = UIManager.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
            }

            if (_contextStack.Count != 0)
            {
                BaseContext lastContext = _contextStack.Peek();
                BaseView curView = UIManager.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
                curView.OnResume(lastContext);
            }
        }

        public BaseContext PeekOrNull()
        {
            if (_contextStack.Count != 0)
            {
                return _contextStack.Peek();
            }
            return null;
        }
    }
}
