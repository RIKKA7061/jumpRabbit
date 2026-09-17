using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Script : MonoBehaviour
{
	[SerializeField] private TextMeshPro tmp = null; // text object 변수 선언

	public void Activate_Func(int _score)
	{
		this.tmp.text = _score.ToString();
	}


	public void Deactivate_Func() // 점수가 생기고 자동으로 사라지는 함수
	{
		GameObject.Destroy(this.gameObject);
	}

	public void CallAni_Deactivate_Func()
	{
		this.Deactivate_Func();
	}
}
