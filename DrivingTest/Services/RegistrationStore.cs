using System;
using System.Collections.Concurrent;

namespace DrivingTest.Services
{
    public class PendingRegistration
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }

    public static class RegistrationStore
    {
        private static readonly ConcurrentDictionary<string, PendingRegistration> _store = new();

        public static string Add(PendingRegistration reg)
        {
            var token = Guid.NewGuid().ToString();
            reg.ExpiresAt = DateTime.UtcNow.AddHours(1);
            _store[token] = reg;
            return token;
        }

        public static bool TryRemove(string token, out PendingRegistration? reg)
        {
            reg = null;
            if (string.IsNullOrEmpty(token)) return false;
            if (_store.TryRemove(token, out var r))
            {
                if (r.ExpiresAt < DateTime.UtcNow) return false;
                reg = r;
                return true;
            }
            return false;
        }

        public static bool Exists(string token)
        {
            return _store.ContainsKey(token);
        }
    }
}
