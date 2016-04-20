﻿using System;
using System.Collections.Generic;

namespace GameEditor.Extensions
{
    public static class EnumerableExtension
    {
        public static void Apply<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable) action(item);
        }
    }
}
