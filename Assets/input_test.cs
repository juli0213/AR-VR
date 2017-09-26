using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_test : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	//		获取用户事件需要使用  Input 类，一般写在Update内 

	void Update () {
		//		每一帧都需要坚挺用户事件
		//	当前这一帧，如果用户按下了W就会返回true，否则返回false


		//Input.GetKeyDown（）方法用来检测按键按下事件
		bool b = Input.GetKeyDown (KeyCode.W);//返回一个布尔值
		if(b){
			Debug.Log ("go");//debug只能在 monobehaviour  的子类中使用，其他情况不能使用
			print ("往回走");
		}
	    
		//Input.GetKeyUp()  方法来检测按键淘气事件
		if (Input.GetKeyUp(KeyCode.Alpha1))//数字键  1
		{
			print ("按下  1");
		}


		//		Input.GetKey （）  方法用来检测持续按键事件
		if (Input.GetKey (KeyCode.F)) {
			print ("按下了F");
		}
	}
}
