using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    /// <summary>
    /// The script in control of the entire locomotion system for a vessel.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ThrusterMainSystem : MonoBehaviour
    {

        [Header("Thruster sets")]
        public ThrusterLateralSet thrustersForward;
        public ThrusterLateralSet thrustersBackward;
        public ThrusterLateralSet thrustersPort;
        public ThrusterLateralSet thrustersStarboard;

        [Header("Locomotion")]
        [Tooltip("The movement amount of this locomotion system, with values provided by Propulsion_Inputs")]
        public Vector2 movementAmount;

        public bool brakes = false;

        private Rigidbody _rigidbody;

        [SerializeField] private Vector4 moveDirection;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }




        private void Update()
        {
            moveDirection = new Vector4(0, 0, 0, 0);

            SendMovementInputs();
        }

        private void SendMovementInputs()
        {
            brakes = false;

           // ApplyBrakes();

            if (brakes) return;

            SendForwardThrust();
            SendBackwardThrust();
            SendPortThrust();
            SendStarboardThrust();
        }

        private void ApplyBrakes()
        {
            brakes = true;
        }

        private void SendForwardThrust()
        {
            // TODO: Forward thrust is currently tied to the Y axis, for some reason.


            if (movementAmount.y <= 0) return;
            Vector3 direction = new Vector3(0, 0, 1);

            thrustersForward.ApplyForceOnLateralSet(_rigidbody, direction, movementAmount.y);

            moveDirection.x = 1;

        }
        private void SendBackwardThrust()
        {

            if (movementAmount.y >= 0) return;
            Vector3 direction = new Vector3(0, 0, -1);

            thrustersForward.ApplyForceOnLateralSet(_rigidbody, direction, movementAmount.y);
            moveDirection.w = 1;

        }
        private void SendPortThrust()
        {

            if (movementAmount.x >= 0) return;
         
            Vector3 direction = new Vector3(-1, 0, 0);

            thrustersForward.ApplyForceOnLateralSet(_rigidbody, direction, movementAmount.y);


            moveDirection.z = 1;
        }
        private void SendStarboardThrust()
        {
            
            if (movementAmount.x <= 0) return;
            Vector3 direction = new Vector3(1, 0, 0);

            thrustersForward.ApplyForceOnLateralSet(_rigidbody, direction, movementAmount.y);

            moveDirection.y = 1;

        }

    }
}

