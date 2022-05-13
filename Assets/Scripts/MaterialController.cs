using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    //[ExecuteInEditMode]
    public class MaterialController : MonoBehaviour
    {
        [SerializeField]
        private Color mainColor;

        MaterialPropertyBlock _materialPropertyBlock;
        Renderer _renderer;
        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _materialPropertyBlock = new MaterialPropertyBlock();

            SetColor();
        }

        void SetColor()
        {           
            _materialPropertyBlock.SetColor("_Color",mainColor);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }

        //private void Update()
        //{
        //    SetColor(); 
        //}
     
    }
}

