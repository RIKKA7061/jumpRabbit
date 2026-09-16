using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataBase_Manager : ScriptableObject
{
	public static DataBase_Manager Instance;

	[Header("ÇÃ·¹ÀÌ¾î")]
	public float jumpPower = 1f;

	[Header("ÇÃ·§Æû")]
	public Platform_Script[] largePlatformClassArr = null;
	public Platform_Script[] middlePlatformClassArr = null;
	public Platform_Script[] smallPlatformClassArr = null;
	public PlatformSystem_Manager.Data[] dataArr = null;
	public float gapIntervalMin = .5f;
	public float gapIntervalMax = 1.5f;

	[Header("Ä«¸Þ¶ó")]
	public float followSpeed = 5f;
	public float arriveDist = .1f;


	public void Init_Func()
	{
		Instance = this;
	}
}
