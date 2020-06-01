using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnergyBar
{
    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    // Demo class
    // Random wandering behaviour
    // for spawned NPC

    public class NpcMovement : MonoBehaviour
    {
        [SerializeField] bool wander;
        [SerializeField] float speed = 1f;

        // locals
        Vector3 nextPos;


        void Start()
        {
            GetNextTarget();
        }

        void Update()
        {
            if (wander) DoWander();
        }



        // movement -------

        void DoWander()
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextPos) < 0.1f)
            {
                GetNextTarget();
            }
        }

        void GetNextTarget()
        {
            var p = UnityEngine.Random.onUnitSphere * 3f;
            p.y = 0f;
            nextPos = transform.position + p;
        }

    }

}
