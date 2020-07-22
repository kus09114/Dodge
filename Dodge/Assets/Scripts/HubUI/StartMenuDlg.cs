using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDlg : MonoBehaviour
{
	[SerializeField] Button m_btnStart = null;
	[SerializeField] Button m_btnOption = null;

	[SerializeField] GameObject m_OptionPopup = null;

	public bool m_bOnStart = false;

	void Start()
	{
		m_btnStart.onClick.AddListener(OnClick_Start);
		m_btnOption.onClick.AddListener(OnClick_Option);
	}

	public void Initializ()
	{

	}

	void Update()
    {
        
    }

	public void SetUI(bool set)
	{
		gameObject.SetActive(set);
	}

	public void OnClick_Start()
	{
		GameScene kGamescene = GameMng.Inst.m_GameScene;

		kGamescene.m_BattleFSM.SetReadyState();
		SetUI(false);
	}

	public void OnClick_Option()
	{
		m_OptionPopup.SetActive(true);
	}
}
