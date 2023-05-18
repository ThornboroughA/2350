using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    /// <summary>
    /// In command of a series of associated thrusters.
    /// </summary>
    public class ThrusterCluster : MonoBehaviour
    {
        public Thruster[] thrusters;

        [Header("Thruster strength")]
        [Tooltip("The force output of the primary engines.")]
        public float primaryForce = 1f;
        [Tooltip("The force output of the secondary engines.")]
        public float secondaryForce = 0.5f;
        [Tooltip("The force output of the tertiary engines.")]
        public float tertiaryForce = 0.25f;


        /// <summary>
        /// Configure the rigidbody components with standardized parameters.
        /// </summary>
        /// <param name="parameters">A RigidbodyData scriptable object to feed in the values.</param>
        public void ConfigureThrusterRigidbodies(RigidbodyData parameters)
        {
            foreach (Thruster thruster in thrusters)
            {
                Rigidbody rb = thruster.rb;

                rb.drag = parameters.drag;
                rb.angularDrag = parameters.angularDrag;
                rb.useGravity = parameters.useGravity;
                rb.interpolation = parameters.interpolation;
                rb.collisionDetectionMode = parameters.collisionDetection;
            }
        }

        /// <summary>
        /// Apply force to all the thrusters in command by this ThrusterCluster. Activates and sets the amount of force dependent on the type of thruster in question; primary, secondary, or tertiary.
        /// </summary>
        /// <param name="inputStrength">The amount of input strength given to these thrusters. Only primary thrusters fire until a certain threshold is passed.</param>
        public void ApplyForceToThrusters(float inputStrength)
        {
            foreach (Thruster thruster in thrusters)
            {
                switch (thruster.thrusterType)
                {
                    case Propulsion_DataObjects.ThrusterType.primary:
                        break;
                    case Propulsion_DataObjects.ThrusterType.secondary:
                        break;
                    case Propulsion_DataObjects.ThrusterType.tertiary:
                        break;
                    default:
                        break;
                }
            }
        }

    }
}