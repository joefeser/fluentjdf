﻿using FluentJdf.Configuration;
using Machine.Specifications;

namespace FluentJdf.Tests {
    public class AssemblyContext : IAssemblyContext, ICleanupAfterEveryContextInAssembly {
        #region IAssemblyContext Members

        public void OnAssemblyStart() {
            Bootstrapper.Initialize();
        }

        public void OnAssemblyComplete() {}

        #endregion

        public void AfterContextCleanup() {
            Library.Settings.ResetToDefaults();
        }
    }
}