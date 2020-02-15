using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace EnergyBar
{

    // Handles bar position in canvas
    // Call methods to update bar fill and text
    // Attached to bar element spawned to canvas

    public class BarHandler : MonoBehaviour, IPointerClickHandler
    {
        [Header("Assign")]
        [SerializeField] RectTransform barRt;
        [SerializeField] RectTransform fillRt;
        [SerializeField] GameObject barContent;
        [SerializeField] Text text;

        [Header("Bar settings")]
        public float barValue = 100f;
        public float updateRate = 1f;

        [Header("Bar click events")]
        public UnityEvent onBarClicked;

        // Visibility
        [Header("Visibility")]
        [SerializeField] bool inFront;
        Vector3 pos;
        bool wasInFront;
        bool init;

        // camera
        Camera cam;
        RectTransform canvasRt;

        // owner object
        Collider ownerCol;

        // bar 
        Vector3 offset;
        float barDefaultWidth;

        // updating 
        float updateTimer;
        string nextText;


        // init ------------

        void Awake()
        {
            barRt = this.transform as RectTransform;
            barDefaultWidth = fillRt.sizeDelta.x;
        }

        public void Init(Camera camera, RectTransform canvasRt, Collider collider, Vector3 offset)
        {
            init = true;
            this.cam = camera;
            this.canvasRt = canvasRt;
            this.ownerCol = collider;
            this.offset = offset;

            // random updateOffset
            updateTimer += UnityEngine.Random.Range(0, updateRate);
        }



        // Main -----------

        void Update()
        {
            if (!init) return;

            LateTextUpdate();
            UpdateBarPosition();
            CullBehindCamera();
        }

        void UpdateBarPosition()
        {
            Vector2 localPoint;

            // calculate position
            var top = new Vector3(ownerCol.bounds.center.x, ownerCol.bounds.max.y + offset.y, ownerCol.bounds.center.z);
            var screeenPos = Camera.main.WorldToScreenPoint(top);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRt, screeenPos, cam, out localPoint);

            // place bar
            barRt.localPosition = localPoint;
        }

        void CullBehindCamera()
        {
            pos = cam.WorldToScreenPoint(ownerCol.gameObject.transform.position);
            inFront = pos.z > 0f;

            if (inFront != wasInFront)
            {
                ShowBar(inFront);
            }

            wasInFront = inFront;
        }

        void LateTextUpdate()
        {
            updateTimer += Time.deltaTime;

            if (updateTimer >= updateRate)
            {
                updateTimer = 0;
                text.text = nextText;
            }
        }



        // Call these ------

        public void UpdateText(string newText)
        {
            if (updateRate == 0)
            {
                this.text.text = newText;
            }
            else
            {
                nextText = newText;
            }
        }       

        public void ShowBar(bool state)
        {
            barContent.SetActive(state);
        }

        public void SetBarValue(float value, float maxValue)
        {
            barValue = Mathf.Clamp(value, 0, maxValue);
            var fill = (value / maxValue) * barDefaultWidth;
            fillRt.sizeDelta = new Vector2(fill, fillRt.sizeDelta.y);
        }



        // Interfaces ------

        public void OnPointerClick(PointerEventData eventData)
        {
            onBarClicked.Invoke();
        }

    }

}
