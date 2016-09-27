using UnityEngine;
using System;
using System.Collections;

public class Singleton<T>
	where T:class
{
	private static T _instance;
	public static T Instance
	{
		get{
			if(_instance==null)
			{
				_instance = (T)Activator.CreateInstance(typeof(T), true);
			}
			return _instance;
		}
	}
	public static void Create()
	{
		_instance = (T)Activator.CreateInstance(typeof(T), true);

		return;
	}
	public static void SetInstance(T t)
	{
		_instance = t;
	}
	public static void Destroy()
	{
		_instance = null;
		return;
	}
}
