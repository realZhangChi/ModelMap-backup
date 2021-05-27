using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ModelMap.Desktop.Services.Setting
{
    public class SettingService : ISettingService, ITransientDependency
    {
        private const string AccessTokenKey = "AccessToken";
        private readonly string AccessTokenDefault = string.Empty;
        private const string RefreshTokenKey = "RefreshToken";
        private readonly string RefreshTokenDefault = string.Empty;
        private const string IdentityTokenKey = "IdentityToken";
        private readonly string IdentityTokenDefault = string.Empty;
        private const string ExpiresInKey = "ExpiresIn";
        private readonly int ExpiresInDefault = 0;

        public string AccessToken
        {
            get => GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            set => AddOrUpdateValue(AccessTokenKey, value);
        }

        public string RefreshToken
        {
            get => GetValueOrDefault(RefreshTokenKey, RefreshTokenDefault);
            set => AddOrUpdateValue(RefreshTokenKey, value);
        }

        public string IdentityToken
        {
            get => GetValueOrDefault(IdentityTokenKey, IdentityTokenDefault);
            set => AddOrUpdateValue(IdentityTokenKey, value);
        }

        public int ExpiresIn
        {
            get => GetValueOrDefault(ExpiresInKey, ExpiresInDefault);
            set => AddOrUpdateValue(ExpiresInKey, value);
        }

        #region Public Methods

        public Task AddOrUpdateValue(string key, bool value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, string value) => AddOrUpdateValueInternal(key, value);
        public Task AddOrUpdateValue(string key, int value) => AddOrUpdateValueInternal(key, value);
        public bool GetValueOrDefault(string key, bool defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public string GetValueOrDefault(string key, string defaultValue) => GetValueOrDefaultInternal(key, defaultValue);
        public int GetValueOrDefault(string key, int defaultValue) => GetValueOrDefaultInternal(key, defaultValue);

        #endregion

        #region Internal Implementation

        async Task AddOrUpdateValueInternal<T>(string key, T value)
        {
            if (value == null)
            {
                await Remove(key);
            }

            Application.Current.Properties[key] = value;
            try
            {
                await Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
            }
        }

        T GetValueOrDefaultInternal<T>(string key, T defaultValue = default(T))
        {
            object value = null;
            if (Application.Current.Properties.ContainsKey(key))
            {
                value = Application.Current.Properties[key];
            }
            return null != value ? (T)value : defaultValue;
        }

        async Task Remove(string key)
        {
            try
            {
                if (Application.Current.Properties[key] != null)
                {
                    Application.Current.Properties.Remove(key);
                    await Application.Current.SavePropertiesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove: " + key, " Message: " + ex.Message);
            }
        }

        #endregion
    }
}
