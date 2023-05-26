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

        private Rigidbody _rigidbody;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }




        private void Update()
        {
            SendMovementInputs();
        }

        private void SendMovementInputs()
        {
            SendForwardThrust();
        }


        private void SendForwardThrust()
        {
            // TODO: Forward thrust is currently tied to the Y axis, for some reason.

            //      thrustersForward.thrustInput = movementAmount.y;

            Vector3 direction = new Vector3(0, 0, 1);

            thrustersForward.ApplyForceOnLateralSet(_rigidbody, direction, movementAmount.y);


        }

    }
}

