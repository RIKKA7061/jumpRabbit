using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigid = null;
	[SerializeField] private Animator anim = null;
	private float currentJumpPower = 1f;
	public void Init_Func()
	{

	}
	private void Update()
	{
		// 스페이스바 누를시
		if(Input.GetKeyDown(KeyCode.Space) == true)
		{
			// JumpReady로 전환
			this.anim.SetInteger("StateID", 1);
		}
		// 스페이스바 누르고 있을시
		else if(Input.GetKey(KeyCode.Space) == true)
		{
			this.currentJumpPower += DataBase_Manager.Instance.jumpPower;
			// 점프력 게이지 상승
		}
		// 스페이스바 뗄시
		else if (Input.GetKeyUp(KeyCode.Space) == true)
		{
			// 모은 점프력 게이지 만큼 발사
			this.rigid.AddForce(Vector2.one * .5f * this.currentJumpPower);

			this.currentJumpPower = 0;

			// Jump로 전환
			this.anim.SetInteger("StateID", 2);
		}
	}

	// 콜라이더 충돌 감지 (토끼가 플랫폼에 착지) (플레이어가 착지 할 때)
	private void OnCollisionEnter2D(Collision2D _col)
	{
		// 속도 0 (정지)
		this.rigid.velocity = Vector2.zero;

		// jump -> idle
		this.anim.SetInteger("StateID", 0);

		// 플레이어 이동 -> 카메라 이동
		CameraSystem_Manager.Instance.OnFollowFunc(this.transform.position);

		// 플랫폼 한테 착지 됬다는 사실 전달
		if(_col.transform.parent.TryGetComponent(out Platform_Script _platformClass) == true)
		{
			_platformClass.OnLandding_Func();
		}
	}
}