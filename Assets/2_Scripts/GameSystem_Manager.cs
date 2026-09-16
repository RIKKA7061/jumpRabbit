using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
	[SerializeField] private PlatformSystem_Manager platformSystem_Manager = null;
	[SerializeField] private Player_Script playerClass = null;
	[SerializeField] private CameraSystem_Manager cameraSystem_Manager = null;
	[SerializeField] private DataBase_Manager dataBase_Manager = null;

	private void Awake()
	{
		this.dataBase_Manager.Init_Func();
		this.playerClass.Init_Func();
		this.platformSystem_Manager.Init_Func();
		this.cameraSystem_Manager.Init_Func();
	}

	private void Start()
	{
		this.platformSystem_Manager.Active_Func();
	}
}
