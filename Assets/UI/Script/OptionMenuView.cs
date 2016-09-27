using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class OptionMenuContext :BaseContext
    {
        public OptionMenuContext() : base(UIType.OptionMenu)
        {

        }
    }

    public class OptionMenuView : AlphaView
    {
		private Scrollbar _volumeBar;
		public override void Init ()
		{
			base.Init ();
			_volumeBar = transform.Find ("VolumeBar").GetComponent<Scrollbar>();
		}
        public override void OnEnter(BaseContext context)
        {
            base.OnEnter(context);
			_volumeBar.value = GameManager.Instance.GetVolume ();
        }

        public override void OnExit(BaseContext context)
        {
            base.OnExit(context);
        }

        public override void OnPause(BaseContext context)
        {
            base.OnPause(context);
        }

        public override void OnResume(BaseContext context)
        {
            base.OnResume(context);
        }
			
		public void VolumeChange()
		{
			GameManager.Instance.SetVolume (_volumeBar.value);
		}
        
    }
}

