using System.Globalization;

public class Entry
{
    public string Data { get; set; }

    public int Freq { get; set; }

    public int Order { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Freq; i++)
        {
            sb.Append(Data);
        }
        return sb.ToString();
    }
}

public class Solution
{
    public string DecodeString(string s)
    {
        if (string.IsNullOrWhiteSpace(s) || !IsValidString(s)) return s;

        var sb = new StringBuilder();

        var entryList = Parse(s);

        foreach (var entry in entryList)
        {
            if (IsProcessingComplete(entry.Data))
            {
                sb.Append(entry);
            }
            else
            {
                var tempString = DecodeString(entry.ToString());
                sb.Append(tempString);
            }
        }
        return sb.ToString();
    }

    public IList<Entry> Parse(string s)
    {
        var resultList = new List<Entry>();
        if (string.IsNullOrWhiteSpace(s) || !IsValidString(s)) return resultList;

        var freq = 0;
        var nbrackets = 0;
        var order = 0;
        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]) && nbrackets == 0)
            {
                if (sb.Length > 0)
                {
                    //Time to process, don't append
                    var entry = new Entry
                    {
                        Data = sb.ToString(),
                        Freq = freq == 0 ? 1 : freq,
                        Order = order
                    };
                    resultList.Add(entry);

                    sb.Clear(); //Clear the sb buffer
                    freq = 0; //Reset the frequency
                    order++;
                }
                freq = 10*freq + CharUnicodeInfo.GetDigitValue(s[i]);
            }
            else if (s[i] == '[')
            {
                nbrackets++;
                if (nbrackets == 1)
                {
                    //Time to start processing, don't append this character
                }
                else
                {
                    //Append
                    sb.Append(s[i]);
                }
            }
            else if (s[i] == ']')
            {
                nbrackets--;
                if (nbrackets == 0)
                {
                    //Time to process, don't append
                    var entry = new Entry
                    {
                        Data = sb.ToString(),
                        Freq = freq == 0 ? 1 : freq,
                        Order = order
                    };
                    resultList.Add(entry);

                    sb.Clear(); //Clear the sb buffer
                    freq = 0; //Reset the frequency
                    order++;
                }
                else
                {
                    //Append
                    sb.Append(s[i]);
                }
            }
            else
            {
                sb.Append(s[i]);
            }
        }

        if (sb.Length > 0)
        {
            //Time to process, don't append
            var entry = new Entry
            {
                Data = sb.ToString(),
                Freq = freq == 0 ? 1 : freq,
                Order = order
            };
            resultList.Add(entry);
        }

        return resultList;
    }

    public bool IsProcessingComplete(string data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (string.Empty == data) return true;

        return !data.Contains("[") || !data.Contains("]");
    }

    public bool IsValidString(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return true;
        var count = 0;
        foreach (var c in s)
        {
            if (c == '[')
            {
                count++;
            }
            else if (c == ']')
            {
                count--;
                if (count < 0) return false;
            }
        }
        return count == 0;
    }
}
