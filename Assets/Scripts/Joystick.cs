﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CaseStudy
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float Horizontal { get { return input.x; } }
        public float Vertical { get { return input.y; } }

        public float HandleRange
        {
            get { return handleRange; }
            set { handleRange = Mathf.Abs(value); }
        }

        public float DeadZone
        {
            get { return deadZone; }
            set { deadZone = Mathf.Abs(value); }
        }

        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone = 0;

        [SerializeField] protected RectTransform background = null;
        [SerializeField] private RectTransform handle = null;
        private RectTransform baseRect = null;

        private Canvas canvas;
        private Camera cam;

        private Vector2 input = Vector2.zero;
        private Vector2 startPos;
        GameManager gm;

        private void Start()
        {
            gm = GameManager.Instance;

            HandleRange = handleRange;
            DeadZone = deadZone;
            baseRect = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
                Debug.LogError("");

            Vector2 center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
            startPos = background.transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!gm.isStartGame)
                return;

            OnDrag(eventData);
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (!gm.isStartGame)
                return;

            cam = null;
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
                cam = canvas.worldCamera;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
            Vector2 radius = background.sizeDelta / 2;

            input = (eventData.position - position) / (radius * canvas.scaleFactor);
            HandleInput(input.magnitude, input.normalized, radius, cam);
            handle.anchoredPosition = input * radius * handleRange;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
            background.transform.position = startPos;
        }
        void HandleInput(float magnitude, Vector2 normalized, Vector2 radius, Camera cam)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    input = normalized;
            }
            else
                input = Vector2.zero;
        }
    }
}


