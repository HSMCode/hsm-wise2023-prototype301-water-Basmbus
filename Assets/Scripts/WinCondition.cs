using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public bool GameWon;
    [SerializeField] private AudioSource collectionSoundEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            collectionSoundEffect.Play();
            Destroy(other.gameObject);
            

            Debug.Log("Victory! Du hast das Level geschafft!");
            GameWon = true;
        }
    }
}
