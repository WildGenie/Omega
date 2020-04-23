﻿
using System.ComponentModel;

namespace Omega.Ots.Common.Enums
{
    public enum GruplamaTuru : byte
    {
        [Description("Giriş Tarihine Göre")]
        GirisTarihineGore = 1,
        [Description("Vadeye Göre")]
        VadeyeGore = 2,
        [Description("Hesaba Geçiş Tarihine Göre")]
        HesabaGecisTarihineGore = 3
    }
}
