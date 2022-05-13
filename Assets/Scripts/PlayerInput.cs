using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class PlayerInput : MonoBehaviour
    {
        public Joystick input;  
        private Vector3 direction;
        private Vector3 lastDirection;

        public Vector3 Direction { get { return direction; } }


        private void Update()
        {
          

            float inputX = input.Horizontal;
            float inputZ = -input.Vertical;
            direction += lastDirection;
            direction = new Vector3(inputX,0,inputZ);
            lastDirection = direction;

        }
    } 

}

