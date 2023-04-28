using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public float timeLimit = 60f;
   private float time;
   
   public TextMeshProUGUI timeText;
   
   public Player player;
   
   public GameObject restartScreen;
   public GameObject finishScreen;
   
   public string nextLevelName;
   
   
   private void Start()
   {
      time = timeLimit;
      player.manager = this;
   }

   private void Update()
   {
      if (time <= 0)
      {
         ShowRestartScreen();
      }
      time -= Time.deltaTime;
      int integerTimeLimit = (int) time;
      timeText.text = "Лимит времени: " + integerTimeLimit.ToString();
   }

   public void ShowFinishScreen()
   {
      timeText.gameObject.SetActive(false);
      player.disableControls = true;
      finishScreen.SetActive(true);
   }

   public void ShowRestartScreen()
   {
      timeText.gameObject.SetActive(false);
      player.disableControls = true;
      restartScreen.SetActive(true);

   }
   public void Restart()
   {
      timeText.gameObject.SetActive(true);
      restartScreen.SetActive(false);
      player.disableControls = false;
      player.ReturnToSpawn();
      time = timeLimit;
   }

   public void LoadNextLevel()
   {
      timeText.gameObject.SetActive(true);
      finishScreen.SetActive(false);
      player.disableControls = false;
      SceneManager.LoadScene(nextLevelName);
   }
}
