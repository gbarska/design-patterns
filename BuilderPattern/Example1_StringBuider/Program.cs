﻿using System.Text;
using System;

namespace BuilterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //example using a basic simple builder 
            var hello = "hello";

            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            
            Console.WriteLine(sb);

        var words = new[] {"hello", "world"};

        sb.Clear();
        sb.Append("<ul>");
        foreach (var item in words)
        {
            sb.AppendFormat("<li>{0}</li>", item);
        }
        
        
        sb.Append("</ul>");
        Console.WriteLine(sb);
        }
    }
}
