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


        [Header("Thruster strength")]
        [Tooltip("The force output of the primary engines.")]
        public float primaryForce = 1f;
        [Tooltip("The force output of the secondary engines.")]
        public float secondaryForce = 0.5f;
        [Tooltip("The force output of the tertiary engines.")]
        public float tertiaryForce = 0.25f;


        /// <summary>
        /// Apply force to all the thrusters in command by this ThrusterCluster. Activates and sets the amount of force dependent on the type of thruster in question; primary, secondary, or tertiary.
        /// </summary>
        /// <param name="inputStrength">The amount of input strength given to these thrusters. Only primary thrusters fire until a certain threshold is passed.</param>
        public void ApplyForceToThrusters(Rigidbody rb, Vector3 direction, float inputStrength)
        {
            foreach (Thruster thruster in thrusters)
            {
           //     Debug.Log($"Sending {inputStrength} to {thruster.gameObject.name}");
                switch (thruster.thrusterType)
                {
                    case Propulsion_DataObjects.ThrusterType.primary:
                        //thruster.currentThrust = ( activeThrust * primaryForce);

                        thruster.ActivateEngine(rb, direction, (inputStrength * primaryForce) );

                        break;
                    case Propulsion_DataObjects.ThrusterType.secondary:
                        //     thruster.currentThrust = (activeThrust * secondaryForce);

                        thruster.ActivateEngine(rb, direction, (inputStrength * secondaryForce));
                        break;
                    case Propulsion_DataObjects.ThrusterType.tertiary:
                        //   thruster.currentThrust = (activeThrust * tertiaryForce);

                        thruster.ActivateEngine(rb, direction, (inputStrength * tertiaryForce));
                        break;
                    default:
                     //   thruster.currentThrust = (activeThrust * primaryForce);
                        Debug.LogWarning($"Thruster type not assigned on {thruster.gameObject.name}.");
                        break;
                }
            }
        }

    }
}