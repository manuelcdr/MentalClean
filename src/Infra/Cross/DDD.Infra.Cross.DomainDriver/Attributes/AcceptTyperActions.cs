using System;

namespace DDD.Infra.Cross.DomainDriver.Attributes
{
    public class AcceptDriverActionsAttribute : Attribute
    {
        public DriverAction Actions { get; private set; }

        public AcceptDriverActionsAttribute(bool none = false)
        {
            if (none)
            {
                Actions |= DriverAction.None;
            }
            else
            {
                foreach (var action in Enum.GetValues(typeof(DriverAction)))
                {
                    if (action.Equals(DriverAction.None))
                        continue;

                    Actions |= (DriverAction)action;
                }
            }
        }

        public AcceptDriverActionsAttribute(params DriverAction[] actions)
        {
            foreach (var action in actions)
            {
                Actions |= action;
            }
        }
    }

    [Flags]
    public enum DriverAction
    {
        None = 0,
        GetSingle = 1,
        GetAll = 2,
        Insert = 4,
        Update = 8,
        Delete = 16,
        Activate = 32,
        Deactivate = 64,
        GetActives = 128
    }
}
