using System; 
using UnityEngine; 

namespace UnityStandardAssets.ImageEffects 
{ 
	[RequireComponent (typeof(Camera))] 
	public class BlackEffect : PostEffectsBase 
	{ 
		public Shader TintShader = null; 
		private float _count = 1f;
		public float count
		{
			get{
				return _count;
			}
			set{ 
				_count = value;
			}
		}
		public Material TintMaterial = null; 

		public override bool CheckResources () 
		{ 
			CheckSupport (true); 
			TintMaterial = CheckShaderAndCreateMaterial (TintShader,TintMaterial); 

			if (!isSupported) 
				ReportAutoDisable (); 
			return isSupported; 
		} 
		void OnRenderImage (RenderTexture source, RenderTexture destination) 
		{ 
			if (CheckResources()==false) 
			{ 
				Graphics.Blit (source, destination); 
				return; 
			} 
			TintMaterial.SetFloat("count", Mathf.Clamp01(_count)); 

			//Do a full screen pass using TintMaterial 
			Graphics.Blit (source, destination, TintMaterial); 
		} 
	} 
}
