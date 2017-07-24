using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerNS
{
    public class Filer : IFiler
    {
        protected string Level;

        protected string RawString;
        protected string CompressedString;
        protected string DecompressedString;

        public string Load()
        {
            decompress();
            return DecompressedString;
        }

        public void Save(string file, IFileable callBack)
        {
            int rows = callBack.GetRowCount();
            int columns = callBack.GetColumnCount();
            StringBuilder level = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    char part = (char)callBack.WhatsAt(i, j);
                    level.Append(part);
                }
                if (i < (rows - 1))
                {
                    level.AppendLine();
                }
                
            }
            RawString = level.ToString();
            compress();
            System.IO.File.WriteAllText(file, CompressedString);
        }

        public void SetString(string input)
        {
            RawString = input;
            compress();
        }

        protected void compress()
        {
            char[] chars= RawString.ToCharArray();
            StringBuilder builder = new StringBuilder();

            int count = 1;
            char previous = chars[0];

            for (int i = 1; i < chars.Length; i++)
            {
                char current = chars[i];
                if (current == previous)
                {
                    count++;
                }
                else
                {
                    if(count > 1)
                    {
                        builder.Append(count);
                    }
                    builder.Append(previous);
                    count = 1;
                }
                previous = current;
            }
            if(count > 1)
            {
                builder.Append(count);
            }
            CompressedString = builder.Append(previous).ToString();
        }

        protected void decompress()
        {
            char[] chars = CompressedString.ToCharArray();
            StringBuilder builder = new StringBuilder();

            double count = 1;
            for (int i = 0; i < chars.Length; i++)
            {
                char current = chars[i];

                
                if (!char.IsNumber(current))
                {
                    for (int j = 0; j < count; j++)
                    {
                        builder.Append(current);
                    }
                    count = 1;
                }
                else
                {
                    count = char.GetNumericValue(current);
                    char countPlusOne = chars[i + 1];
                        if (char.IsNumber(countPlusOne))
                        {
                            double numCountPlusOne = char.GetNumericValue(countPlusOne);
                            if (count == 2)
                            {
                                count = 1;
                            }
                            int newNumber = int.Parse(count.ToString() + numCountPlusOne.ToString());
                            count = Convert.ToDouble(newNumber);
                            i++;   
                        }                  
                }
            }
            DecompressedString = builder.ToString();
        }
    }
}
