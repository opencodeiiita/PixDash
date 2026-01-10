using UnityEngine;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{
	[Header("Camera")]
	[Tooltip("Camera used to drive parallax (Cinemachine compatible)")]
	public Transform cameraTransform;

	[Header("Parallax Layers")]
	public List<ParallaxLayer> layers = new();

	private Vector3 lastCameraPosition;

	private void Awake()
	{
		if (cameraTransform == null)
		{
			Debug.LogError("ParallaxManager: Camera Transform is not assigned.");
			enabled = false;
			return;
		}
	}

	private void Start()
	{
		lastCameraPosition = cameraTransform.position;

		// Clamp all factors defensively
		foreach (var layer in layers)
		{
			layer.parallaxFactor = Mathf.Clamp01(layer.parallaxFactor);
		}
	}

	private void LateUpdate()
	{
		Vector3 cameraDelta = cameraTransform.position - lastCameraPosition;

		foreach (var layer in layers)
		{
			if (layer.layerTransform == null) continue;

			Vector3 parallaxMovement = new Vector3(
				cameraDelta.x * layer.parallaxFactor,
				cameraDelta.y * layer.parallaxFactor,
				0f
			);

			layer.layerTransform.position += parallaxMovement;
		}

		lastCameraPosition = cameraTransform.position;
	}
}
