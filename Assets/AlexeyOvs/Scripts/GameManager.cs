﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject goToDoorPanel;
    public GameObject InputControll;
    public GameObject PanelGems;
    public float timeGemsPanelDisplay = 1.5f;

    public Text gems;
    private Text _gemsLeftText;

    public Animator animDoor;

    public GameObject winPanel;

    //public PlayerController PlayerController;
    //public GameObject enemy;
    private GameObject _gemsPanel;

    public int countGemsToWin = 5;
    private int _curgemsCount = 0; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _gemsPanel = Instantiate(PanelGems);
        _gemsLeftText = _gemsPanel.GetComponentInChildren<Text>();
        _gemsPanel.SetActive(false);
    }

    public void AddGems()
    {
        _curgemsCount++;
        gems.text = _curgemsCount.ToString();
        CheckOnWin(); 
    }
     

    private void CheckOnWin()
    {
        if (_curgemsCount == countGemsToWin)
        {
            goToDoorPanel.SetActive(true);
            animDoor.SetTrigger("Door");
            Invoke("Deactive", 7);
        }
    }

    public void Deactive()
    {
        goToDoorPanel.SetActive(false); 
    }

    public void ActiveWinPanel()
    {
        InputControll.SetActive(false);
        Instantiate(winPanel);
    }

    public void Restart()
    {
        Application.LoadLevel(1);
    }

    public void ViewPanelGems()
    {
       

        DeleteGemsPanel(gemsPanel);
    }

    private void DeleteGemsPanel(GameObject panel)
    { 
        Destroy(panel, timeGemsPanelDisplay);
    }
}
