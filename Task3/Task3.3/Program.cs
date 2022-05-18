using System.Text.RegularExpressions;

bool isMatch(char item1, char item2)
{
    return item1 switch
    {
        '[' when item2 == ']' => true,
        '(' when item2 == ')' => true,
        '{' when item2 == '}' => true,
        _ => false
    };
}

bool CheckPlacement(string inputText)
{
    Stack<char> stack = new Stack<char>();

    for (int i = 0; i < inputText.Length; i++)
    {
        if ("[{(".Contains(inputText[i]))
        {
            stack.Push(inputText[i]);
        }

        if ("]})".Contains(inputText[i]))
        {
            if (stack.Count == 0)
            {
                return false;
            }
            else if (!isMatch(stack.Pop(), inputText[i]))
            {
                return false;
            }
        }
    }

        if (stack.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
}

Stack<char> brackets = new Stack<char>();

Console.WriteLine("Enter text to check!");
var text = Console.ReadLine();
Console.WriteLine("Enter brackets to check!");
var pattern = Console.ReadLine();
var usedBrackets = pattern switch
{
    "{}"=> Regex.Replace(text, @"[^{}]", ""),
    "[]"=> Regex.Replace(text, @"[^][]", ""),
    "()"=> Regex.Replace(text, @"[^()]", ""),
    "[]{}" or "{}[]" => Regex.Replace(text, @"[^][{}]", ""),
    "[]()" or "()[]" => Regex.Replace(text, @"[^][()]", ""),
    "{}()" or "(){}" => Regex.Replace(text, @"[^{}()]", ""),
    "[](){}" or "(){}[]" or "{}[]()" or "()[]{}" or "[]{}()" or "{}()[]" => Regex.Replace(text, @"[^][{}()]", ""),
    _ => Regex.Replace(text, @"[^][{}()]", "")
};

if (usedBrackets.CompareTo(pattern)>=0)
{
    Console.WriteLine(usedBrackets + " - " + CheckPlacement(usedBrackets));
}
else
{
    Console.WriteLine(text + " - text does not contain all brackets in the pattern");
}

