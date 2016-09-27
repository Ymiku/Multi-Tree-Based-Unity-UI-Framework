using UnityEngine;
using System.Collections;

public class UnitySingleton<T> : MonoBehaviour 
  where T:Component
{
	private static T _Instance;
	public static T Instance
	{
		get{
			if(_Instance==null)
			{
				_Instance = FindObjectOfType(typeof(T)) as T;
				if(_Instance==null)
				{
					GameObject obj = new GameObject();
					obj.hideFlags=HideFlags.HideAndDontSave;
					_Instance = (T)obj.GetComponent(typeof(T));
				}
			}
			return _Instance;
		}
	}
	// Use this for initialization
	public virtual void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		if(_Instance==null)
		{
			_Instance=this as T;
		}

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
