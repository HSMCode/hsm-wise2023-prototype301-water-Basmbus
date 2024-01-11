using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool Death;
    private Renderer rend;
    public GameObject Mesh0;
    public GameObject Mesh1;
    public GameObject Mesh2;
    public GameObject Mesh3;
    public Rigidbody rb;
    public Collider bc;
    public Animator animator;
    [SerializeField] private AudioSource collectionSoundEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cylinder")) // Überprüfe, ob das kollidierte Objekt ein "Cylinder"-Tag hat
        {
            collectionSoundEffect.Play();
            bc = GetComponent<BoxCollider>();
            bc.enabled = false; //remove the collider to avoid the jellyfish getting thrown into oblivion (with the camera attached)
            GetComponent<AutoMovementX>().enabled = false;
            rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0); //sets jellyfish velocity to 0 as precaution
            animator.SetBool("IsDead", true);
            rend = Mesh0.GetComponent<SkinnedMeshRenderer>();
            rend.enabled = false;
            rend = Mesh1.GetComponent<SkinnedMeshRenderer>();
            rend.enabled = false;
            rend = Mesh2.GetComponent<SkinnedMeshRenderer>();
            rend.enabled = false;
            rend = Mesh3.GetComponent<SkinnedMeshRenderer>();
            rend.enabled = false;
            // individually disables the renderers for the different loading distances
            // fucking ugly but necessary to hide the jellyfish without destroying it (and the necessary scripts attached to it)
            Debug.Log("Cube zerstört durch Kollision mit dem Zylinder. Du hast verloren.");
            Death = true;
        }
    }
}

