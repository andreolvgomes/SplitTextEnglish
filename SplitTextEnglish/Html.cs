using System;
using System.Collections.Generic;
using System.Text;

namespace TextEnglish
{
    public class Html
    {
        private string body = @"</--Site de transcrição fonêtica-->
</--https://tophonetics.com/pt/-->

<html>
<head>
<style>
	hr.line { border-top: 1px dotted red; }
	h1.one { font-family:verdana;color:teal }
	h1.two { font-family:courier;font-size:150% }
	h2.three { font-family:verdana; color:green }
</style>
</head>
<body>";

        private string footer = @"</body>
</html>";

        public string GerHtml(List<Phrase> phrases, bool numerar)
        {
            string format = String.Format(@"
<h1 class='one'>
english
</h1>
<h1 class='two'>
.......
</h1>
<h2 class='three'>
portuguese
</h2>
<hr class='line'>");

            string text = "";
            for (int i = 0; i < phrases.Count; i++)
            {
                if (i > 0)
                    text += "\n";

                string newstr = format;
                Phrase phrase = phrases[i];
                if (numerar)
                    newstr = newstr.Replace("english", (i + 1).ToString() + "-" + phrase.English.Replace("\r\n", " "));
                else
                    newstr = newstr.Replace("english", phrase.English.Replace("\r\n", " "));

                newstr = newstr.Replace("portuguese", phrase.Portuguese.Replace("\r\n", " "));
                if (!string.IsNullOrEmpty(phrase.Transcricao))
                    newstr = newstr.Replace(".......", phrase.Transcricao.Replace("\r\n", " "));

                text += newstr;
            }

            string full = body + text + footer;
            return full;
        }
    }
}