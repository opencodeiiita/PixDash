using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
	public Transform layerTransform;

	[Range(0f, 1f)]
	public float parallaxFactor = 0.5f;
}
