using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public Turret[] m_Turrets = null;
	public PlayerController m_PlayerController = null;
	public MapFrame m_MapFrame = null;

    void Start()
    {
		//Initializ(); 
	}

	public void Initializ()
	{
		// 플레이어 초기화
		m_PlayerController.Initializ();

		// 각 터렛 초기화
		for ( int i = 0; i < m_Turrets.Length; i++)
		{
			m_Turrets[i].Initialize(m_PlayerController.transform);
		}
	}

	void Update()
    {
        
    }
}
