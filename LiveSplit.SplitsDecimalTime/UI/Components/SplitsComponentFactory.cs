﻿using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class SplitsComponentFactory : IComponentFactory
    {
        public string ComponentName => "Splits (Decimal Timing)";

        public string Description => "Displays a list of split times and deltas in relation to a comparison (in the decimal time format).";

        public ComponentCategory Category => ComponentCategory.List;

        public IComponent Create(LiveSplitState state) => new SplitsComponent(state);

        public string UpdateName => ComponentName;

        //public string XMLURL => "http://livesplit.org/update/Components/update.LiveSplit.Splits.xml";
        public string XMLURL => "";

        public string UpdateURL => "http://livesplit.org/update/";

        public Version Version => Version.Parse("1.8.19");
    }
}
