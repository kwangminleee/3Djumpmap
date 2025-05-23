using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed = 3f;
    public float waitTime = 1f;

    private int targetIndex = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (points.Length == 0 || isWaiting) return;

        Transform target = points[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            StartCoroutine(WaitAndSwitchTarget());
        }
    }

    IEnumerator WaitAndSwitchTarget()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        targetIndex = (targetIndex + 1) % points.Length;
        isWaiting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
