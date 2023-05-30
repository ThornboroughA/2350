using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime;
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
        public VisualEffect thrusterEffects;

        [HideInInspector][Tooltip("The amount of thrust a thruster of this type gets as dictated by the cluster. Applied on launch.")]
        public float thrusterClusterModifier = 1f;
        [Tooltip("An additional strength modifier applied locally by the thruster.")]
        [SerializeField] private const float thrusterLocalModifier = 1f;
        
        private float clusterInputStrength = 0f;
        private float visualStrength = 0f;

        public Propulsion_DataObjects.ThrusterType thrusterType;

        // The min and max of the thruster particle lifetime.
        private float thrusterLifetimeRange;
        private float thrusterScaleRange;

        private void Awake()
        {

            // Set initial thruster visuals.
            if (thrusterEffects != null)
            {
                thrusterLifetimeRange = thrusterEffects.GetFloat("Lifetime");
                thrusterScaleRange = thrusterEffects.GetFloat("Scale");

                Debug.Log($"Thruster lifetime is {thrusterLifetimeRange}, thruster scale is {thrusterScaleRange}.");
            }            
        }
        

        private void LateUpdate()
        {
            HandleThrusterVisuals();

        }

        private void HandleThrusterVisuals()
        {
            // If thrusters are disabled or null, return, else enable.
            if (thrusterEffects == null)
            {
                return;
            }
            if (clusterInputStrength == 0 && visualStrength <= 0)
            {
                thrusterEffects.enabled = false;
                return;
            }
            thrusterEffects.enabled = true;

            float transitionSpeed = 2f;
            visualStrength = Mathf.Lerp(visualStrength, clusterInputStrength, Time.deltaTime * transitionSpeed);


            // The current power input is converted into a value in the range for the thruster visuals.

            thrusterEffects.SetFloat("Lifetime", visualStrength * (thrusterLifetimeRange));
            thrusterEffects.SetFloat("Scale", visualStrength * thrusterScaleRange);
        }

        public Rigidbody ActivateEngine(Rigidbody rb, Vector3 direction, float inputStrength)
        {
            float power = thrusterClusterModifier * inputStrength;

            Vector3 force = direction * power * thrusterLocalModifier;
            rb.AddForceAtPosition(force, transform.localPosition);

            // Debug.Log($"Applying force of {force} at position {transform.localPosition}.");

            clusterInputStrength = inputStrength;
            return rb;
        }
    }
}
