using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
	public HubUI m_HubUI = null;
	public GameUI m_GameUI = null;

	[HideInInspector] public BattleFSM m_BattleFSM = null; // new BattleFSM();

	void Awake()
	{
		//m_BattleFSM = new BattleFSM();
	}

	void Start()
	{
		GameMng.Inst.m_GameScene = this;
		InitFSM();
		Initializ();
	}

	public void InitFSM()
	{
		if (m_BattleFSM == null)
		{
			m_BattleFSM = new BattleFSM();
			m_BattleFSM.Initialize(Callback_ReadyEnter, Callback_WaveEnter, Callback_GameEnter, Callback_ResultEnter);
		}
	}

	void Initializ()
	{
		m_HubUI.Initializ();
	}

	void Update()
	{
		if (m_BattleFSM == null)
		{
			InitFSM();
		}
		else
		{
			m_BattleFSM.OnUpdate();
			if(m_BattleFSM.IsGameState())
				GameMng.Inst.OnUpdate(Time.deltaTime);
		}

	}

	public void Callback_ReadyEnter()
	{
		m_HubUI.StartReadyCount();
		m_GameUI.m_PlayerController.Initializ();
	}
	public void Callback_WaveEnter()
	{

	}
	public void Callback_GameEnter()
	{
		GameStart();
	}
	public void Callback_ResultEnter()
	{
		Invoke("ResultState", 1.0f);
	}

	void GameStart()
	{
		m_GameUI.Initializ();
		GameMng.Inst.m_GameInfo.ReStartGame();
	}
	void ResultState()
	{
		m_HubUI.Initializ();
		m_HubUI.SetResultState();
	}
}
