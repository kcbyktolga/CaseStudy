using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
            }
        }



    }
}

