﻿//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/MyToolkit/MyToolkit/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using MyToolkit.Messaging;
using MyToolkit.Paging;
using MyToolkit.Paging.Animations;
using SampleWindowsStoreApp.Views;

namespace SampleWindowsStoreApp
{
    sealed partial class App : MtApplication
    {
        public App()
        {
            InitializeComponent();
        }

        public override Type StartPageType
        {
            get { return typeof(WelcomePage); }
        }

        public override Task OnInitializedAsync(MtFrame frame, ApplicationExecutionState args)
        {
            // TODO: Called when the app is started (not resumed)

            //frame.PageAnimation = new TurnstilePageAnimation { UseBitmapCacheMode = true };
            //frame.PageAnimation = new PushPageAnimation();

            var mapper = RegexViewModelToViewMapper.CreateDefaultMapper(typeof(App).GetTypeInfo().Assembly);
            Messenger.Default.Register(DefaultActions.GetNavigateMessageAction(mapper, frame));

            return null;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            await InitializeFrameAsync(args.PreviousExecutionState);

            // TODO: Remove these calls if not used
            ToastAndTilesPage.HandleSecondaryTileClick(args);
        }

        #region Search Contract

        protected override async void OnSearchActivated(SearchActivatedEventArgs args)
        {
            // TODO: Add "Search" in the "Declarations" section of Package.appxmanifest
            await InitializeFrameAsync(args.PreviousExecutionState);

            // TODO: Implement this directly in App.xaml.cs
            SearchSamplePage.OnSearchActivated(args);
        }

        #endregion

        #region File Extension

        protected override async void OnFileActivated(FileActivatedEventArgs args)
        {
            await InitializeFrameAsync(args.PreviousExecutionState);

            // TODO: Implement this directly in App.xaml.cs
            FilePickerPage.OnFileActivated(args);
        }

        #endregion

        #region Share Target

        protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
        {
            await InitializeFrameAsync(args.PreviousExecutionState);

            // TODO: Implement this directly in App.xaml.cs
            ShareTargetPage.OnShareTargetActivated(args);
        }

        #endregion
    }
}
