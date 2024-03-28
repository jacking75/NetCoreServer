using System;
using System.Text;

namespace NetCoreServer;

/// <summary>
/// Conversion metrics utilities
/// </summary>
public class Utilities
{
    /// <summary>
    /// 데이터 크기 문자열 생성. 주어진 바이트에 따라 바이트, KiB, MiB, GiB, TiB의 예쁜 문자열을 반환합니다.
    /// </summary>
    /// <param name="b">바이트 단위의 데이터 크기</param>
    /// <returns>데이터 크기 표현의 문자열</returns>
    public static string GenerateDataSize(double b)
    {
        var sb = new StringBuilder();

        long bytes = (long)b;
        long absBytes = Math.Abs(bytes);

        if (absBytes >= (1024L * 1024L * 1024L * 1024L))
        {
            long tb = bytes / (1024L * 1024L * 1024L * 1024L);
            long gb = (bytes % (1024L * 1024L * 1024L * 1024L)) / (1024 * 1024 * 1024);
            sb.Append(tb);
            sb.Append('.');
            sb.Append((gb < 100) ? "0" : "");
            sb.Append((gb < 10) ? "0" : "");
            sb.Append(gb);
            sb.Append(" TiB");
        }
        else if (absBytes >= (1024 * 1024 * 1024))
        {
            long gb = bytes / (1024 * 1024 * 1024);
            long mb = (bytes % (1024 * 1024 * 1024)) / (1024 * 1024);
            sb.Append(gb);
            sb.Append('.');
            sb.Append((mb < 100) ? "0" : "");
            sb.Append((mb < 10) ? "0" : "");
            sb.Append(mb);
            sb.Append(" GiB");
        }
        else if (absBytes >= (1024 * 1024))
        {
            long mb = bytes / (1024 * 1024);
            long kb = (bytes % (1024 * 1024)) / 1024;
            sb.Append(mb);
            sb.Append('.');
            sb.Append((kb < 100) ? "0" : "");
            sb.Append((kb < 10) ? "0" : "");
            sb.Append(kb);
            sb.Append(" MiB");
        }
        else if (absBytes >= 1024)
        {
            long kb = bytes / 1024;
            bytes = bytes % 1024;
            sb.Append(kb);
            sb.Append('.');
            sb.Append((bytes < 100) ? "0" : "");
            sb.Append((bytes < 10) ? "0" : "");
            sb.Append(bytes);
            sb.Append(" KiB");
        }
        else
        {
            sb.Append(bytes);
            sb.Append(" bytes");
        }

        return sb.ToString();
    }

    /// <summary>
    /// 기간 문자열을 생성합니다. 주어진 나노초를 기준으로 ns, mcs, ms, s, m, h의 예쁜 문자열을 반환합니다.
    /// </summary>
    /// <param name="ms">Milliseconds</param>
    /// <returns>String with time period representation</returns>
    public static string GenerateTimePeriod(double ms)
    {
        var sb = new StringBuilder();

        long nanoseconds = (long) (ms * 1000.0 * 1000.0);
        long absNanoseconds = Math.Abs(nanoseconds);

        if (absNanoseconds >= (60 * 60 * 1000000000L))
        {
            long hours = nanoseconds / (60 * 60 * 1000000000L);
            long minutes = ((nanoseconds % (60 * 60 * 1000000000L)) / 1000000000) / 60;
            long seconds = ((nanoseconds % (60 * 60 * 1000000000L)) / 1000000000) % 60;
            long milliseconds = ((nanoseconds % (60 * 60 * 1000000000L)) % 1000000000) / 1000000;
            sb.Append(hours);
            sb.Append(':');
            sb.Append((minutes < 10) ? "0" : "");
            sb.Append(minutes);
            sb.Append(':');
            sb.Append((seconds < 10) ? "0" : "");
            sb.Append(seconds);
            sb.Append('.');
            sb.Append((milliseconds < 100) ? "0" : "");
            sb.Append((milliseconds < 10) ? "0" : "");
            sb.Append(milliseconds);
            sb.Append(" h");
        }
        else if (absNanoseconds >= (60 * 1000000000L))
        {
            long minutes = nanoseconds / (60 * 1000000000L);
            long seconds = (nanoseconds % (60 * 1000000000L)) / 1000000000;
            long milliseconds = ((nanoseconds % (60 * 1000000000L)) % 1000000000) / 1000000;
            sb.Append(minutes);
            sb.Append(':');
            sb.Append((seconds < 10) ? "0" : "");
            sb.Append(seconds);
            sb.Append('.');
            sb.Append((milliseconds < 100) ? "0" : "");
            sb.Append((milliseconds < 10) ? "0" : "");
            sb.Append(milliseconds);
            sb.Append(" m");
        }
        else if (absNanoseconds >= 1000000000)
        {
            long seconds = nanoseconds / 1000000000;
            long milliseconds = (nanoseconds % 1000000000) / 1000000;
            sb.Append(seconds);
            sb.Append('.');
            sb.Append((milliseconds < 100) ? "0" : "");
            sb.Append((milliseconds < 10) ? "0" : "");
            sb.Append(milliseconds);
            sb.Append(" s");
        }
        else if (absNanoseconds >= 1000000)
        {
            long milliseconds = nanoseconds / 1000000;
            long microseconds = (nanoseconds % 1000000) / 1000;
            sb.Append(milliseconds);
            sb.Append('.');
            sb.Append((microseconds < 100) ? "0" : "");
            sb.Append((microseconds < 10) ? "0" : "");
            sb.Append(microseconds);
            sb.Append(" ms");
        }
        else if (absNanoseconds >= 1000)
        {
            long microseconds = nanoseconds / 1000;
            nanoseconds = nanoseconds % 1000;
            sb.Append(microseconds);
            sb.Append('.');
            sb.Append((nanoseconds < 100) ? "0" : "");
            sb.Append((nanoseconds < 10) ? "0" : "");
            sb.Append(nanoseconds);
            sb.Append(" mcs");
        }
        else
        {
            sb.Append(nanoseconds);
            sb.Append(" ns");
        }

        return sb.ToString();
    }
}
