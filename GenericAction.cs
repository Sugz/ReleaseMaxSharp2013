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

namespace MaxSharp
{
    /// <summary>
    /// Used for declaring action items. 
    /// </summary>
    public class GenericAction : Autodesk.Max.Plugins.ActionItem
    {
        string name;
        string category;
        string description;
        Action action;

        public GenericAction(string name, string category, string description, Action action)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.action = action;
        }

        public override string ButtonText
        {
            get { return name; }
        }

        public override string CategoryText
        {
            get { return category; }
        }

        public override string DescriptionText
        {
            get { return description; }
        }

        public override bool ExecuteAction()
        {
            action();
            return true;
        }

        public override Autodesk.Max.IMaxIcon Icon
        {
            get { return null; }
        }

        public override bool IsItemVisible
        {
            get { return true; }
        }

        public override string MenuText
        {
            get { return "&" + name; }
        }

#if MAX_2012
        public override int Id_
        {
            get { return 1; }
        }

        public override bool IsChecked_
        {
            get { return false; }
        }

        public override bool IsEnabled_
        {
            get { return true; }
        }
#else
        public override int Id
        {
            get { return 1; }
        }

        public override bool IsChecked
        {
            get { return false; }
        }

        public override bool IsEnabled
        {
            get { return true; }
        }
#endif
    }
}
