using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{
    public class Player : MonoBehaviour
    {
        [Header("Property")]
        [SerializeField]
        private PlayerMovementSettings settings;
        [SerializeField]
        private string pointTag;
        
        private PlayerInput playerInput;
        private Rigidbody playerRigidbody;
        private Vector3 movement;
        private GameManager gm;
        
        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerInput = GetComponent<PlayerInput>();
            gm = GameManager.Instance;
        }

        private void FixedUpdate()
        {
            if (!gm.isStartGame)
                return;
            Move(playerInput.Direction);
        }

        private void Move( Vector3 direction)
        {
            float vertical = direction.z;
            float horizontal = direction.x;

            movement.Set(vertical, 0f, horizontal);
            movement = settings.Speed*Time.fixedDeltaTime* movement.normalized;
            playerRigidbody.MovePosition(transform.position + movement);

            if (horizontal != 0f || vertical != 0f)
            {
                Rotating(horizontal, vertical);
            }
        }
        private void Rotating(float horizontal, float vertical)
        {
            
            Vector3 targetDirection = new Vector3(vertical, 0f, horizontal);           
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);           
            Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, settings.TurningSmoothing * Time.deltaTime);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(pointTag))
                return;

            gm.Collect(other.gameObject);
            
        }
    }
}

