﻿using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class DetailedTimerFactory : IComponentFactory
    {
        public string ComponentName => "Detailed Timer (Decimal Time)";

        public string Description => "Displays the run timer, segment timer, and segment times for up to two comparisons (in the decimal time format).";

        public ComponentCategory Category => ComponentCategory.Timer;

        public IComponent Create(LiveSplitState state) => new DetailedTimer(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "http://livesplit.org/update/Components/update.LiveSplit.DetailedTimer.xml";

        public string UpdateURL => "http://livesplit.org/update/";

        public Version Version => Version.Parse("1.8.11");
    }
}
