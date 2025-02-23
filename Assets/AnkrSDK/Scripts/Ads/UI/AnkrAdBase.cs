using AnkrAds.Ads;
using AnkrAds.Ads.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AnkrSDK.Ads.UI
{
	public abstract class AnkrAdBase : MonoBehaviour
	{
		private bool _isReady;

		public bool IsReady
		{
			get => _isReady;
			private set
			{
				if (!value)
				{
					gameObject.SetActive(false);
				}

				_isReady = value;
			}
		}

		public virtual async UniTask SetupAd(byte[] byteData)
		{
			IsReady = false;
			var tex = new Texture2D(2, 2);
			tex.LoadImage(byteData);
			OnTextureLoaded(tex);
			IsReady = true;
		}

		public void TryShow()
		{
			if (!_isReady)
			{
				Debug.LogError("Trying to show Ad which is not ready yet.");
				return;
			}

			gameObject.SetActive(true);
		}

		protected abstract void OnTextureLoaded(Texture2D texture);

		private static UniTask<Sprite> DownloadTexture(string textureURL)
		{
			return AdsWebHelper.GetImageFromURL(textureURL).AsUniTask();
		}
	}
}