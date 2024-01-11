using System.Collections;
using UnityEngine;

public class MoveUpOnSpace : MonoBehaviour
{
    public float moveDistance = 1f; // Entfernung, um die sich das Objekt bewegen soll
    bool playerWin = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playerWin)
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        if (!playerWin) // Bewege das Objekt um die angegebene Entfernung nach oben
        {
            transform.Translate(Vector3.up * moveDistance);
            Debug.Log("Leertaste gedrückt. Das Objekt wurde nach oben bewegt.");
            // Überprüfe auf Kollision mit der Sphere
            CheckForCollision();
        }
    }

    void CheckForCollision()
    {
        // Überprüfe, ob das Objekt mit der Sphere kollidiert
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f); // Annahme: Sphere hat einen Radius von 0.5
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Sphere"))
            {
                playerWin = true;
                Debug.Log("Der Spieler hat die Sphere berührt und gewonnen!");
                StartCoroutine(DisableMovement());
                break;
            }
        }
    }

    IEnumerator DisableMovement()
    {
        // Warte eine Sekunde, um sicherzustellen, dass die Bewegung abgeschlossen ist
        yield return new WaitForSeconds(1f);
        // Deaktiviere die Script-Komponente, um die Bewegung zu stoppen
        this.enabled = false;
    }
}