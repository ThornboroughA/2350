using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwentyThreeFifty.Propulsion
{
    public class ThrusterLateralSet : MonoBehaviour
    {
        public ThrusterCluster[] thrusterClusters;

        private void Start()
        {
            if (thrusterClusters == null)
            {
                Debug.LogWarning($"No thrusterCluster attached to {this}");
            }


        }
    }

}