using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpOnSpace : MonoBehaviour
{
    public float moveDistance = 1f; // Entfernung, um die sich das Objekt bewegen soll
    bool playerWin = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        if (!playerWin) // Bewege das Objekt um die angegebene Entfernung nach oben
            transform.Translate(Vector3.up * moveDistance);
        Debug.Log("Leertaste gedr�ckt. Das Objekt wurde nach oben bewegt.");
        // �berpr�fe auf Kollision mit der Sphere
        CheckForCollision();
    }
    void CheckForCollision()
    {
        // �berpr�fe, ob das Objekt mit der Sphere kollidiert
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f); // Annahme: Sphere hat einen Radius von 0.5
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Sphere")) 
            {
             
                playerWin = true;
                Debug.Log("Der Spieler hat die Sphere ber�hrt und gewonnen!");
                break;
            }
        }
    }
}
