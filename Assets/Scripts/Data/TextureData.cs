using UnityEngine;
using System.Collections;
using System.Linq;

[CreateAssetMenu()]
public class TextureData : UpdatableData
{
	public Layer[] layers;

	float savedMinHeight;
	float savedMaxHeight;

	public void ApplyToMaterial(Material material)
	{

		material.SetInt("layerCount", layers.Length);
		material.SetColorArray("baseColours", layers.Select(x => x.tint).ToArray());
		material.SetFloatArray("baseStartHeights", layers.Select(x => x.startHeight).ToArray());
		material.SetFloatArray("baseBlends", layers.Select(x => x.blendStrength).ToArray());
		material.SetFloatArray("baseColourStrength", layers.Select(x => x.tintStrength).ToArray());
		material.SetFloatArray("baseTextureScales", layers.Select(x => x.textureScale).ToArray());

		UpdateMeshHeights(material, savedMinHeight, savedMaxHeight);
	}

	public void UpdateMeshHeights(Material material, float minHeight, float maxHeight)
	{
		savedMinHeight = minHeight;
		savedMaxHeight = maxHeight;

		material.SetFloat("minHeight", minHeight);
		material.SetFloat("maxHeight", maxHeight);
	}

	Texture2DArray GenerateTextureArray(Texture2D[] textures)
    {
		Texture2DArray textureArray = new Texture2DArray(null, null, null, null, null);

		return textureArray;
    }

	[System.Serializable]
	public class Layer
    {
		public Texture texture;
		public Color tint;
		[Range(0, 1)]
		public float tintStrength;
		[Range(0, 1)]
		public float startHeight;
		[Range(0, 1)]
		public float blendStrength;
		public float textureScale;
    }
}