﻿using Omega.Ots.Bll.Base;
using Omega.Ots.Bll.Interfaces;
using Omega.Ots.Common.Enums;
using Omega.Ots.Data.Context;
using Omega.Ots.Model.Entities;
using Omega.Ots.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Omega.Ots.Bll.General
{
    public class FiltreBll : BaseGenelBll<Filtre>, IBaseCommonBll
    {
        public FiltreBll() : base(KartTuru.Filtre) { }
        public FiltreBll(Control ctrl) : base(ctrl, KartTuru.Filtre) { }

    }
}