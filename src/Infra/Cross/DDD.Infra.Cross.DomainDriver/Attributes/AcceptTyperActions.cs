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
        None        = 0,
        GetSingle   = 1 << 0,
        GetAll      = 1 << 1,
        Insert      = 1 << 2,
        Update      = 1 << 3,
        Delete      = 1 << 4,
        Activate    = 1 << 5,
        Deactivate  = 1 << 6,
        GetActives  = 1 << 7
    }
}
