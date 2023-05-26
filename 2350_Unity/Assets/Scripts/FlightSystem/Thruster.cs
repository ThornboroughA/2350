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
    public class Thruster : MonoBehaviour
    {
        [Tooltip("The visual effects graph component for this thruster.")]
        private VisualEffect thrusterEffects;

        [SerializeField] private float thrusterThrust = 1f;

        public Propulsion_DataObjects.ThrusterType thrusterType;


        public Rigidbody ActivateEngine(Rigidbody rb, Vector3 direction, float power)
        {

            Vector3 force = direction * power * thrusterThrust;
            rb.AddForceAtPosition(force, transform.localPosition);

            Debug.Log($"Applying force of {force} at position {transform.localPosition}.");

            return rb;
        }



    }
}
