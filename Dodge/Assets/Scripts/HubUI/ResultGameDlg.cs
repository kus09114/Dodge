using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameDlg : MonoBehaviour
{
	[SerializeField] Button m_btnRestart = null;
	[SerializeField] Button m_btnExit = null;
	[SerializeField] Text m_txtPlayTime = null;

	GameScene m_GameScene = null;
	GameInfo m_GameInfo = null;

	void Start()
    {
		m_btnRestart.onClick.AddListener(OnClick_Restart);
		m_btnExit.onClick.AddListener(OnClick_Exit);
	}

	public void Show(bool bShow)
	{
		gameObject.SetActive(bShow);
	}

	public void OpenUI()
	{
		Show(true);
	}

	public void Initializ()
	{
		m_GameScene = gameObject.GetComponentInParent<GameScene>();
		m_txtPlayTime.text = m_GameScene.m_HubUI.m_GameUIDlg.m_publicTime;
	}

	void OnClick_Restart()
	{
		m_GameScene.m_BattleFSM.SetReadyState();

		SetResultUI(false);
	}

	void OnClick_Exit()
	{
		SetResultUI(false);
		m_GameScene.m_HubUI.m_StartMenuDlg.SetUI(true);
	}

	void SetResultUI(bool set)
	{
		gameObject.SetActive(set);
	}
}
