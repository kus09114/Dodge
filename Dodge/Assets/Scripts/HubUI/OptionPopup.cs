using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPopup : MonoBehaviour
{
	[SerializeField] Button m_btnClose; 

    void Start()
    {
		m_btnClose.onClick.AddListener(OnClick_Close);
	}

	void OnClick_Close()
	{
		gameObject.SetActive(false);
	}
}
