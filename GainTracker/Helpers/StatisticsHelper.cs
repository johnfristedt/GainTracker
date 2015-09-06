using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Helpers
{
    public class StatisticsHelper
    {
        public enum StatisticTypes
        {
            Visitor,
            UniqueVisitor,
            Register,
            Login,
            AddedCat,
            AddedData
        };
    }
}