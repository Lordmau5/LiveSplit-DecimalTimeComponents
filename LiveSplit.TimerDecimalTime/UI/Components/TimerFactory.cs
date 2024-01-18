using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class TimerFactory : IComponentFactory
    {
        public string ComponentName => "Timer (Decimal Time)";

        public string Description => "Displays the current run time (in the decimal time format).";

        public ComponentCategory Category => ComponentCategory.Timer;

        public IComponent Create(LiveSplitState state) => new Timer();

        public string UpdateName => this.ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.8.1");
    }
}
