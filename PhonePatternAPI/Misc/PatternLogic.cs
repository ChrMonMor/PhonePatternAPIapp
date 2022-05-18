namespace PhonePatternAPI.Misc
{
    public class PatternLogic
    {
        public static List<byte[]> ByteList()
        {
            try
            {
                List<byte[]> bytes = new List<byte[]>();
                for (byte a = 1; a < 10; a++)
                {
                    for (byte b = 1; b < 10; b++)
                    {
                        if (b == a)
                        {
                            continue;
                        }
                        for (byte c = 1; c < 10; c++)
                        {
                            if (c == a || c == b)
                            {
                                continue;
                            }
                            for (byte d = 1; d < 10; d++)
                            {
                                if (d == a || d == b || d == c)
                                {
                                    continue;
                                }
                                for (byte e = 1; e < 10; e++)
                                {
                                    if (e == a || e == b || e == c || e == d)
                                    {
                                        continue;
                                    }
                                    for (byte f = 1; f < 10; f++)
                                    {
                                        if (f == a || f == b || f == c || f == d || f == e)
                                        {
                                            continue;
                                        }
                                        for (byte g = 1; g < 10; g++)
                                        {
                                            if (g == a || g == b || g == c || g == d || g == e || g == f)
                                            {
                                                continue;
                                            }
                                            for (byte h = 1; h < 10; h++)
                                            {
                                                if (h == a || h == b || h == c || h == d || h == e || h == f || h == g)
                                                {
                                                    continue;
                                                }
                                                for (byte i = 1; i < 10; i++)
                                                {
                                                    if (i != a && i != b && i != c && i != d && i != e && i != f && i != g && i != h)
                                                    {
                                                        bytes.Add(new byte[] { a, b, c, d, e, f, g, h, i });
                                                    }
                                                }
                                                if (h != a && h != b && h != c && h != d && h != e && h != f && h != g)
                                                {
                                                    bytes.Add(new byte[] { a, b, c, d, e, f, g, h });
                                                }
                                            }
                                            if (g != a && g != b && g != c && g != d && g != e && g != f)
                                            {
                                                bytes.Add(new byte[] { a, b, c, d, e, f, g });
                                            }
                                        }
                                        if (f != a && f != b && f != c && f != d && f != e)
                                        {
                                            bytes.Add(new byte[] { a, b, c, d, e, f });
                                        }
                                    }
                                    if (e != a && e != b && e != c && e != d)
                                    {
                                        bytes.Add(new byte[] { a, b, c, d, e });
                                    }
                                }
                                if (d != a && d != b && d != c)
                                {
                                    bytes.Add(new byte[] { a, b, c, d });
                                }
                            }
                        }
                    }
                }
                return bytes.OrderBy(x => x.Length).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void TxtLogik()
        {
            try
            {
                using (StreamWriter w = File.AppendText(@"C:\Users\chri615w\Desktop\PhonePattern\PhonePatternAPIapp\PhonePatternAPI\TextFile.txt"))
                {
                    for (byte a = 1; a < 10; a++)
                    {
                        for (byte b = 1; b < 10; b++)
                        {
                            if (b == a)
                            {
                                continue;
                            }
                            for (byte c = 1; c < 10; c++)
                            {
                                if (c == a || c == b)
                                {
                                    continue;
                                }
                                for (byte d = 1; d < 10; d++)
                                {
                                    if (d == a || d == b || d == c)
                                    {
                                        continue;
                                    }
                                    for (byte e = 1; e < 10; e++)
                                    {
                                        if (e == a || e == b || e == c || e == d)
                                        {
                                            continue;
                                        }
                                        for (byte f = 1; f < 10; f++)
                                        {
                                            if (f == a || f == b || f == c || f == d || f == e)
                                            {
                                                continue;
                                            }
                                            for (byte g = 1; g < 10; g++)
                                            {
                                                if (g == a || g == b || g == c || g == d || g == e || g == f)
                                                {
                                                    continue;
                                                }
                                                for (byte h = 1; h < 10; h++)
                                                {
                                                    if (h == a || h == b || h == c || h == d || h == e || h == f || h == g)
                                                    {
                                                        continue;
                                                    }
                                                    for (byte i = 1; i < 10; i++)
                                                    {
                                                        if (i != a && i != b && i != c && i != d && i != e && i != f && i != g && i != h)
                                                        {
                                                            w.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", a, b, c, d, e, f, g, h, i);
                                                        }
                                                    }
                                                    if (h != a && h != b && h != c && h != d && h != e && h != f && h != g)
                                                    {
                                                        w.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}", a, b, c, d, e, f, g, h);
                                                    }
                                                }
                                                if (g != a && g != b && g != c && g != d && g != e && g != f)
                                                {
                                                    w.WriteLine("{0}{1}{2}{3}{4}{5}{6}", a, b, c, d, e, f, g);
                                                }
                                            }
                                            if (f != a && f != b && f != c && f != d && f != e)
                                            {
                                                w.WriteLine("{0}{1}{2}{3}{4}{5}", a, b, c, d, e, f);
                                            }
                                        }
                                        if (e != a && e != b && e != c && e != d)
                                        {
                                            w.WriteLine("{0}{1}{2}{3}{4}", a, b, c, d, e);
                                        }
                                    }
                                    if (d != a && d != b && d != c)
                                    {
                                        w.WriteLine("{0}{1}{2}{3}", a, b, c, d);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
