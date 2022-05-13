using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class Animation : MonoBehaviour
    {
       
        public GameManager gm;

        Animator animator;     
        public virtual void Start()
        {
            animator = GetComponent<Animator>();
            gm = GameManager.Instance;
        }

        public virtual void PlayAnim(int animId)
        {
            animator.SetTrigger(animId);
        }
    }

}
