using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartSceneController : MonoBehaviour
{
	AudioSource source;//音频资源
	public AudioClip clip;//一个音频

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	//加载场景
	public void OnStartButtonClick(string path)
	{
		//source.clip = clip ;
		//source.loop = false;
		//source.Play();
		StartCoroutine(loadScene(path));
	}
	IEnumerator loadScene(string index)
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(index);
	}
}
