﻿// <copyright file="WelcomeTeamCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.RemoteSupport.Cards
{
    using Microsoft.Teams.Apps.RemoteSupport.Common;
    using Microsoft.Teams.Apps.RemoteSupport.Models;

    /// <summary>
    ///  This class process Welcome Card when installed in Team scope.
    /// </summary>
    public static class WelcomeTeamCard
    {
        /// <summary>
        /// This method will construct the user welcome card when bot is added in team scope.
        /// </summary>
        /// <param name="applicationBasePath">Application base URL.</param>
        /// <param name="localizer">The current cultures' string localizer.</param>
        /// <returns>User welcome card.</returns>
        public static Attachment GetCard(string applicationBasePath, IStringLocalizer<Strings> localizer)
        {
            AdaptiveCard card = new AdaptiveCard(new AdaptiveSchemaVersion(Constants.AdaptiveCardVersion))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveColumnSet
                    {
                        Columns = new List<AdaptiveColumn>
                        {
                            new AdaptiveColumn
                            {
                                Width = "1",
                                Items = new List<AdaptiveElement>
                                {
                                    new AdaptiveImage
                                    {
                                        Url = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}/Artifacts/AppIcon.png", applicationBasePath?.Trim('/'))),
                                        Size = AdaptiveImageSize.Large,
                                    },
                                },
                            },
                            new AdaptiveColumn
                            {
                                Width = "5",
                                Items = new List<AdaptiveElement>
                                {
                                    new AdaptiveTextBlock
                                    {
                                        Text = localizer.GetString("WelcomeCardTitle"),
                                        Weight = AdaptiveTextWeight.Bolder,
                                        Size = AdaptiveTextSize.Large,
                                    },
                                    new AdaptiveTextBlock
                                    {
                                        Text = localizer.GetString("WelcomeTeamCardContent"),
                                        Wrap = true,
                                        Spacing = AdaptiveSpacing.None,
                                    },
                                },
                            },
                        },
                    },
                    new AdaptiveTextBlock
                    {
                        HorizontalAlignment = AdaptiveHorizontalAlignment.Left,
                        Text = localizer.GetString("WelcomeSubHeaderText"),
                        Spacing = AdaptiveSpacing.Small,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("TeamRequestBulletPoint"),
                        Spacing = AdaptiveSpacing.None,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("ExperListBulletPoint"),
                        Spacing = AdaptiveSpacing.None,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = localizer.GetString("ContentText"),
                        Spacing = AdaptiveSpacing.Small,
                    },
                },
                Actions = new List<AdaptiveAction>
                {
                    new AdaptiveSubmitAction
                    {
                        Title = localizer.GetString("ExpertListTitle"),
                        Data = new AdaptiveCardAction
                        {
                            MsteamsCardAction = new CardAction
                            {
                                Type = Constants.MessageBackActionType,
                                Text = Constants.ManageExpertsAction,
                            },
                        },
                    },
                },
            };
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card,
            };
        }
    }
}
