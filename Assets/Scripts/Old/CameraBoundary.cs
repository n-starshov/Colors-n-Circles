using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

public class CameraBoundary : MonoBehaviour
{
	[SerializeField] private Transform _leftPad;
	[SerializeField] private Transform _rightPad;

	private void Start()
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
		var camera = Camera.main;
		var safeArea = Screen.safeArea;
		var l = new Vector3(safeArea.xMin, safeArea.height / 2, 0f);
		var p = camera.ScreenToWorldPoint(l);
		_leftPad.position = p + Vector3.left * _leftPad.localScale.x * 0.5f;
		l = new Vector3(safeArea.xMax, safeArea.height / 2, 0f);
		p = camera.ScreenToWorldPoint(l);
		_rightPad.position = p + Vector3.right * _rightPad.localScale.x * 0.5f;
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
