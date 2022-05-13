using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CaseStudy
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Status Flags")]
        public bool isStartGame;

        [Header("Level Property")]
        [SerializeField]
        private Vector2 mapSize;
        [SerializeField]
        private GameObject point;

        Queue<GameObject> pointQueue = new Queue<GameObject>();
        const int pointCount = 5;
        const int amount = 10;
        const int pointLimit = 100;

        int score;
        public int Score{ get{ return score; } }

        public delegate void CollectPoint();
        public CollectPoint collectPoint;
    
        public void GeneratePoints()
        {
            for (int i = 0; i < pointCount; i++)
            {
                GameObject _point = Instantiate(point,GetPosition(),Quaternion.identity);
            }
        }
        public void Collect(GameObject _point)
        {
            score += amount;

            collectPoint();
            _point.SetActive(false);

            if (score >= pointLimit)
            {
                FindObjectOfType<DisplayController>().GameOver();
                return;
            }
            pointQueue.Enqueue(_point);
            Invoke(nameof(Reposition), 1);
        }
        void Reposition()
        {
            GameObject _point = pointQueue.Dequeue();
            _point.transform.position = GetPosition();
            _point.SetActive(true);
        }

        Vector3 GetPosition()
        {
            float newPosX = Random.Range(-mapSize.x, mapSize.x) * 5f;
            float newPosy = Random.Range(-mapSize.y, mapSize.y) * 5f;

            return new Vector3(newPosX, point.transform.position.y, newPosy);
        }

      
    }

}

