using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    /// <summary>
    /// A container script for all the thrusters corresponding to a particular axis.
    /// </summary>
    public class ThrusterLateralSet : MonoBehaviour
    {
        public ThrusterCluster[] thrusterClusters;

        public float thrustInput;

        private void Start()
        {
            if (thrusterClusters == null)
            {
                Debug.LogWarning($"No thrusterCluster attached to {this}");
            }
        }

        private void Update()
        {
            foreach (ThrusterCluster cluster in thrusterClusters)
            {
                cluster.activeThrust = thrustInput;
            }
        }
    }

}