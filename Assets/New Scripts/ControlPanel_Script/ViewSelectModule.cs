//内容--增加脚本文件ViewSeleModule，用于实现数控机床的正视图、俯视图和左视图
//姓名--刘旋，时间--2013-4-1

using UnityEngine;
using System.Collections;

public class ViewSelectModule : MonoBehaviour {
	//GameObject mainObject;//内容--用于获得机床的基准坐标点，姓名--刘旋，时间--2013-4-1
	GameObject mainCamera;//内容--用于对摄像机进行设置，姓名--刘旋，时间--2013-4-1
	Vector3 current_position;
	Vector3 targetFront_position;
	Vector3 targetTop_position;
	Vector3 targetLeft_position;
	Vector3 current_angles;
	Vector3 targetFront_angles;
	Vector3 targetTop_angles;
	Vector3 targetLeft_angles;
	bool front_flag=false;
	bool top_flag=false;
	bool left_flag=false;
	float currentView;
	float targetView;
	
	
	void Awake()
	{
		//mainObject=GameObject.Find("GZT");//内容--选取机床零点坐标作为机床的基准点，姓名--刘旋，时间--2013-4-1
		mainCamera=GameObject.Find("Main Camera");
		targetFront_position=new Vector3(-30f,1.2f,-1.1f);
		targetTop_position=new Vector3(0,45f,-1.1f);
		targetLeft_position=new Vector3(0,1.2f,30f);
		targetFront_angles=new Vector3(0,90f,0);
		targetTop_angles=new Vector3(90f,0,0);
		targetLeft_angles=new Vector3(0,180f,0);
		targetView=6f;
		
		
	}

	// Use this for initialization
	void Start () {
		
	
	}
	void OnGUI()
	{
		currentView=mainCamera.camera.fieldOfView;
		string temp=currentView.ToString();
		Debug.Log(temp);
		if(GUI.Button(new Rect(10,190,100,40),"Front View"))
		{
			front_flag=true;
			top_flag=false;
			left_flag=false;
			currentView=30f;
		}
		if(GUI.Button(new Rect(10,240,100,40),"Top View"))
		{
			front_flag=false;
			top_flag=true;
			left_flag=false;
			currentView=30f;
		}
		if(GUI.Button(new Rect(10,290,100,40),"Left View"))
		{
			front_flag=false;
			top_flag=false;
			left_flag=true;
			currentView=30f;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (front_flag)
			Front();
		if (top_flag)
			Top();
		if (left_flag)
			Left();
	}
	void Front()
	{
		mainCamera.camera.transform.LookAt(new Vector3(0,1.2f,-1.1f));
		current_position=mainCamera.transform.position;
		current_position=Vector3.Lerp(current_position,targetFront_position,Time.deltaTime*5f);
		mainCamera.transform.position=current_position;
		current_angles=mainCamera.transform.eulerAngles;
		current_angles=Vector3.Lerp(current_angles,targetFront_angles,Time.deltaTime*5f);
		mainCamera.transform.eulerAngles=current_angles;
		currentView=Mathf.LerpAngle(currentView,targetView,Time.deltaTime*5f);
		mainCamera.camera.fieldOfView=currentView;
	}
	void Top()
	{
		//mainCamera.camera.transform.LookAt(Vector3.zero);
		current_position=mainCamera.transform.position;
		current_position=Vector3.Lerp(current_position,targetTop_position,Time.deltaTime*5f);
		mainCamera.transform.position=current_position;
		current_angles=mainCamera.transform.eulerAngles;
		current_angles=Vector3.Lerp(current_angles,targetTop_angles,Time.deltaTime*5f);
		mainCamera.transform.eulerAngles=current_angles;
		currentView=Mathf.LerpAngle(currentView,targetView,Time.deltaTime*5f);
		mainCamera.camera.fieldOfView=currentView;
	}
	void Left()
	{
		mainCamera.camera.transform.LookAt(new Vector3(0,1.2f,-1.1f));
		current_position=mainCamera.transform.position;
		current_position=Vector3.Lerp(current_position,targetLeft_position,Time.deltaTime*5f);
		mainCamera.transform.position=current_position;
		current_angles=mainCamera.transform.eulerAngles;
		current_angles=Vector3.Lerp(current_angles,targetLeft_angles,Time.deltaTime*5f);
		mainCamera.transform.eulerAngles=current_angles;
		currentView=Mathf.LerpAngle(currentView,targetView,Time.deltaTime*5f);
		mainCamera.camera.fieldOfView=currentView;
	}
	
}
