﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace myWeb.th.ac.mju.ouop {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="verifyuserBinding", Namespace="nusoap")]
    public partial class verifyuser : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CallverifyuserOperationCompleted;
        
        private System.Threading.SendOrPostCallback verifyuserWDOperationCompleted;
        
        private System.Threading.SendOrPostCallback verifyuserNDOperationCompleted;
        
        private System.Threading.SendOrPostCallback authenUserCheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback debug_verifyuserNDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public verifyuser() {
            this.Url = global::myWeb.Properties.Settings.Default.myWeb_th_ac_mju_ouop_verifyuser;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CallverifyuserCompletedEventHandler CallverifyuserCompleted;
        
        /// <remarks/>
        public event verifyuserWDCompletedEventHandler verifyuserWDCompleted;
        
        /// <remarks/>
        public event verifyuserNDCompletedEventHandler verifyuserNDCompleted;
        
        /// <remarks/>
        public event authenUserCheckCompletedEventHandler authenUserCheckCompleted;
        
        /// <remarks/>
        public event debug_verifyuserNDCompletedEventHandler debug_verifyuserNDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ouop.mju.ac.th/ws.php/verifyuser", RequestNamespace="nusoap", ResponseNamespace="nusoap")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string Callverifyuser(string username, string password) {
            object[] results = this.Invoke("Callverifyuser", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CallverifyuserAsync(string username, string password) {
            this.CallverifyuserAsync(username, password, null);
        }
        
        /// <remarks/>
        public void CallverifyuserAsync(string username, string password, object userState) {
            if ((this.CallverifyuserOperationCompleted == null)) {
                this.CallverifyuserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallverifyuserOperationCompleted);
            }
            this.InvokeAsync("Callverifyuser", new object[] {
                        username,
                        password}, this.CallverifyuserOperationCompleted, userState);
        }
        
        private void OnCallverifyuserOperationCompleted(object arg) {
            if ((this.CallverifyuserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CallverifyuserCompleted(this, new CallverifyuserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ouop.mju.ac.th/ws.php/verifyuserWD", RequestNamespace="nusoap", ResponseNamespace="nusoap")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string verifyuserWD(string username, string password) {
            object[] results = this.Invoke("verifyuserWD", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void verifyuserWDAsync(string username, string password) {
            this.verifyuserWDAsync(username, password, null);
        }
        
        /// <remarks/>
        public void verifyuserWDAsync(string username, string password, object userState) {
            if ((this.verifyuserWDOperationCompleted == null)) {
                this.verifyuserWDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnverifyuserWDOperationCompleted);
            }
            this.InvokeAsync("verifyuserWD", new object[] {
                        username,
                        password}, this.verifyuserWDOperationCompleted, userState);
        }
        
        private void OnverifyuserWDOperationCompleted(object arg) {
            if ((this.verifyuserWDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verifyuserWDCompleted(this, new verifyuserWDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ouop.mju.ac.th/ws.php/verifyuserND", RequestNamespace="nusoap", ResponseNamespace="nusoap")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string verifyuserND(string username, string password) {
            object[] results = this.Invoke("verifyuserND", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void verifyuserNDAsync(string username, string password) {
            this.verifyuserNDAsync(username, password, null);
        }
        
        /// <remarks/>
        public void verifyuserNDAsync(string username, string password, object userState) {
            if ((this.verifyuserNDOperationCompleted == null)) {
                this.verifyuserNDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnverifyuserNDOperationCompleted);
            }
            this.InvokeAsync("verifyuserND", new object[] {
                        username,
                        password}, this.verifyuserNDOperationCompleted, userState);
        }
        
        private void OnverifyuserNDOperationCompleted(object arg) {
            if ((this.verifyuserNDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verifyuserNDCompleted(this, new verifyuserNDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ouop.mju.ac.th/ws.php/authenUserCheck", RequestNamespace="nusoap", ResponseNamespace="nusoap")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string authenUserCheck(string username, string password) {
            object[] results = this.Invoke("authenUserCheck", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void authenUserCheckAsync(string username, string password) {
            this.authenUserCheckAsync(username, password, null);
        }
        
        /// <remarks/>
        public void authenUserCheckAsync(string username, string password, object userState) {
            if ((this.authenUserCheckOperationCompleted == null)) {
                this.authenUserCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnauthenUserCheckOperationCompleted);
            }
            this.InvokeAsync("authenUserCheck", new object[] {
                        username,
                        password}, this.authenUserCheckOperationCompleted, userState);
        }
        
        private void OnauthenUserCheckOperationCompleted(object arg) {
            if ((this.authenUserCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.authenUserCheckCompleted(this, new authenUserCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ouop.mju.ac.th/ws.php/debug_verifyuserND", RequestNamespace="nusoap", ResponseNamespace="nusoap")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string debug_verifyuserND(string username, string password) {
            object[] results = this.Invoke("debug_verifyuserND", new object[] {
                        username,
                        password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void debug_verifyuserNDAsync(string username, string password) {
            this.debug_verifyuserNDAsync(username, password, null);
        }
        
        /// <remarks/>
        public void debug_verifyuserNDAsync(string username, string password, object userState) {
            if ((this.debug_verifyuserNDOperationCompleted == null)) {
                this.debug_verifyuserNDOperationCompleted = new System.Threading.SendOrPostCallback(this.Ondebug_verifyuserNDOperationCompleted);
            }
            this.InvokeAsync("debug_verifyuserND", new object[] {
                        username,
                        password}, this.debug_verifyuserNDOperationCompleted, userState);
        }
        
        private void Ondebug_verifyuserNDOperationCompleted(object arg) {
            if ((this.debug_verifyuserNDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.debug_verifyuserNDCompleted(this, new debug_verifyuserNDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CallverifyuserCompletedEventHandler(object sender, CallverifyuserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CallverifyuserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CallverifyuserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void verifyuserWDCompletedEventHandler(object sender, verifyuserWDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verifyuserWDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verifyuserWDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void verifyuserNDCompletedEventHandler(object sender, verifyuserNDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verifyuserNDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verifyuserNDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void authenUserCheckCompletedEventHandler(object sender, authenUserCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class authenUserCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal authenUserCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void debug_verifyuserNDCompletedEventHandler(object sender, debug_verifyuserNDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class debug_verifyuserNDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal debug_verifyuserNDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591