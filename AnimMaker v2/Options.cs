using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimMaker_v2
{
    [Serializable]
    public class Options
    {
        public string AutoFilePath;
        public bool AutoFileSave;
        public TimeSpan AutoFileTime;
        public static Options Default
        {
            get
            {
                var tmp = new Options();
                if (!System.IO.Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnimMakerV2/autosaves")))
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnimMakerV2/autosaves"));
                tmp.AutoFilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnimMakerV2/autosaves");
                tmp.AutoFileSave = true;
                tmp.AutoFileTime = TimeSpan.FromMinutes(5);
                return tmp;
            }
        }
    }
}
