using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class catch_tip : MonoBehaviour {
	Vector3 startPos;
	Vector3 startRotation;
	// Use this for initialization
	void Start () {
		startPos = this.transform.localPosition;
		startRotation = this.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//		积木归为
	public void resetBlock()
	{
		this.transform.SetParent (Controller2.instance2.blocksGroup2.transform);
		//print ("调用reset");
		this.transform.DOLocalMove(startPos,1.5f);
		this.transform.DOLocalRotate (startRotation, 1.5f);
	}

	void OnTriggerEnter(Collider other) {
		//先判断碰撞的物体是否属于 		Tips		的对象
		if ((!this.transform.parent.name.Equals ("Tip"))&&other.transform.parent.name.Equals("Tip")) {
			print ("被碰撞的属于TIp类");

			if (this.transform.name == other.transform.name) 
			{
				print ("名称相同");
				//摆放正确，积木的父类设为tips类
				this.transform.SetParent (other.transform.parent.transform);
				//print (other.transform.name);
				//this.transform.localPosition = other.transform.localPosition;
				//this.transform.localEulerAngles = other.transform.localEulerAngles;
				this.transform.DOLocalMove(other.transform.localPosition,1.5f);
				//位置摆正的1.5s的动画完成之后   执行Oncomplete
				this.transform.DOLocalRotate (other.transform.localEulerAngles, 1.5f).OnComplete(()=>
					//隐藏上一个闪烁，开启下一个
					{
						Controller2.instance2.showNextTip(other.gameObject.name);
						Controller2.instance2.gameCompete();
					}
				);
				this.transform.localScale = other.transform.localScale;
				catch_Block.isCatch = false;
			}
			else 
			{
				
				print ("名称不相同");
				this.transform.SetParent (Controller2.instance2.blocksGroup2.transform);
				//this.transform.localPosition = startPos;
			//	this.transform.localEulerAngles = startRotation;
				resetBlock();
				catch_Block.isCatch = false;

			}


		}

	}


}
