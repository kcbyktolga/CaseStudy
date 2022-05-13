using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;


namespace CaseStudy
{
    public class DisplayController : Animation
    {
        [SerializeField]
        private Button button;

        int startAnimId;
        int gameOverAnimId;

        public override void Start()
        {
            base.Start();

            startAnimId = Animator.StringToHash("Start");
            gameOverAnimId = Animator.StringToHash("GameOver");

            OnClick(StartGame);
        }

        void OnClick(Action action)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => action.Invoke());
        }
        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        void StartGame()
        {
            PlayAnim(startAnimId);
            gm.GeneratePoints();
            gm.isStartGame = true;
            OnClick(Restart);
        }
        public void GameOver()
        {
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = "Restart";
            PlayAnim(gameOverAnimId);
            gm.isStartGame = false;
        }
    }


}
