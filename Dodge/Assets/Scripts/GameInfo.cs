using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo 
{
	public float m_KeepTime = 0;

	public void Initialize()
	{
		m_KeepTime = 0;
	}

	public void OnUpdate(float fElasedTime)
	{
		m_KeepTime += fElasedTime;
	}

	public void ReStartGame()
	{
		m_KeepTime = 0;
	}
}
