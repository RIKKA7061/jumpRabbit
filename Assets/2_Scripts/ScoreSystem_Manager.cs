using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem_Manager : MonoBehaviour
{
	public static ScoreSystem_Manager Instance; // 객체 생성

	private int totalScore;

	public void Init_Func() // 함수 (게임매니저 통제하에 실행됨)
	{
		Instance = this; // 변수에 값 대입
	}

	public void AddScore_Func(int _score) // 몇점 추가 되는 지
	{
		this.totalScore += _score; // 보내준 점수 만큼 전체 스코어에 중첩해서 더해주기
	}
}
