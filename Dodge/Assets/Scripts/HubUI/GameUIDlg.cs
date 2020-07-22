using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIDlg : MonoBehaviour
{
	[SerializeField] Text m_txtPlayTime = null;
	[HideInInspector] public string m_publicTime = null;

	string m_txtClear;

	GameScene m_GameScene = null;

    void Start()
	{
		m_GameScene = gameObject.GetComponentInParent<GameScene>();
		m_txtClear = m_txtPlayTime.text;
	}

	public void Initialize()
	{
		m_txtPlayTime.text = m_txtClear;
	}

	void Update()
	{
		CurrentTime();
		if (m_GameScene.m_BattleFSM.IsGameState())
			gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	}

	void CurrentTime()
	{
		GameInfo kGameInfo = GameMng.Inst.m_GameInfo;

		int nMin = (int)(kGameInfo.m_KeepTime / 60);
		int nSec = (int)(kGameInfo.m_KeepTime) % 60;

		m_txtPlayTime.text = string.Format("{0:00}:{1:00}", nMin, nSec);
		m_publicTime = string.Format("{0:00}:{1:00}", nMin, nSec);
	}
}
