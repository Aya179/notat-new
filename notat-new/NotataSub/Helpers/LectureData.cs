using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotataSub.Helpers
{
    public class LectureData
    {
        public string PageFileName { set; get; }
        public int PageNum { set; get; }

        public byte[] PageDate { set; get; }
        public LectureData(int pageNum, string pageFileName, byte[] pageDate)
        {
            this.PageNum = pageNum;
            this.PageFileName = pageFileName;
            this.PageDate = pageDate;
        }

    }
}
