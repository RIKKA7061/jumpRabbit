using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem_Manager : MonoBehaviour
{
	[SerializeField] private Transform spawnPosTrf = null;
	private Dictionary<int, Platform_Script[]> platformClassArrDic;
	private int platformNum;
	public void Init_Func()
	{
		this.platformClassArrDic = new Dictionary<int, Platform_Script[]>();

		this.platformClassArrDic.Add(0, DataBase_Manager.Instance.smallPlatformClassArr);
		this.platformClassArrDic.Add(1, DataBase_Manager.Instance.middlePlatformClassArr);
		this.platformClassArrDic.Add(2, DataBase_Manager.Instance.largePlatformClassArr);
	}

	public void Active_Func()
	{
		// 좌표 지정
		Vector2 _pos = this.spawnPosTrf.position;

		for (int i = 0; i < 50; i++)
		{
			int _platformID = -1;
			foreach (Data _data in DataBase_Manager.Instance.dataArr)
			{
				if (_data.TryGetPlatformID_Func(this.platformNum, out _platformID) == true)
					break;
			}

			// 0 : small, 1 : middle, 2 : large
			// 배열 지정
			Platform_Script[] _platformClassArr = this.platformClassArrDic[_platformID];
			
			// 0 ~ 배열 길이 수 중에 랜덤한 숫자 뽑기
			int _randID = Random.Range(0, _platformClassArr.Length);
			// 랜덤한 프리펩 지정(길이별)
			Platform_Script _randPlatformClass = _platformClassArr[_randID];

			// 생성
			Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);

			if (0 < i)
				_pos += Vector2.right * _platformClass.GetHalfSizeX;

			_platformClass.Active_Func(_pos);

			float _gap = Random.Range(DataBase_Manager.Instance.gapIntervalMin, DataBase_Manager.Instance.gapIntervalMax);

			_pos += new Vector2(_gap * _platformClass.GetHalfSizeX, 0f);

			// 한개씩 증가
			this.platformNum++; 
		}
	}

	[System.Serializable]
	public class Data
	{
		[SerializeField] private int conditionNum;
		[SerializeField] private float[] percentArr = new float[3];

		public bool TryGetPlatformID_Func(int _platformNum, out int _platformID)
		{
			if (this.conditionNum <= _platformNum)
			{
				// 0과1 사이에 랜덤값
				float _randValue = Random.value;

				for (int i = 0; i < this.percentArr.Length; i++)
				{
					if (_randValue < this.percentArr[i])
					{
						_platformID = i;

						return true;
					}
					else
					{
						_randValue -= this.percentArr[i];
					}
				}

				_platformID = 0;

				return true;
			}
			else
			{
				_platformID = -1;

				return false;
			}
		}
	}
}
