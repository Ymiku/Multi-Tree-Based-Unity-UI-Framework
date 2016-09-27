using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 *	
 *  Base Context For View
 *
 *	by Xuanyi
 *
 */

namespace UIFrameWork
{
	public class BaseContext 
    {

        public UIType ViewType { get; private set; }

        public BaseContext(UIType viewType)
        {
            ViewType = viewType;
        }
	}
}
