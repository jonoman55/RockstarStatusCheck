using RockstarStatusCheck.Classes;
using RockstarStatusCheck.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockstarStatusCheck.Handlers
{
    public class EnumHandler
    {
        public static IEnumerable<T> GetValues<T>() => Enum.GetValues(typeof(T)).Cast<T>();

        public static IEnumerable<(string check, IEnumerable<ServicesPayload> statuses)> ForEachAll() =>
            from check in GetValues<StatusType>().Select(t => t.ToString())
            let statuses = StatusHandler.GetStatuses(check.ToLower())
            select (check, statuses);

        #region ForEachType - Deprecated
        //public static IEnumerable<(string check, IEnumerable<ServicesPayload> statuses)> ForEachType() =>
        //    from check in GetValues<StatusType>().Select(t => t.ToString())
        //    let statuses = StatusHandler.ServicesStatuses
        //    select (check, statuses);
        #endregion

        public static IEnumerable<(string check, IEnumerable<StatusesPayload> statuses)> ForEachPlatform() =>
            from check in GetValues<PlaformsType>().Select(t => t.ToString())
            let statuses = StatusHandler.PlatformStatuses
            select (check, statuses);
    }
}
