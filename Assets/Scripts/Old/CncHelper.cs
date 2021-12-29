using UnityEngine;

public static class CncHelper
{
    public static float GetScreenWidth()
    {
        var camera = Camera.main;
        var left = camera.ViewportToWorldPoint(new Vector3(0, .5f, camera.nearClipPlane));
        var right = camera.ViewportToWorldPoint(new Vector3(1, .5f, camera.nearClipPlane));
        var dist = Vector3.Distance(left, right);
        return dist;
    }
    
    public static float GetScreenDiagonal()
    {
        var camera = Camera.main;
        var a = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        var b = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        var dist = Vector3.Distance(a, b);
        return dist;
    }
}
