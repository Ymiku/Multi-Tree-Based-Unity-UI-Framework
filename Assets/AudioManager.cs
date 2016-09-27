using UnityEngine;
using System.Collections;

public class AudioManager : UnitySingleton<AudioManager> {
	public AudioClip[] audioClip;
	private AudioSource _audioSource;
	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

	public void Play(int i)
	{
		_audioSource.PlayOneShot (audioClip[i]);
	}
}
