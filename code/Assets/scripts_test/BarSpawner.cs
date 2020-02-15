using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnergyBar
{

    // Demo class
    // How to spawn a new energy bar
    // How to call energy bar methods

    public class BarSpawner : MonoBehaviour
    {

        [SerializeField] Collider ownerCollider;
        [SerializeField] Vector3 offset = new Vector3(0, 1f, 0f);

        // Locals
        BarHandler bar;

        void Start()
        {
            // Demo - create bar
            bar = BarCreator.instance.Create(ownerCollider, offset);

            // Demo - add listener
            bar.onBarClicked.AddListener(() =>
           {
               bar.barValue -= 5f;
               bar.SetBarValue(bar.barValue, 100f);
           });

        }

        void Update()
        {
            // Demo - update bar text
            
            // NOTE: 
            // updating texts in each frame
            // is pretty expensive (and not recommended)
            // With 100+ bars you'll see 
            // slowdown depending on your system

            bar.UpdateText("Pos:" + transform.position);
        }

    }

}