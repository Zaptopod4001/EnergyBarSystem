using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EnergyBar
{

    // Factory that spits out energy bars
    // and parents them to assigned canvas

    public class BarCreator : MonoBehaviour
    {
        public static BarCreator instance;
        
        [SerializeField] BarHandler barRtPrefab;
        [SerializeField] RectTransform canvasRt;
        [SerializeField] Camera cam;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
                

        public BarHandler Create(Collider collider, Vector3 offset)
        {
            cam = Camera.main;

            // Rt
            var barHandler = Instantiate(barRtPrefab);
            barHandler.transform.SetParent(canvasRt, false);

            // refresh
            barHandler.Init(cam, canvasRt, collider, offset);

            return barHandler;
        }

    }

}