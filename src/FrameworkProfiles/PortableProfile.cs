﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkProfiles
{
    public sealed class PortableProfile : FrameworkProfile
    {
        public PortableProfile()
        {
            SupportedFrameworks = new List<FrameworkProfile>();
        }

        public override bool SupportedByVisualStudio2013
        {
            get { return SupportedFrameworks.All(x => x.SupportedByVisualStudio2013); }

            set { throw new InvalidOperationException(); }
        }

        public override bool SupportsAsync
        {
            get { return SupportedFrameworks.All(x => x.SupportsAsync); }
        }

        public override bool SupportsGenericVariance
        {
            get { return SupportedFrameworks.All(x => x.SupportsGenericVariance); }
        }

        public override string NugetTarget
        {
            get
            {
                if (SupportedFrameworks.Any(x => x.NugetTarget == string.Empty))
                    return string.Empty;
                return "portable-" + string.Join("+", SupportedFrameworks.Select(x => x.NugetTarget));
            }
        }

        public List<FrameworkProfile> SupportedFrameworks { get; private set; }
    }
}