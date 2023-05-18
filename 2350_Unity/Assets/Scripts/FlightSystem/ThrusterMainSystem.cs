using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    /// <summary>
    /// The script in control of the entire locomotion system for a vessel.
    /// </summary>
    public class ThrusterMainSystem : MonoBehaviour
    {
        [Tooltip("The universally-shared configuration for rigidbodies of the thrusters.")]
        [SerializeField] public RigidbodyData rbParameters;

        [Header("Thruster sets")]
        public ThrusterLateralSet thrustersForward;
        public ThrusterLateralSet thrustersBackward;
        public ThrusterLateralSet thrustersPort;
        public ThrusterLateralSet thrustersStarboard;

        [Header("Locomotion")]
        [Tooltip("The movement amount of this locomotion system, with values provided by Propulsion_Inputs")]
        public Vector2 movementAmount;


        #region STARTUP

        private void Start()
        {
            SetUpRigidbodies();

        }

        /// <summary>
        /// Set up the rigidbody parameters for all the thrusters in this locomotion system.
        /// </summary>
        private void SetUpRigidbodies()
        {
            List<ThrusterLateralSet> allThrusterSets = new List<ThrusterLateralSet>();
            allThrusterSets.Add (thrustersForward);
            allThrusterSets.Add(thrustersBackward);
            allThrusterSets.Add(thrustersPort);
            allThrusterSets.Add(thrustersStarboard);

            foreach(ThrusterLateralSet lateralSet in allThrusterSets)
            {
                if (lateralSet == null)
                {
                    return;
                }

                foreach (ThrusterCluster cluster in lateralSet.thrusterClusters)
                {
                    cluster.ConfigureThrusterRigidbodies(rbParameters);
                }
            }
        }

        public void SetRigidbodyValues(Rigidbody rb)
        {
            rb.drag = rbParameters.drag;
            rb.angularDrag = rb.angularDrag;
            rb.useGravity = rbParameters.useGravity;
            rb.interpolation = rbParameters.interpolation;
            rb.collisionDetectionMode = rbParameters.collisionDetection;
        }


        #endregion


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

            thrustersForward.thrustInput = movementAmount.y;


        }

    }
}

