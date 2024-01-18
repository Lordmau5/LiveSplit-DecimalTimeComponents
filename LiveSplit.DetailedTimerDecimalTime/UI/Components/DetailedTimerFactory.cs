using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class DetailedTimerFactory : IComponentFactory
    {
        public string ComponentName => "Detailed Timer (Decimal Time)";

        public string Description => "Displays the run timer, segment timer, and segment times for up to two comparisons (in the decimal time format).";

        public ComponentCategory Category => ComponentCategory.Timer;

        public IComponent Create(LiveSplitState state) => new DetailedTimer(state);

        public string UpdateName => this.ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.8.12");
    }
}
