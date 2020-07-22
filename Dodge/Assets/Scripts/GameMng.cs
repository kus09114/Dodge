using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng
{
	static GameMng _instance = null;
	public static GameMng Inst
	{
		get
		{
			if (_instance == null)
				_instance = new GameMng();

			return _instance;
		}
	}
	//----------------------------------------------

	public GameScene m_GameScene = null;

	public GameInfo m_GameInfo = new GameInfo();


	public void Initialize()
	{

	}

	public void OnUpdate(float fElasedTime)
	{
		m_GameInfo.OnUpdate(fElasedTime);
	}
}
