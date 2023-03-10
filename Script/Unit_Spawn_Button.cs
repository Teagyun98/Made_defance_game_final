using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Unit_Spawn_Button : MonoBehaviour
{
	public GameObject SpawnUnit;
	public GameObject Wid;
	public Sprite img;


	public void ClickEvent() //클릭시 유닛 생성
	{
		if (GameManager.instance.BlueCost >= SpawnUnit.GetComponent<Unit>().needCost) //코스트 소모 로직 추가
		{
			GameManager.instance.SoundManager.GetComponent<SoundManager>().Buy.Play();
			GameManager.instance.BlueCost -= SpawnUnit.GetComponent<Unit>().needCost;
			GameManager.instance.BaseBlue.GetComponent<Base_Condition>().UnitList.Add(Instantiate(SpawnUnit, SpawnUnit.transform.position, Quaternion.identity)); //생성된 유닛을 진영의 리스트에 저장
		}
	}

	public void ClickWidEvent() //마법사 활성화
	{
		if (GameManager.instance.BlueCost >= Wid.GetComponent<Unit>().needCost)
		{
			GameManager.instance.SoundManager.GetComponent<SoundManager>().Buy.Play();
			GameManager.instance.BlueCost -= Wid.GetComponent<Unit>().needCost;
			transform.GetChild(0).GetComponent<Image>().sprite = img; //마법사 유닛 이미지 추가
			Wid.SetActive(true);
			Destroy(transform.GetChild(1).gameObject);
			Destroy(this); // 마법사의 경우 한번 소환하면 계속 유지가 되서 스크립트를 비활성화 해준다.
		}
	}

	//AI에서 사용될 로직
	public void ClickEventR() //클릭시 유닛 생성
	{
		if (GameManager.instance.RedCost >= SpawnUnit.GetComponent<Unit>().needCost) //코스트 소모 로직 추가
		{
			GameManager.instance.RedCost -= SpawnUnit.GetComponent<Unit>().needCost;
			GameManager.instance.BaseRed.GetComponent<Base_Condition>().UnitList.Add(Instantiate(SpawnUnit, SpawnUnit.transform.position, Quaternion.identity));
		}
	}

	public void ClickWidEventR() //마법사 활성화
	{
		if (GameManager.instance.RedCost >= Wid.GetComponent<Unit>().needCost)
		{
			GameManager.instance.RedCost -= Wid.GetComponent<Unit>().needCost;
			Wid.SetActive(true);
			Destroy(this); // 마법사의 경우 한번 소환하면 계속 유지가 되서 스크립트를 비활성화 해준다.
		}
	}
}
