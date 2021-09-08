using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform Target;
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = Target.position;
        }
    }

}