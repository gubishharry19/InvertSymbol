using System;
using System.Collections.Generic;

namespace InvertSymbolUaEng
{
    class Model
    {
        #region Словники з розкладками клавіатури
        Dictionary<char, char> InvEngUa = new Dictionary<char, char>()
        {
            {'Q', 'Й' },{'W', 'Ц' },{'E', 'У' },{'R', 'К' },
            {'T', 'Е' },{'Y', 'Н' },{'U', 'Г' },{'I', 'Ш' },
            {'O', 'Щ' },{'P', 'З' },{'{', 'Х' },{'}', 'Ї' },
            {'A', 'Ф' },{'S', 'І' },{'D', 'В' },{'F', 'А' },
            {'G', 'П' },{'H', 'Р' },{'J', 'О' },{'K', 'Л' },
            {'L', 'Д' },{':', 'Ж' },{'"', 'Є' },{'Z', 'Я' },
            {'X', 'Ч' },{'C', 'С' },{'V', 'М' },{'B', 'И' },
            {'N', 'Т' },{'M', 'Ь' },{'<', 'Б' },{'>', 'Ю' },
            {'?', ',' },{'~','₴' },
            {'q', 'й' },{'w', 'ц' },{'e', 'у' },{'r', 'к' },
            {'t', 'е' },{'y', 'н' },{'u', 'г' },{'i', 'ш' },
            {'o', 'щ' },{'p', 'з' },{'[', 'х' },{']', 'ї' },
            {'a', 'ф' },{'s', 'і' },{'d', 'в' },{'f', 'а' },
            {'g', 'п' },{'h', 'р' },{'j', 'о' },{'k', 'л' },
            {'l', 'д' },{';', 'ж' },{'\'', 'є' },{'z', 'я' },
            {'x', 'ч' },{'c', 'с' },{'v', 'м' },{'b', 'и' },
            {'n', 'т' },{'m', 'ь' },{',', 'б' },{'.', 'ю' },
            {'/', '.' },
            {'@', '"' },{'#', '№' },{'$', ';' },{'^', ':' },
            {'&', '?' },{'|','/' },{'`','\'' }
        };
        Dictionary<char, char> InvUaEng = new Dictionary<char, char>()
        {
            {'Й', 'Q' },{'Ц', 'W' },{'У','E' }, {'К', 'R' },
            {'Е', 'T' },{'Н', 'Y' },{'Г','U' }, {'Ш', 'I' },
            {'Щ', 'O' },{'З', 'P' },{'Х','{' }, {'Ї', '}' },
            {'Ф', 'A' },{'І', 'S' },{'В','D' }, {'А', 'F' },
            {'П', 'G' },{'Р', 'H' },{'О','J' }, {'Л', 'K' },
            {'Д', 'L' },{'Ж', ':' },{'Є','"' }, {'Я', 'Z' },
            {'Ч', 'X' },{'С', 'C' },{'М','V' }, {'И', 'B' },
            {'Т', 'N' },{'Ь', 'M' },{'Б','<' }, {'Ю', '>' },
            {',', '?' },{'₴', '~'},
            {'й', 'q' },{'ц', 'w' },{'у','e' }, {'к', 'r' },
            {'е', 't' },{'н', 'y' },{'г','u' }, {'ш', 'i' },
            {'щ', 'o' },{'з', 'p' },{'х','[' }, {'ї', ']' },
            {'ф', 'a' },{'і', 's' },{'в','d' }, {'а', 'f' },
            {'п', 'g' },{'р', 'h' },{'о','j' }, {'л', 'k' },
            {'д', 'l' },{'ж', ';' },{'є','\'' },{'я', 'z' },
            {'ч', 'x' },{'с', 'c' },{'м', 'v' },{'и', 'b' },
            {'т', 'n' },{'ь', 'm' },{'б', ',' },{'ю', '.' },
            {'.', '/' },
            {'"', '@' },{'№', '#' },{';', '$' },{':', '^' },
            {'?', '&' },{'/', '|' },{'\'', '`'}
        };
#endregion
        public string Convert(string words, bool isEng)
        {
            string conv_string = "";
            var inv = isEng ? InvEngUa : InvUaEng;
            for (int i = 0; i < words.Length; i++)
            {
                if (inv.ContainsKey(words[i]))
                    conv_string += inv[words[i]];
                else if (words[i] == ' ' || (words[i] >= 48 && words[i] <= 57)//ASCII цифер
                    || words[i] == '\n' || words[i] == '\r' || words[i] == '-' || words[i] == '_'
                    || (words[i] >= 40 && words[i] <= 42) || words[i] == 37//()*%
                    )
                    conv_string += words[i];
                else
                    throw new Exception("Symbol error: Invalid symbol");
                continue;
            }
            return conv_string;
        }
        #region Перевірка розкладки
        public static bool IsEng(string text)
        {
            int i=0;
            while (true)
            {
                if ((text[i]>=65&&text[i]<=90)||(text[i]>=97&&text[i]<=122))
                {
                    return true;
                }
                else if(text[i]== 'Ґ'||text[i] == 'ґ' || text[i] =='ї' || text[i] == 'Ї'
                    || text[i] == 'Є' || text[i] == 'є' || text[i] == 'і' || text[i] == 'І'||
                    (text[i]>='А'&&text[i]<='Я')|| (text[i] >= 'а' && text[i] <= 'я'))
                {
                    return false;
                }
                else
                {
                    i++;
                    continue;
                }
            }
        }
#endregion
    }

}
