using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeTempDataDictionary : Dictionary<string, object?>, ITempDataDictionary
{
    public new object? this[string key]
    {
        get => TryGetValue(key, out var value) ? value : null;
        set => base[key] = value;
    }

    public void Keep()
    {
    }

    public void Keep(string key)
    {
    }

    public void Load()
    {
    }

    public object? Peek(string key) => this[key];

    public void Save()
    {
    }
}
