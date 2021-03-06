﻿using System;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlTypes;

namespace One
{
    public class Class1
    {
        [SqlFunction(
           DataAccess = DataAccessKind.None,
           FillRowMethodName = "MyFillRowMethod"
           , IsDeterministic = true)
       ]
        public static IEnumerable Split(string stringToSplit, string delimiters)
        {
            string[] elements = stringToSplit.Split(delimiters.ToCharArray());
            return elements;
        }

        public static void MyFillRowMethod(Object theItem, out SqlChars results)
        {
            results = new SqlChars(theItem.ToString());
        }

        public static SqlInt32 CalculateDeposit(SqlMoney start, SqlDouble percent, SqlMoney add, SqlMoney all)
        {
            var s = start.Value;
            var p = Convert.ToDecimal(percent.Value);
            var a = add.Value;
            var end = all.Value;
            int m = 0;
            while (s < end)
            {
                s += s * (p / 1200) + a;
                m++;
            }

            return new SqlInt32(m);
        }

        [SqlFunction(
           DataAccess = DataAccessKind.None,
           FillRowMethodName = "FillRowKeyValuePair", 
            IsDeterministic = true,
            TableDefinition = "(symbol nvarchar(1), count int)")]
        public static IEnumerable LetterCount(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach(var c in s)
            {
                if(d.ContainsKey(c))
                {
                    d[c]++;
                }
                else
                {
                    d[c] = 1;
                }
            }

            return d;
        }

        public static void FillRowKeyValuePair(object item, out SqlChars symbol, out SqlInt32 count)
        {
            KeyValuePair<char, int> p = (KeyValuePair<char, int>)item;
            symbol = new SqlChars(new char[] { p.Key });
            count = p.Value;
        }

    }
}
