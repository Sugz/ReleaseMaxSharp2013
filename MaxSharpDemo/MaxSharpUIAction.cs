//
// Copyright 2012 Autodesk, Inc.  All rights reserved.
//
// Use of this software is subject to the terms of the Autodesk license
// agreement provided at the time of installation or download, or which
// otherwise accompanies this software in either electronic or hard copy form.  
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UiViewModels.Actions;
using MaxSharp;

namespace MaxSharpDemo
{
    public class MaxSharpUIAction : CuiActionCommandAdapter
    {
        public static FormWithEditor form;

        public override string ActionText
        {
            get { return "MaxSharp UI action"; }
        }

        public override string Category
        {
            get { return "MaxSharp demo"; }
        }

        public override void Execute(object parameter)
        {
            if (form == null)
                form = new FormWithEditor();
            form.Show();
        }

        public override string InternalActionText
        {
            get { return ActionText; }
        }

        public override string InternalCategory
        {
            get { return Category; }
        }
    }
}
