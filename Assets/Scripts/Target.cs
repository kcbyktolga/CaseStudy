using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class Target : MonoBehaviour
    {
        Player player;
        void Start()
        {
            player = FindObjectOfType<Player>();
        }

        
        void FixedUpdate()
        {
            transform.position = player.transform.position;
        }
    }

}

