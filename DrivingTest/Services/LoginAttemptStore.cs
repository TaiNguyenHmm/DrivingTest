using System;
using System.Collections.Concurrent;

namespace DrivingTest.Services
{
    public class AttemptInfo
    {
        public int Count { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }

    public static class LoginAttemptStore
    {
        private static readonly ConcurrentDictionary<string, AttemptInfo> _store = new(StringComparer.OrdinalIgnoreCase);

        // Record a failed attempt; returns info about current state
        public static (int count, bool isLocked, DateTime? lockoutEnd) RecordFailedAttempt(string key, int maxAttempts = 5, int lockoutMinutes = 10)
        {
            var info = _store.GetOrAdd(key, _ => new AttemptInfo());
            if (info.LockoutEnd.HasValue && info.LockoutEnd.Value > DateTime.UtcNow)
            {
                return (info.Count, true, info.LockoutEnd);
            }

            info.Count++;
            if (info.Count >= maxAttempts)
            {
                info.LockoutEnd = DateTime.UtcNow.AddMinutes(lockoutMinutes);
                info.Count = 0; // reset count after lockout
                _store[key] = info;
                return (info.Count, true, info.LockoutEnd);
            }

            _store[key] = info;
            return (info.Count, false, info.LockoutEnd);
        }

        public static bool IsLocked(string key, out DateTime? lockoutEnd)
        {
            lockoutEnd = null;
            if (_store.TryGetValue(key, out var info))
            {
                if (info.LockoutEnd.HasValue && info.LockoutEnd.Value > DateTime.UtcNow)
                {
                    lockoutEnd = info.LockoutEnd;
                    return true;
                }

                // if lockout expired, clear it
                if (info.LockoutEnd.HasValue && info.LockoutEnd.Value <= DateTime.UtcNow)
                {
                    _store.TryRemove(key, out _);
                    return false;
                }
            }
            return false;
        }

        public static void Reset(string key)
        {
            _store.TryRemove(key, out _);
        }
    }
}
