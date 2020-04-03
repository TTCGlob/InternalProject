using SeFramework.Constant.Framework;
using System;
using System.Configuration;

namespace SeFramework.Config
{
    public class ConfigReader
    {
        private string GetValue(string key) => ConfigurationManager.AppSettings.Get(key);

        public BrowserType Browser => (BrowserType)Enum.Parse(typeof(BrowserType), GetValue(General.Browser));
        public int ElementTimeout => int.Parse(GetValue(General.ElementLoadTimeOut));
        public int PageLoadTimeout => int.Parse(GetValue(General.PageLoadTimeOut));
        public string Url => GetValue(General.Website);
        public string Username => GetValue(General.Username);
        public string Password => GetValue(General.Password);
        public bool Headless => bool.Parse(GetValue(General.Headless));
    }
}
