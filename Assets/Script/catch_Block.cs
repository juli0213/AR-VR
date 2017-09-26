using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catch_Block : MonoBehaviour {

	// Use this for initialization

	public static bool isCatch;//	检测是否有积木被抓取

	void Start () {
		isCatch = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		//print ("name    "+other.name);
		if (other.transform.parent.name.Equals ("Modle")&&!isCatch)//	被抓取积木属于积木素材  并且   操控杆没有抓取其他物体
		{
			other.transform.SetParent (this.transform);
			isCatch = true;	//		以抓取物体

		}


	}
}
