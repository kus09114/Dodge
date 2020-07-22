using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubUI : MonoBehaviour
{
	public StartMenuDlg m_StartMenuDlg = null;
	public ResultGameDlg m_ResultGameDlg = null;
	public GameUIDlg m_GameUIDlg = null;

	[SerializeField] Text m_txtCount = null;
	[SerializeField] GameObject m_ReadyUI = null;
	[SerializeField] GameObject m_ResultUI = null;
	[SerializeField] GameObject m_InGameUI = null;

	int m_nCount = 3;

	void Start()
    {
		Initializ();
	}

	public void Initializ()
	{
		m_txtCount.text = m_nCount.ToString();
		m_ResultGameDlg.Initializ();
	}

	public void StartReadyCount()
	{
		SetUIText(true);
		StartCoroutine("ReadyCount", 1.0f);
	}

	IEnumerator ReadyCount(float fDeley)
	{
		int nCount = 3;
		while (nCount >= 0)
		{
			if (nCount == 0)
				m_txtCount.text = "Start";
			else
				m_txtCount.text = nCount.ToString();

			--nCount;

			yield return new WaitForSeconds(fDeley);
		}
		if(nCount < 0)
		{
			SetUIText(false);
			GameScene kGameScene = gameObject.GetComponentInParent<GameScene>();
			kGameScene.m_BattleFSM.SetGameState();
			m_InGameUI.SetActive(true);
		}
	}

	void SetUIText(bool set)
	{
		m_ReadyUI.SetActive(set);
	}

	void SetResultUI(bool set)
	{
		m_ResultUI.SetActive(set);
	}

	public void SetResultState()
	{
		m_ResultGameDlg.OpenUI();
	}
}
