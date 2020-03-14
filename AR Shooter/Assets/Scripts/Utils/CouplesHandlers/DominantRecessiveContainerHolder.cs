using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils.CouplesHandlers
{
    public class DominantRecessiveContainerHolder : MonoBehaviour
    {
        [SerializeField]
        public GameObject RecessivePositionHolder;

        public Vector3 GetRecessiveGlobalCootrdinates()
        {
            //Position as World;
            return RecessivePositionHolder.transform.position;
        }
        public Quaternion GetRecessiveGlobalRotation()
        {
            return RecessivePositionHolder.transform.rotation;
        }
    }
}
