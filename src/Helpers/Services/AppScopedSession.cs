using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Netopes.Core.Helpers.Services
{
    public class AppScopedSession
    {
        protected ConcurrentDictionary<string, string?> _sessionStringData = new();
        protected ConcurrentDictionary<string, object?> _sessionObjectsData = new();
        
        public bool IsInitialized { get; protected set; }
        
        public virtual async Task InitializeAsync()
        {
            if (!IsInitialized)
            {
                await LoadStateAsync();
            }
        }
        
        public virtual async Task LoadStateAsync()
        {
            IsInitialized = true;
            await Task.CompletedTask;
        }

        public string? this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException("Null or empty key.");
                }
                return _sessionStringData.ContainsKey(key) ? _sessionStringData[key] : null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException("Null or empty key.");
                }
                _sessionStringData[key] = value;
            }
        }

        public string? GetValue(string key, string? defaultValue = null) => this[key] ?? defaultValue;

        public T? GetValue<T>(string key, T? defaultValue = default) => this[key] == null ? defaultValue : JsonSerializer.Deserialize<T>(this[key] ?? string.Empty);

        public void SetValue(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Null or empty key.");
            }
            var stringValue = value == null ? null : JsonSerializer.Serialize(value);
            _sessionStringData[key] = stringValue;
        }

        public void RemoveValue(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Null or empty key.");
            }

            if (_sessionStringData.ContainsKey(key))
            {
                return;
            }
            
            if (!_sessionStringData.TryRemove(new KeyValuePair<string, string?>(key, _sessionStringData[key])))
            {
                _sessionStringData[key] = null;
            }
        }

        public object? GetObjectValue(string key, object? defaultValue = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Null or empty key.");
            }
        
            if (!_sessionObjectsData.ContainsKey(key) || _sessionObjectsData[key] == null)
            {
                return defaultValue;
            }
        
            return _sessionObjectsData[key];
        }
        
        public void SetObjectValue(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Null or empty key.");
            }
            _sessionObjectsData[key] = value;
        }

        public void RemoveObjectValue(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Null or empty key.");
            }

            if (!_sessionObjectsData.ContainsKey(key))
            {
                return;
            }

            if (!_sessionObjectsData.TryRemove(new KeyValuePair<string, object?>(key, _sessionObjectsData[key])))
            {
                _sessionObjectsData[key] = null;
            }
        }
    }
}