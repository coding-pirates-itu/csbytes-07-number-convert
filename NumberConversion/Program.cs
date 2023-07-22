Console.Write("Input base (10): ");
var inBaseStr = Console.ReadLine();
if (!int.TryParse(inBaseStr, out var inBase)) inBase = 10;

Console.Write("Output base (16): ");
var outBaseStr = Console.ReadLine();
if (!int.TryParse(outBaseStr, out var outBase)) outBase = 16;

Console.Write("Input number: ");
var numStr = Console.ReadLine();
if (string.IsNullOrEmpty(numStr)) return;

var num = 0L;
foreach (var ch in numStr)
{
    var digit = ch <= '9' ? ch - '0' : char.ToUpper(ch) - 'A' + 10;
    if (digit >= inBase)
        throw new ArgumentException($"Digit {ch} is not correct in base {inBase}.");

    num = num * inBase + digit;
}

if (num == 0)
{
    Console.WriteLine("0");
    return;
}

var conv = "";
while (num > 0)
{
    var (q, r) = Math.DivRem(num, outBase);
    var ch = r < 10 ? r + '0' : r - 10 + 'A';
    conv = (char)ch + conv;
    num = q;
}

Console.WriteLine(conv);
