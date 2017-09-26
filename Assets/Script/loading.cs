using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//using System.Collections.Generic;

public class loading : MonoBehaviour
{
	//异步对象
	AsyncOperation async;

	//场景的进度
	int toProgress = 0;

	//加载的进度
	int displayProgress = 0;

	//public GameObject LoadText;

	public Slider _slider;
	float _slidernum = 0;

	public float timego = 100;

	void Start()
	{
		//在这里开启一个异步任务
		//进入loadScene方法。
		StartCoroutine(loadScene());
	}


	IEnumerator loadScene()
	{
		async = SceneManager.LoadSceneAsync ("GameScene");

		//async.allowSceneActivation  控制异步加载的场景
		async.allowSceneActivation = false;
		//(async.progress < 0.9f)
		while (async.progress < 0.9f)
		{
			toProgress = (int)async.progress * 100;
			while (displayProgress < toProgress)
			{
				++displayProgress;
				//LoadText.GetComponent<Text>().text = "Loading..." +  displayProgress + "%";
				_slider.GetComponent<Slider> ().value = (_slidernum + displayProgress) * 100 ;
				yield return new WaitForEndOfFrame();
			}
		}
		toProgress = 500;

		while (displayProgress < toProgress)
		{
			++displayProgress;

			//LoadText.GetComponent<Text>().text = "Loading..." + displayProgress / 5  + "%";
			_slider.GetComponent<Slider> ().value =  (_slidernum + displayProgress) / 500 ;
			yield return new WaitForEndOfFrame();
		}
		async.allowSceneActivation = true;

	}
}
