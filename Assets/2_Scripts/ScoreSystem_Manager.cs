using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem_Manager : MonoBehaviour
{
	public static ScoreSystem_Manager Instance; // 객체 생성

	[SerializeField] private TextMeshProUGUI scoreTmp = null; // Canvas에 보여질 Score text
	[SerializeField] private Score_Script baseScoreClass = null; // 변수

	private int totalScore;

	public void Init_Func() // 함수 (게임매니저 통제하에 실행됨)
	{
		Instance = this; // 변수에 값 대입
	}

	public void AddScore_Func(int _score, Vector2 _scorePos) // 몇점 추가 되는 지
	{
		Score_Script _scoreClass = GameObject.Instantiate<Score_Script>(this.baseScoreClass); // 현재 씬에 있는 존재하는 객체로 지정
		_scoreClass.transform.position = _scorePos; // 객체 위치 설정
		_scoreClass.Activate_Func(_score); // 그 객체의 함수 실행

		this.totalScore += _score; // 보내준 점수 만큼 전체 스코어에 중첩해서 더해주기

		this.scoreTmp.text = this.totalScore.ToString(); // 점수 추가 -> 전체 스코어 최신화 -> UI Score 최신화
	}
}
