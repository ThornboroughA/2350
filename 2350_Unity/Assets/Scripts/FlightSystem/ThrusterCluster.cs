using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    /// <summary>
    /// In command of a series of associated thrusters, with finer control over specifications of them.
    /// </summary>
    public class ThrusterCluster : MonoBehaviour
    {
        public Thruster[] thrusters;

        [Tooltip("The visual status of the thrusters. If active, start active. If disabled, start inactive. If destroy, delete on start.")]
        [SerializeField] private VisualType thrusterVisuals = VisualType.active;

        [Header("Thruster strength")]
        [Tooltip("The force output of the primary engines.")]
        public const float primaryForce = 1f;
        [Tooltip("The force output of the secondary engines.")]
        public const float secondaryForce = 0.5f;
        [Tooltip("The force output of the tertiary engines.")]
        public const float tertiaryForce = 0.25f;


        private void Start()
        {
            // Disable or destroy thruster particle systems if configured to.
            if (thrusterVisuals == VisualType.inactive)
            {
                foreach (Thruster thruster in thrusters)
                {
                    if (thruster.thrusterEffects == null) continue;
                    thruster.thrusterEffects.enabled = false;
                }
            } else if (thrusterVisuals == VisualType.destroy)
            {
                foreach (Thruster thruster in thrusters)
                {
                    if (thruster.thrusterEffects == null) continue;
                    Destroy(thruster.thrusterEffects);
                }
            }

            SetThrusterChildValuesBasedOnType();
        }

        /// <summary>
        /// Sets the thrusterClusterModifier values -- the basic thrust -- of each of this cluster's thrusters depending on whether they're primary, secondary, or tertiary.
        /// </summary>
        private void SetThrusterChildValuesBasedOnType()
        {
            foreach (Thruster thruster in thrusters)
            {
                switch (thruster.thrusterType)
                {
                    case Propulsion_DataObjects.ThrusterType.primary:
                        thruster.thrusterClusterModifier = primaryForce;
                        break;
                    case Propulsion_DataObjects.ThrusterType.secondary:
                        thruster.thrusterClusterModifier = secondaryForce;
                        break;
                    case Propulsion_DataObjects.ThrusterType.tertiary:
                        thruster.thrusterClusterModifier = tertiaryForce;
                        break;
                }
            }
        }

        /// <summary>
        /// Apply force to all the thrusters in command by this ThrusterCluster. Activates and sets the amount of force dependent on the type of thruster in question; primary, secondary, or tertiary.
        /// </summary>
        /// <param name="inputStrength">The amount of input strength given to these thrusters. Only primary thrusters fire until a certain threshold is passed.</param>
        public void HandleThrusterCluster(Rigidbody rb, Vector3 direction, float inputStrength)
        {
            HandleThrusterMovement(rb, direction, inputStrength);
        }

        private void HandleThrusterMovement(Rigidbody rb, Vector3 direction, float inputStrength)
        {
            foreach (Thruster thruster in thrusters)
            {
                thruster.ActivateEngine(rb, direction, inputStrength);
            }

        }

    }
}