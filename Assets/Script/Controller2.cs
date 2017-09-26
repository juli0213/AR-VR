using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : MonoBehaviour {
	public static Controller2 instance2;
	int currentBlockNum2=0;//搭建积木数字    完成标志
	public GameObject completePanel;
	public GameObject blocksTipGroup2;
	public GameObject blocksGroup2;
	public GameObject[] blockTipArray2;

	void Awake(){
		if (instance2 == null) {
			instance2 = this;
		}
	}

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Init()
	{
		currentBlockNum2 = 0;
		blocksGroup2.SetActive(false);
		//除去第一个积木外其他关闭
		for (int i = 1; i < blockTipArray2.Length; i++)
		{
			blockTipArray2[i].SetActive(false);
		}
	}

	public void gameCompete()//检测游戏完成
	{
		if (currentBlockNum2 >= blockTipArray2.Length) //  检测数字大于等于总积木数，搭建完成
		{
			completePanel.SetActive (true);//显示UI面板
		}
	}

	//    下一个木块提示
	public void showNextTip(string CollisionName)
	{
		//先循环检测数组积木组件数组，遍历查找当前闪烁积木块
		for (int i = 0; i < blockTipArray2.Length; i++) 
		{
			//	  查找到提示积木明
			if (blockTipArray2 [i].name == CollisionName) 
			{
				//	关闭闪烁，开启下一个
				blockTipArray2[i].SetActive(false);

				//如果已经是最后一个就不开启，防止越界
				if (i < blockTipArray2.Length - 1) 
				{
					//开启下一个
					blockTipArray2[i+1].SetActive(true);
				}

				//完成标志，完成数字为length结束
				currentBlockNum2 = i+1;

			}
		}
	}

	public void restartGame()
	{
		//   检测标注重置
		currentBlockNum2 = 0;
		//		获取可移动积木  使其重置

		print ("调用restart");
		catch_tip[] tempBlockArray = blocksTipGroup2.GetComponentsInChildren<catch_tip>();
		for (int i = 0; i < tempBlockArray.Length; i++) 
		{
			//循环使积木归位
			//print(tempBlockArray[i].name);
			tempBlockArray[i].resetBlock();
		}
		//showFirstBlockTips ();
		//移动动画结束后  第一个积木开始提示
		Invoke("showFirstBlockTips",1.5f);

		//通关提示关闭
		completePanel.SetActive(false);
	}

	//提示第一个积木
	void showFirstBlockTips()
	{
		blockTipArray2 [0].SetActive (true);
	}
}
