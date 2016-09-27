using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
    Multi-Tree-Based UIFramework
	made by Leo Liu
	based on MrNerverDie's UIFramework  https://github.com/MrNerverDie/Unity-UI-Framework
*/
namespace UIFrameWork
{
	public class UIRoot : MonoBehaviour {

        public void Start()
        {
            UIManager.Create();
            Localization.Create();
			UIManager.Instance.StartUILine (UIManager.UILine.MainMenu);
			UIManager.Instance.Push (new MainContext());
        }
		void Update()
		{
			UIManager.Instance.Update ();
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				if(!UIManager.Instance.isQuit)
				UIManager.Instance.Push (new QuitContext());
			}
		}
	}
}
