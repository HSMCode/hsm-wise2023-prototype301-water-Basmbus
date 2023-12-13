using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cylinder")) // �berpr�fe, ob das kollidierte Objekt ein "Cylinder"-Tag hat
        {
            Destroy(gameObject); // Zerst�re den Cube
            Debug.Log("Cube zerst�rt durch Kollision mit dem Zylinder. Du hast verloren.");
        }
    }
}

