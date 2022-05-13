using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    [CreateAssetMenu(fileName ="Movement Settings", menuName ="Settings/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        [Range(0, 10)]
        [SerializeField]
        private float speed;

        [Range(0, 20)]
        [SerializeField]
        private float turningSpeed;

        public float TurningSmoothing
        { get { return turningSpeed; } }
        public float Speed
        { get { return speed; } }

    }

}
