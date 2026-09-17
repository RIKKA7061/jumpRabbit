using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col = null;
    [SerializeField] private SpriteRenderer srdr = null;
    [SerializeField] private int score; // 플랫폼 별 점수

    public float GetHalfSizeX => this.col.size.x * .5f;

    public void Active_Func(Vector2 _pos)
	{
        this.transform.position = _pos;
	}

    // 플레이어 착지 감지 -> 착지 사실 전달 -> *이 함수 -> 점수 매니저 -> 점수 추가
    public void OnLandding_Func()
    {
        ScoreSystem_Manager.Instance.AddScore_Func(this.score, this.transform.position);
    }
}
