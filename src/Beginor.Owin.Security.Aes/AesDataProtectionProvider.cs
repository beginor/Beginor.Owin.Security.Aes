﻿using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginor.Owin.Security.Aes {

    public class AesDataProtectionProvider : IDataProtectionProvider {

        private string appName;

        public AesDataProtectionProvider() : this(Guid.NewGuid().ToString()) {
        }

        public AesDataProtectionProvider(string appName) {
            if (appName == null) {
                throw new ArgumentNullException("appName");
            }
            this.appName = appName;
        }

        public IDataProtector Create(params string[] purposes) {
            return new AesDataProtector(appName + ":" + string.Join(",", purposes));
        }
    }
}