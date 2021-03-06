using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.GameplaySetup;
using UnityEngine;
using Zenject;
using Colour = UnityEngine.Color;

namespace MoreDifferentDots.UI
{
	public class DotTab : MonoBehaviour, IInitializable, IDisposable, INotifyPropertyChanged
	{
		private Config config;
		private GameplaySetupViewController gameplaySetupViewController;
		public event PropertyChangedEventHandler PropertyChanged = null!;

		[UIComponent("root")]
		private readonly RectTransform rootTransform = null!;

		[UIComponent("modal")]
		private readonly RectTransform modalTransform = null!;

		[UIValue("dots-enabled")]
		public bool DotsEnabled
        {
			get => config.DotsEnabled;
			set
			{
				config.DotsEnabled = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DotsEnabled)));
			}
		}

		[UIValue("dot-color")]
		public Colour DotColorValue
		{
			get => config.Color;
			set => config.Color = value;
		}

		[UIValue("dot-scale")]
		public float DotScaleValue
		{
			get => config.Scale;
			set
			{
				config.Scale = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DotScaleValue)));
			}
		}

		[UIValue("dot-distance")]
		public float DotDistanceValue
		{
			get => config.Distance;
			set
			{
				config.Distance = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DotDistanceValue)));
			}
		}

		[Inject]
		internal void Inject(Config _config, GameplaySetupViewController _gameplaySetupViewController)
		{
			config = _config;
			gameplaySetupViewController = _gameplaySetupViewController;
		}

		public void Initialize()
		{
			gameplaySetupViewController.didDeactivateEvent += YeetModalEvent;

			GameplaySetup.instance.AddTab("MoreDifferentDots", "MoreDifferentDots.UI.DotTab.bsml", this, MenuType.All);
		}

		public void Dispose()
		{
			GameplaySetup.instance?.RemoveTab("MoreDifferentDots");
			gameplaySetupViewController.didDeactivateEvent -= YeetModalEvent;
		}

		private void YeetModalEvent(bool removedFromHierarchy, bool screenSystemDisabling)
		{
			if (rootTransform != null && modalTransform != null)
			{
				modalTransform.SetParent(rootTransform);
				modalTransform.gameObject.SetActive(false);
			}
		}
	}
}
