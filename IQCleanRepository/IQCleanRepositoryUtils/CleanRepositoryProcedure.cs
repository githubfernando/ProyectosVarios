using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryUtils
{
    public static class CleanRepositoryProcedure
    {
        public const string spGetProjects = "SPGetProjects";
        public const string spGetRepository = "SPGetRepository";
        public const string spSaveImageList = "spSaveConsultImageList";
        public const string spSaveImageListBlob = "spSaveConsultImageList_Blob";
        public const string spSaveImageCleanUp = "spSaveRepositoryCleanUp";
        public const string spGetImagesPending = "spGetImagesPendingCleanUp";
        public const string spCrossFileWithData = "spCrossFileWithData";
        public const string spGetFilesToCleanUp = "spGetFilesToCleanUp";
    }
}
