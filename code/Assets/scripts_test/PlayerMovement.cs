using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnergyBar
{

    // Demo class
    // Allows player to move and rotate
    // with WASD / Arrow keys

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float x;
        [SerializeField] float y;
        [SerializeField] float z;

        void Update()
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            var input = new Vector3(0, 0, z);

            transform.position += transform.forward * z;

            transform.Rotate(Vector3.up * x, Space.World);
        }

    }

}