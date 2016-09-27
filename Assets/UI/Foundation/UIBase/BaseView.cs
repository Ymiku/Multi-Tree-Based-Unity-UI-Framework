using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace UIFrameWork
{
	public abstract class BaseView : MonoBehaviour
    {
		void Awake()
		{
			#if UNITY_EDITOR
			Init();
			#endif
		}
		public virtual void Init()
		{

		}
        public virtual void OnEnter(BaseContext context)
        {
			
        }

        public virtual void OnExit(BaseContext context)
        {

        }

        public virtual void OnPause(BaseContext context)
        {

        }

        public virtual void OnResume(BaseContext context)
        {

        }
		public virtual void Excute()
		{

		}
		public virtual void PopCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.Pop ();
		}
		void Update()
		{
			Excute ();
		}
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
		public void PlaySound(int i)
		{
			AudioManager.Instance.Play (i);
		}
	}
}
