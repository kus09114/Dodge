using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	float m_Speed;

	Vector3 m_vDir;

	void Start()
	{
		Destroy(this.gameObject, 5.0f);
	}

	public void Initialize(Vector3 vTarget, float speed, Transform tTarget)
	{
		m_vDir = vTarget - transform.position;
		m_vDir.Normalize();
		transform.LookAt(tTarget);
		m_Speed = speed;
	}

	void Update()
	{
		Move();
	}

	void Move()
	{
		transform.Translate(m_vDir * m_Speed, Space.World);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}
