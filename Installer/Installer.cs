using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;

namespace Installer
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }
        
        public override void Install(IDictionary stateSaver)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\UWF\\Blackjack";
            FileSystemAccessRule rule = new FileSystemAccessRule((IdentityReference)new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, (SecurityIdentifier)null), FileSystemRights.Write, AccessControlType.Allow);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DirectorySecurity accessControl = Directory.GetAccessControl(path);
            accessControl.AddAccessRule(rule);
            Directory.SetAccessControl(path, accessControl);
            base.Install(stateSaver);
        }
        
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
        
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}

