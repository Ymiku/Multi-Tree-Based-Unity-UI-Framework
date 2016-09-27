using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : UnitySingleton<LevelManager> {
	public int avSceneNum = 0;
	private static int lastSceneNum = 4;
	public List<int> sceneList = new List<int>();
	public List<int> destoryList = new List<int>();
	public List<AsyncOperation> asyncList = new List<AsyncOperation>();
	// Use this for initialization
	void Start () {
		
	}

	void Update()
	{
		for (int i = asyncList.Count-1;i >=0; i--) {
			if (asyncList [i].progress >= 1f) {
				asyncList.RemoveAt (i);
			}
		}
	}
	public void LevelStart(int sceneNum)
	{
		GC.Collect ();
		asyncList.Add(SceneManager.LoadSceneAsync (sceneNum.ToString(), LoadSceneMode.Additive));
		sceneList.Add (sceneNum);
	}

	public void LevelEnd()
	{
		SceneManager.UnloadScene (sceneList[0].ToString());
		sceneList.Clear ();
	}
	public bool isReady()
	{
		if (asyncList.Count <= 0) {
			return true;
		}
		return false;
	}

	public void Save()
	{
		
	}
	public void Reset()
	{
		SceneManager.UnloadScene (sceneList[0].ToString());
		asyncList.Add(SceneManager.LoadSceneAsync (sceneList[0].ToString(), LoadSceneMode.Additive));

	}
	public void LoadNext()
	{
		if (sceneList [0] == lastSceneNum)
			return;
		SceneManager.UnloadScene (sceneList[0].ToString());
		sceneList [0]++;
		asyncList.Add(SceneManager.LoadSceneAsync (sceneList[0].ToString(), LoadSceneMode.Additive));

	}
}
