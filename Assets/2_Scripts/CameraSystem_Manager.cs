using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem_Manager : MonoBehaviour
{
    // 매니저라서 자유롭게 접근 가능해야함
    public static CameraSystem_Manager Instance;

    public void Init_Func()
	{
        Instance = this;
	}

    public void OnFollowFunc(Vector2 _targetPos)
	{
		StartCoroutine(this.OnFollow_Cor(_targetPos));
	}
	private IEnumerator OnFollow_Cor(Vector2 _targetPos)
	{
		while (DataBase_Manager.Instance.arriveDist <= Vector3.Distance(this.transform.position, _targetPos))
		{
			this.transform.position = Vector3.Lerp(this.transform.position, _targetPos, Time.deltaTime * DataBase_Manager.Instance.followSpeed);

			yield return null;
		}
	}
}
