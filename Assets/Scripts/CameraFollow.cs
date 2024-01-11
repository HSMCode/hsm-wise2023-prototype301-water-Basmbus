using System.Collections;
using UnityEngine;

public class FollowCubeHeight : MonoBehaviour
{
    public Transform target; // Das Transform-Objekt des Cubes
    public float yOffset = 0.5f; // Der vertikale Offset zwischen der Kamera und dem Cube
    public float lerpSpeed = 1f; // Die Geschwindigkeit, mit der die Kamera lerpt

    void Update()
    {
        if (target != null)
        {
            StartCoroutine(LerpCamera());
        }
    }

    IEnumerator LerpCamera()
    {
        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime);
            elapsedTime += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        transform.position = targetPos; // Stelle sicher, dass die Zielposition genau erreicht wird
    }
}