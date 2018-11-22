using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimMaker_v2
{
    internal interface Finishable
    {
        #region Public Properties

        bool Finished { get; set; }

        #endregion Public Properties
    }
}