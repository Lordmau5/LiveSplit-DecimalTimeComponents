using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class SplitsComponentFactory : IComponentFactory
    {
        public string ComponentName => "Subsplits (Decimal Time)";

        public string Description => "Displays a list of split times and deltas in relation to a comparison (in the decimal time format). Only shows subsplits when relevant";

        public ComponentCategory Category => ComponentCategory.List;

        public IComponent Create(LiveSplitState state) => new SplitsComponent(state);

        public string UpdateName => this.ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.8.12");
    }
}
