using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class CameraShake : Animation
    {
        int shakeAnimId;
        public override void Start()
        {
            base.Start();

            shakeAnimId = Animator.StringToHash("Shake");
            gm.collectPoint += Shake;
        }

        void Shake()
        {
            PlayAnim(shakeAnimId);
        }

    }
}

