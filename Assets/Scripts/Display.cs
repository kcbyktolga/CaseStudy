using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CaseStudy
{
    public class Display : Animation
    {       
        private TMP_Text scoreText;     
        int collectAnimId;

        public override void Start()
        {
            base.Start();

            scoreText = GetComponent<TMP_Text>();
            collectAnimId = Animator.StringToHash("Collect");
            gm.collectPoint += UpdateScore;
        }

        private void UpdateScore()
        {
            scoreText.text = $"Score: {gm.Score}";
            PlayAnim(collectAnimId); 
        }
    }

}
