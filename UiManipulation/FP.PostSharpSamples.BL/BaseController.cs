﻿using System;

namespace FP.PostSharpSamples.BL
{
    public abstract class BaseController
    {
        public virtual void InitDataSource()
        {
            var handler = DataSourceInitialized;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler DataSourceInitialized;

        public Guid ObjectId { get; set; }
    }
}
