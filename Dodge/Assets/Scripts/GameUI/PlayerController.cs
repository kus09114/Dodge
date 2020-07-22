using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_fMoveSpeed = 0;
	[SerializeField] Transform m_StartPos = null;
	Rigidbody m_MyRigidbody = null;
	GameScene m_GameScene = null;

	[HideInInspector] public bool m_bDie = false;

	private void Start()
	{
		m_MyRigidbody = GetComponent<Rigidbody>();
	}

	public void Initializ()
	{
		m_bDie = false;
		gameObject.transform.position = m_StartPos.position;
		m_GameScene = gameObject.GetComponentInParent<GameScene>();
	}

	void FixedUpdate()
	{
		if (m_GameScene == null)
			m_GameScene = gameObject.GetComponentInParent<GameScene>();

		if (m_GameScene.m_BattleFSM.IsGameState())
		{
			float hor = Input.GetAxis("Horizontal");
			float ver = Input.GetAxis("Vertical");
			
			Vector3 pos = transform.position;
			
			pos.x += hor * Time.deltaTime * m_fMoveSpeed;
			pos.z += ver * Time.deltaTime * m_fMoveSpeed;
			
			transform.position = pos;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Bullet" && !m_bDie)
		{
			m_bDie = true;
			if(m_GameScene == null)
				m_GameScene = gameObject.GetComponentInParent<GameScene>();
			else
				m_GameScene.m_BattleFSM.SetResultState();
		}
	}
}
