using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(AnimateLine());
    }

    private IEnumerator AnimateLine(){
        float startTime = Time.time;

        Vector3 startPos = lineRenderer.GetPosition(0);
        Vector3 endPos = lineRenderer.GetPosition(1);
        Vector3 currentPos = startPos;

        while (currentPos != endPos)
        {
            float t = (Time.time - startTime)/animationDuration;
            currentPos = Vector3.Lerp(startPos, endPos, t);
            lineRenderer.SetPosition(1, currentPos);
            yield return null;
        }

    }
}
