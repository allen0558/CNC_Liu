using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class SoftkeyModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	MDIEditModule MDIEdit_Script;
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
	}
	
	public void Softkey () 
	{
		//屏幕下方功能软键++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++	
		if (GUI.Button(new Rect(20f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), "<"))            
		{
			if(Main.ScreenPower)
				PreviousPage();
		}
		
		if (GUI.Button(new Rect(90f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))           	
		{
			if(Main.ScreenPower)
				FirstButton();	
		}
		
		if (GUI.Button(new Rect(180f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            	
		{
			if(Main.ScreenPower)
				SecondButton();
		}
		
		if (GUI.Button(new Rect(270f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				ThirdButton();
		}
		
		if (GUI.Button(new Rect(360f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				FourthButton();
		}
		
		if (GUI.Button(new Rect(450f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				FifthButton();
		}
		
		if (GUI.Button(new Rect(520f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ">"))            
		{
			if(Main.ScreenPower)
				NextPage();
		}
	}
	
	//向前翻页软键
	void PreviousPage () {
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
					}
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 1;
					else if(Main.ProgEDITFlip == 3)
						Main.ProgEDITFlip = 2;
					//内容--程序编辑界面下，程序底部按钮有8种显示方式，因此ProgEDITFlip的值由0到7，在向前翻页按钮命令下，ProgEDITFlip的变化如下
					//姓名--刘旋
					//日期2013-3-14
					else if (Main.ProgEDITFlip==4)
				        Main.ProgEDITFlip=3;
			        else if (Main.ProgEDITFlip==5)
				        Main.ProgEDITFlip=2;
			        else if (Main.ProgEDITFlip==6)
				        Main.ProgEDITFlip=5;
			        else if (Main.ProgEDITFlip==7)
				        Main.ProgEDITFlip=2;//变化内容到此
					else if(Main.ProgEDITFlip==8)
						Main.ProgEDITFlip=4;
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
						Main.ProgEDITProg = true;
						Main.ProgEDITList = false;
					}
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 1;
					else if(Main.ProgEDITFlip == 3)
						Main.ProgEDITFlip = 2;
				}
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
		}
	}
	
	//软键 Button1
	void FirstButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//绝对坐标
			Main.AbsoluteCoo = true;
			Main.RelativeCoo = false;
			Main.GeneralCoo = false;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//程序
				//内容--程序和列表菜单下，第一个按钮有不同的功能，因此要分情况定义
				//姓名--刘旋
				//日期2013-3-14
				if(Main.ProgEDITProg)
				{
					if (Main.ProgEDITFlip==2)
				       Main.ProgEDITFlip=3;
			       else if (Main.ProgEDITFlip==3)   
				       Main.ProgEDITFlip=2;
		           else if (Main.ProgEDITFlip==5)
				       Main.ProgEDITFlip=2;
				   else if ((Main.ProgEDITFlip==6)||(Main.ProgEDITFlip==4))//内容--增加程序底部按钮显示“8”，用于实现“替换”功能，姓名--刘旋，时间--2013-3-20
						Main.ProgEDITFlip=8;
					
					
				}
				if(Main.ProgEDITList)
				{//变化的内容到此
					if(Main.ProgEDITFlip == 0)
				     {
					 Main.ProgEDITProg = true;
					 Main.ProgEDITList = false;
				     }
				}
				
				
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = true;
				Main.OffSetSetting = false;
				Main.OffSetCoo = false;
			}
			else if(Main.OffSetCoo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.SearchNo(Main.InputText);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = 57f;
				}
			}	
		}
	}
	
	//软键 Button2
	void SecondButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//相对坐标
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = true;
			Main.GeneralCoo = false;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//内容--程序菜单下，第二个按钮也是有功能的
				//姓名--刘旋
				//日期2013-3-14
				if(Main.ProgEDITProg)
				{
					if (Main.ProgEDITFlip==2)
				       Main.ProgEDITFlip=5;
					else if (Main.ProgEDITFlip==0)
					{
						Main.ProgEDITList=true;
						Main.ProgEDITProg=false ;
						
					}
					
				       
					
				}
				
				
				
				if(Main.ProgEDITList)
				{//变化内容到此
					
					
				if(Main.ProgEDITFlip == 0)
				{
					//列表
					if(Main.current_filenum > 0)
						Main.RealListNum = Main.current_filenum;
					else
						Main.RealListNum = 1;
					Main.ProgEDITCusor = 175f;
					Main.FileNameList.Clear();
					Main.FileSizeList.Clear();
					Main.FileDateList.Clear();
					Main.ProgUnusedNum = 400;
					Main.ProgUnusedSpace = 512;//内容--内存总容量为512K，姓名--刘旋，时间--2013-3-18
					Main.ProgUsedNum = 0;
					Main.ProgUsedSpace = 0;
					FileInfo FileTestExtension;	
					string[] TempFileList = Directory.GetFiles(Application.dataPath + "/Resources/Gcode/");
					string TestStr = "";
					string[] TempStrArray;
					string[] TempNameArray = new string[8];
					int[] TempSizeArray = new int[8];
					string[] TempDateArray = new string[8];
					int Eight = 0;
					for(int i = 0; i < TempFileList.Length; i++)
					{
						FileTestExtension = new FileInfo(TempFileList[i]);
						TestStr = FileTestExtension.Extension.ToUpper();
						if(TestStr == ".CNC" || TestStr == ".NC" || TestStr == ".TXT")
						{
							TempStrArray = TempFileList[i].Split('/');
							TempStrArray = TempStrArray[TempStrArray.Length - 1].Split('.');
							char[] temp_name = TempStrArray[0].ToString().ToCharArray();
							bool normal_flag = true;
							for(int q = 0; q < temp_name.Length; q++)
							{
								if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
									continue;
								else
								{
									normal_flag = false;
									break;
								}
							}
							if(normal_flag)
							{
								Main.FileNameList.Add(TempStrArray[0]);
								Main.FileSizeList.Add((Int32)FileTestExtension.Length/1024);//内容--将文件大小的单位转换为KB，1KB=1024B，姓名--刘旋，时间--2013-3-18
								Main.ProgUsedNum++;
								Main.ProgUsedSpace +=  (Int32)FileTestExtension.Length/1024;//内容--将已用内存的单位转换为KB，1KB=1024B，姓名--刘旋，时间--2013-3-18
								Main.FileDateList.Add(FileTestExtension.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
							}
						}	
					}
					Main.TotalListNum = Main.FileNameList.Count;
					int start_index = Main.RealListNum - 1;
					if(Main.FileNameList.Count  - start_index >= 8)
						Eight = start_index + 8;
					else
						Eight = Main.FileNameList.Count;
					for(int i = 0; i < 8; i++)
					{
						TempNameArray[i] = "";
						TempSizeArray[i] = 0;
						TempDateArray[i] = "";
					}
					int array_index = -1;
					for(int i = start_index; i < Eight; i++)
					{
						array_index++;
						TempNameArray[array_index] = Main.FileNameList[i];
						TempSizeArray[array_index] = Main.FileSizeList[i];
						TempDateArray[array_index] = Main.FileDateList[i];
					}
					
					Main.CodeName01 = TempNameArray[0];
					Main.CodeName02 = TempNameArray[1];
					Main.CodeName03 = TempNameArray[2];
					Main.CodeName04 = TempNameArray[3];
					Main.CodeName05 = TempNameArray[4];
					Main.CodeName06 = TempNameArray[5];
					Main.CodeName07 = TempNameArray[6];
					Main.CodeName08 = TempNameArray[7];
					
					Main.CodeSize01 = TempSizeArray[0];
					Main.CodeSize02 = TempSizeArray[1];
					Main.CodeSize03 = TempSizeArray[2];
					Main.CodeSize04 = TempSizeArray[3];
					Main.CodeSize05 = TempSizeArray[4];
					Main.CodeSize06 = TempSizeArray[5];
					Main.CodeSize07 = TempSizeArray[6];
					Main.CodeSize08 = TempSizeArray[7];
					
					Main.UpdateDate01 = TempDateArray[0];
					Main.UpdateDate02 = TempDateArray[1];
					Main.UpdateDate03 = TempDateArray[2];
					Main.UpdateDate04 = TempDateArray[3];
					Main.UpdateDate05 = TempDateArray[4];
					Main.UpdateDate06 = TempDateArray[5];
					Main.UpdateDate07 = TempDateArray[6];
					Main.UpdateDate08 = TempDateArray[7];
					
					Main.ProgUnusedNum -= Main.ProgUsedNum;
					Main.ProgUnusedSpace -= Main.ProgUsedSpace;
					Main.ProgEDITProg = false;
					Main.ProgEDITList = true;
				}
				
				if(Main.ProgEDITFlip == 1)
				{
					//O检索
					if(Main.ProgEDITList)
					{
							if ((Main.InputText.Length <6)&&(Main.InputText.Length>1))//内容--MDI键盘输入程序名称，按下“O检索”，实现对程序的选择，姓名--刘旋，时间--2013-3-20
							{   
								
								if (Main.InputText[0]!='O')
								{
									Main.InputText="";
									Main .ProgEDITCusorPos=57f;
								}
								
								else 
								{
								char[] temp_name=Main.InputText.ToCharArray ();
								bool normal_flag=true;
								for(int j=0;j<temp_name.Length ;j++)
								{
									if(temp_name[j] == 'O' || (temp_name[j] >= '0' && temp_name[j] <= '9'))
									    continue;
								    else
								       {
									      normal_flag = false;
									      break;
								       }
								}
									if(normal_flag)
									{
										int inputname = Convert.ToInt32(Main.InputText.Trim('O'));
										String tempinput_name=Main.ToolNumFormat(inputname);
										String input_name='O'+tempinput_name;
										int m=0;
										while(input_name!=Main.FileNameList[m])
									{
										m++;
									}
									Main.RealListNum=m+1;
									Main.ProgramNum = Convert.ToInt32(Main.FileNameList[Main.RealListNum - 1].Trim('O'));
									if (Main.ProgEDITFlip==0)
										Main.ProgEDITFlip=1;
									Main.ProgEDITCusor = 175f;
									Main.ProgEDITAt=true;
									int finalnum=Main.RealListNum+8;
									if(finalnum >Main.TotalListNum)
										finalnum=Main.TotalListNum;
									string[] InputNameArray = new string[8];
							        int[] InputSizeArray = new int[8];
							        string[] InputDateArray = new string[8];
							        for(int i = 0; i < 8; i++)
							        {
								      InputNameArray[i] = "";
								      InputSizeArray[i] = 0;
								      InputDateArray[i] = "";
							        }
							        int MiddleNum = -1;
							        for(int i = Main.RealListNum; i < finalnum ; i++)
							        {
								       MiddleNum++;
								       InputNameArray[MiddleNum] = Main.FileNameList[i-1];	
								       InputSizeArray[MiddleNum] = Main.FileSizeList[i-1];
								       InputDateArray[MiddleNum] = Main.FileDateList[i-1];
							        }
							
							Main.CodeName01 = InputNameArray[0];
							Main.CodeName02 = InputNameArray[1];
							Main.CodeName03 = InputNameArray[2];
							Main.CodeName04 = InputNameArray[3];
							Main.CodeName05 = InputNameArray[4];
							Main.CodeName06 = InputNameArray[5];
							Main.CodeName07 = InputNameArray[6];
							Main.CodeName08 = InputNameArray[7];
							
							Main.CodeSize01 = InputSizeArray[0];
							Main.CodeSize02 = InputSizeArray[1];
							Main.CodeSize03 = InputSizeArray[2];
							Main.CodeSize04 = InputSizeArray[3];
							Main.CodeSize05 = InputSizeArray[4];
							Main.CodeSize06 = InputSizeArray[5];
							Main.CodeSize07 = InputSizeArray[6];
							Main.CodeSize08 = InputSizeArray[7];
							
							Main.UpdateDate01 = InputDateArray[0];
							Main.UpdateDate02 = InputDateArray[1];
							Main.UpdateDate03 = InputDateArray[2];
							Main.UpdateDate04 = InputDateArray[3];
							Main.UpdateDate05 = InputDateArray[4];
							Main.UpdateDate06 = InputDateArray[5];
							Main.UpdateDate07 = InputDateArray[6];
							Main.UpdateDate08 = InputDateArray[7];
										
										
									}
								Main.InputText="";
						        Main.ProgEDITCusorPos = 57f;	
								}
							}
						else
					   {	
								
						Main.InputText="";
						Main.ProgEDITCusorPos=57f;//增加内容到此			
						if(Main.FileNameList.Count == 0)
							Debug.Log("No files in the memory now!");
						else
						{
							if(Main.FileNameList[Main.RealListNum - 1].ToCharArray()[0] == 'O')
							{
								char[] temp_name = Main.FileNameList[Main.RealListNum - 1].ToString().ToCharArray();
								bool normal_flag = true;
								for(int q = 0; q < temp_name.Length; q++)
								{
									if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
										continue;
									else
									{
										normal_flag = false;
										break;
									}
								}
								if(normal_flag)
								{
									Main.ProgramNum = Convert.ToInt32(Main.FileNameList[Main.RealListNum - 1].Trim('O'));
									Main.current_filenum = Main.RealListNum;
									Main.current_filename = Main.FileNameList[Main.RealListNum - 1].ToString();
									Main.ProgEDITProg = true;
									Main.ProgEDITList = false;
									Main.CodeForAll.Clear();
									Main.RealCodeNum = 1;
									Main.HorizontalNum = 1;
									Main.VerticalNum = 1;
									string SLine = "";
									FileStream faceInfoFile;
									FileInfo ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt");
									if(ExistCheck.Exists)	
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt", FileMode.Open, FileAccess.Read);
									else 
									{
										ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc");
										if(ExistCheck.Exists)
											faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc", FileMode.Open, FileAccess.Read);
										else
											faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".nc", FileMode.Open, FileAccess.Read);
									}
									StreamReader sR = new StreamReader(faceInfoFile);
									SLine = sR.ReadLine();
									while(SLine != null)
									{
										Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
										SLine = sR.ReadLine();
									}
									sR.Close();
									if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
										Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
									Main.TotalCodeNum = Main.CodeForAll.Count;
									MDIEdit_Script.CodeEdit();
									Main.ProgEDITCusorH = 32f;
									Main.ProgEDITCusorV = 100f;
									Main.EDITText.text = Main.TempCodeList[0][0];
									Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
								}
								else
									Debug.Log("Program name is ilegal!");
							}
							else	
								Debug.Log("Program name is ilegal!");
						}}
					}
					else
					{
						if(Main.FileNameList.Count == 0)
						{
							FileStream prog_file;
							string[] TempFileList = Directory.GetFiles(Application.dataPath + "/Resources/Gcode/");
							if(TempFileList.Length > 0)
							{
								string TestStr = "";
								string[] TempStrArray;
								FileInfo FileTestExtension;	
								Main.FileNameList.Clear();
								Main.FileSizeList.Clear();
								Main.FileDateList.Clear();
								for(int i = 0; i < TempFileList.Length; i++)
								{
									FileTestExtension = new FileInfo(TempFileList[i]);
									TestStr = FileTestExtension.Extension.ToUpper();
									if(TestStr == ".CNC" || TestStr == ".NC" || TestStr == ".TXT")
									{
										TempStrArray = TempFileList[i].Split('/');
										TempStrArray = TempStrArray[TempStrArray.Length - 1].Split('.');
										char[] temp_name = TempStrArray[0].ToString().ToCharArray();
										bool normal_flag = true;
										for(int q = 0; q < temp_name.Length; q++)
										{
											if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
												continue;
											else
											{
												normal_flag = false;
												break;
											}
										}
										if(normal_flag)
										{
											Main.FileNameList.Add(TempStrArray[0]);
											Main.FileSizeList.Add((Int32)FileTestExtension.Length/1024);//内容--将文件大小的单位转换为KB，1KB=1024B，姓名--刘旋，时间--2013-3-18
											Main.ProgUsedNum++;
											Main.ProgUsedSpace +=  (Int32)FileTestExtension.Length/1024;//内容--将文件大小的单位转换为KB，1KB=1024B，姓名--刘旋，时间--2013-3-18
											Main.FileDateList.Add(FileTestExtension.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
										}						
									}	
								}
								for(int a = 0; a < TempFileList.Length; a++)
								{
									string directory_str = TempFileList[a].ToString().ToUpper();
									TempStrArray = directory_str.Split('/');
									string[] prog_num = TempStrArray[TempStrArray.Length - 1].ToString().Split('.');
									char[] temp_name = prog_num[0].ToString().ToCharArray();
									bool normal_flag = true;
									for(int q = 0; q < temp_name.Length; q++)
									{
										if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
											continue;
										else
										{
											normal_flag = false;
											break;
										}
									}
									if(normal_flag)
									{
										Main.ProgramNum = Convert.ToInt32(prog_num[0].ToString().Trim('O'));
										if(TempStrArray[TempStrArray.Length - 1].StartsWith("O"))
										{
											if(TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".TXT") || TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".CNC") || TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".NC"))
											{
												prog_file = new FileStream(Application.dataPath + "/Resources/Gcode/" + TempStrArray[TempStrArray.Length - 1], FileMode.Open, FileAccess.Read);
												StreamReader sR = new StreamReader(prog_file);
												string SLine = "";
												SLine = sR.ReadLine();
												while(SLine != null)
												{
													Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
													SLine = sR.ReadLine();
												}
												sR.Close();
												if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
													Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
												Main.TotalCodeNum = Main.CodeForAll.Count;
												MDIEdit_Script.CodeEdit();
												Main.ProgEDITCusorH = 32f;
												Main.ProgEDITCusorV = 100f;
												Main.current_filenum = a + 1;
												Main.current_filename = prog_num[0];
												Main.EDITText.text = Main.TempCodeList[0][0];
												Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
												break;
											}
										}
									}	
								}
							}
							else
								Debug.Log("No files in the memory now!");
					}
					else
					{
						if(Main.current_filenum < Main.FileNameList.Count)
						{
							Main.current_filenum++;
							Main.RealListNum = Main.current_filenum;
						}
						else
						{
							Main.RealListNum = 1;
							Main.current_filenum = 1;
						}
						if(Main.FileNameList[Main.RealListNum - 1].ToCharArray()[0] == 'O')
						{
							char[] temp_name = Main.FileNameList[Main.RealListNum - 1].ToString().ToCharArray();
							bool normal_flag = true;
							for(int q = 0; q < temp_name.Length; q++)
							{
								if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
									continue;
								else
								{
									normal_flag = false;
									break;
								}
							}
							if(normal_flag)
							{
								Main.ProgramNum = Convert.ToInt32(Main.FileNameList[Main.RealListNum - 1].Trim('O'));
								Main.ProgEDITProg = true;
								Main.ProgEDITList = false;
								Main.CodeForAll.Clear();
								Main.RealCodeNum = 1;
								Main.HorizontalNum = 1;
								Main.VerticalNum = 1;
								string SLine = "";
								FileStream faceInfoFile;
								FileInfo ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt");
								if(ExistCheck.Exists)	
									faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt", FileMode.Open, FileAccess.Read);
								else 
								{
									ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc");
									if(ExistCheck.Exists)
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc", FileMode.Open, FileAccess.Read);
									else
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".nc", FileMode.Open, FileAccess.Read);
								}
								StreamReader sR = new StreamReader(faceInfoFile);
								SLine = sR.ReadLine();
								while(SLine != null)
								{
									Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
									SLine = sR.ReadLine();
								}
								sR.Close();
								if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
									Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
								Main.TotalCodeNum = Main.CodeForAll.Count;
								MDIEdit_Script.CodeEdit();
								Main.ProgEDITCusorH = 32f;
								Main.ProgEDITCusorV = 100f;
								Main.EDITText.text = Main.TempCodeList[0][0];
								Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							}
							else
								Debug.Log("Program name is ilegal!");
						}
						else	
							Debug.Log("Program name is ilegal!");	
					}
				}	
			}
		}
		}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = true;
				Main.OffSetCoo = false;
			}
			else if(Main.OffSetCoo)
			{
				CooSystem_script.Measure(Main.InputText);
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = 57f;
			}
		}
	}
	
	//软键 Button3
	void ThirdButton () 
	{
		//位置界面时按下
		if(Main.PosMenu)
		{
			//综合显示
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = false;
			Main.GeneralCoo = true;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			//程序界面下，第三个按钮功能的增加
			//姓名--刘旋
		   //日期2013-3-14
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					
					
				}
				
				if(Main.ProgEDITList)
				{
					
					
				}
				
				
			}//变化内容到此
			
			
			
			
			
			
				
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = false;
				Main.OffSetCoo = true;
			}
			else
			{
				
			}	
		}
	}
	
	//软键 Button4
	void FourthButton () 
	{	
		if(Main.PosMenu)
		{
			
		}
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDITFlip == 0)
			{
				
			}
			else if(Main.ProgEDITFlip == 1)
			{
				
			}
			else if(Main.ProgEDITFlip == 2)
			{
				
			}
			else 
			{
				
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetCoo && Main.OffSetTwo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.PlusInput(Main.InputText, true);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = 57f;
				}
			}
		}
	}
	
	//软键 Button5
	void FifthButton () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
					//内容--增加第五个按钮的功能
					//姓名--刘旋
					//日期--2013-3-14
					else if (Main.ProgEDITFlip==2)
				           Main.ProgEDITFlip=7;//变化内容到此
					
					
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
				else if(Main.OffSetCoo)
				{
					if(Main.InputText != "")
					{
						CooSystem_script.PlusInput(Main.InputText, false);
						Main.InputText = "";
						Main.CursorText.text = Main.InputText;
						Main.ProgEDITCusorPos = 57f;
					}
				}
			}
		}
	}
	
	//向后翻页软键
	void NextPage () {
		
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)	
						Main.ProgEDITFlip = 2;
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 0;//内容--修改内容，把3改为0，姓名--刘旋，日期--2013-3-14
					//内容--增加向下翻页按钮的功能
					//姓名--刘旋
					//日期--2013-3-14
					else if (Main.ProgEDITFlip==3)
				         Main.ProgEDITFlip=4;
			        else if (Main.ProgEDITFlip==4)
				         Main.ProgEDITFlip=2;
			        else if (Main.ProgEDITFlip==5)
				         Main.ProgEDITFlip=6;
		            else if (Main.ProgEDITFlip==6)
				         Main.ProgEDITFlip=2;//变化内容到此
					else if (Main.ProgEDITFlip==8)
				         Main.ProgEDITFlip=0;
					
				}
				
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
						Main.ProgEDITFlip = 2;
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 3;
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
					
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
