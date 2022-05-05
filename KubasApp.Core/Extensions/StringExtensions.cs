using System.Text;

namespace KubasApp.Core.Extensions;

public static class StringExtensions
{
    public static byte[] ToByteArray(this string text)
    {
        return Encoding.UTF8.GetBytes(text);
    }
}