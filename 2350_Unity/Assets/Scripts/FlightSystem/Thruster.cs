using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.VFX;

namespace TwentyThreeFifty.Propulsion
{

    /// <summary>
    /// An individual thruster. Tied to a thruster cluster. Can be specified by type.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Thruster : MonoBehaviour
    {
        [Tooltip("The visual effects graph component for this thruster.")]
        private VisualEffect thrusterEffects;

        public Propulsion_DataObjects.ThrusterType thrusterType;

        public Rigidbody rb;
        [Tooltip("The current thrust of this thruster.")]
        private float currentThrust;

        private void Awake()
        {
            // Set up rigidbody.
            rb = GetComponent<Rigidbody>();
        }


        public void AddForce(float forceAmount)
        {
            Vector3 forceToAdd = new Vector3(0, 0, forceAmount);

            rb.AddForce(forceToAdd, ForceMode.Impulse);
        }

    }
}
