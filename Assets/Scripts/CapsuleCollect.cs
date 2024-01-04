using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    public int Score;
    public ParticleSystem pickup;
    void Start ()
    {
        pickup = GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Capsule")) // �berpr�fe, ob das kollidierte Objekt ein "Capsule"-Tag hat
        {
            Destroy(other.gameObject); // Zerst�re die Kapsel
            Debug.Log("Capsule aufgesammelt!");
            Score++;
            pickup.Play();
        }
    }
}

