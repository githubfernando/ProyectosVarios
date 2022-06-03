using IQCleanRepositoryUtils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryUtils
{
    public class PPLProcedure : IProcedure
    {
        public const string spCleanCheckRangeDate = "spClean_CheckRangeDate";
        public const string spCleanCheckInBizagi = "spClean_CheckProcessedRad";
        public const string spCleanListImages = "spClean_ListImages";
        public PPLProcedure()
        {
            PPLProcedure ppl = new PPLProcedure();
        }
    }
}
