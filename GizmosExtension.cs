using UnityEngine;
using UnityEditor;

public static class GizmosAnimation
{
    static float time => (float)EditorApplication.timeSinceStartup;

    public static void DrawMovingDottedLine(Vector3 from, Vector3 to, Color col1, Color col2, int segment = 16)
    {
        float segmentLength = Vector3.Distance(from, to) / segment;
        float offsetAmount = time % segmentLength;
        Vector3 dir = (to - from).normalized;
        Vector3 offset = dir * offsetAmount;
        Vector3 lastPoint = from;
        for (int i = 0; i < segment; i++)
        {
            Gizmos.color = i % 2 == 0 ? col1 : col2;
            float t = (float)i / segment;
            Vector3 lerp = Vector3.Lerp(from, to, t);

            Gizmos.DrawLine(lastPoint + offset, lerp + offset);
            lastPoint = lerp;
        }
    }
}