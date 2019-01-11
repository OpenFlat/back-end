using System;

namespace OpenFlat.API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int TokenExpireMinute { get; set; }
    }
}
