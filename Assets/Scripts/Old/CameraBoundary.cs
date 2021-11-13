using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class CameraBoundary : MonoBehaviour
{
	[SerializeField] private Transform _leftPad;
	[SerializeField] private Transform _rightPad;

	private void Awake()
	{
		UpdatePads();
	}

#if UNITY_EDITOR
	private void Update()
	{
		UpdatePads();
	}
#endif
	
	private void UpdatePads()
	{
		Camera camera = Camera.main;
		Vector3 p = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
		_leftPad.position = p + Vector3.left;
		p = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
		_rightPad.position = p + Vector3.right;
	}

	void OnDrawGizmosSelected()
	{
	    Camera camera = Camera.main;
	    Gizmos.color = Color.yellow;
	    
	    Vector3 p = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, camera.nearClipPlane));
	    Gizmos.DrawSphere(p, 0.1F);
	    p = camera.ViewportToWorldPoint(new Vector3(1, 0.5f, camera.nearClipPlane));
	    Gizmos.DrawSphere(p, 0.1F);
	}
}
