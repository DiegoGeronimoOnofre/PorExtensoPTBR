
/**
The MIT License (MIT)

Copyright (c) 2015 Diego Geronimo D Onofre

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files PorExtensoPTBR, to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

/**
 *
 * @author   Diego Geronimo Onofre
 * @channel  www.youtube.com/user/cursostd
 * @phone    (44) 99802997
 * @facebook www.facebook.com/diegogeronimoonofre 
 */

/**
 * @Version 1.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
 * A biblioteca PorExtensoPTBR foi criada para facilitar
 * a conversão de valores numéricos binários (ulong) por 
 * extenso em português (PT-BR). Na versão atual esta biblioteca
 * suporta converter valores de até - ulong.MaxValue, o que significa
 * dizer que é possível converter valores maiores que 18 quintilhões.
 */



/**
 * Abaixo há um exemplo de um resultado gerado
 * pela biblioteca PorExtensoPTBR com a utilização
 * do método PorExtensoPTBR.Extensive.InFull(ulong)
 * 
 * 18.120.159.287.123.456.089
 * 
 * dezoito quintilhões, 
 * cento e vinte quatrilhões, 
 * cento e cinquenta e nove trilhões, 
 * duzentos e oitenta e sete bilhões, 
 * cento e vinte e três milhões, 
 * quatrocentos e cinquenta e seis mil e oitenta e nove
 */



namespace PorExtensoPTBR
{
    /**
    * A classe Extensive foi criada com o propósito de oferecer
    * um método para fazer a conversão de um valor por extenso em 
    * língua portuguesa (PT-BR). O método InFull tem este objetivo. 
    * Use o método InFull desta classe para então converter um 
    * valor por extenso (PT-BR) facilmente.
    */

    public class Extensive
    {
         /**
         * Com o método InFull é possível converter um valor numérico
         * por extenso. Tendo um valor numérico que haja a necessidade 
         * de convertê-lo ou descrevê-lo em uma string o método InFull 
         * pode ser utilizado para este propósito. Para isso é necessário 
         * passar um valor numérico do tipo ulong para o método InFull e
         * assim receber como retorno uma string que possui o valor numérico 
         * descrito como texto em língua portuguesa (PT-BR).
         */


        public static string InFull(ulong value)
        {
            if (value == 0)
                return "zero";

            string text = value.ToString();
            List<string> firstList = new List<string>();
            int currentSection = 0;
            bool wasAddedAnd = false;

            for (int i = text.Length - 1; i >= 0; i = i - 3)
            {
                string d1 = text[i].ToString();
                string d2 = ( i - 1 >= 0 ? text[i - 1].ToString() : "0");
                string d3 = ( i - 2 >= 0 ? text[i - 2].ToString() : "0");
                bool isEmpty = (d1 == "0" && d2 == "0" && d3 == "0");

                if ((d3 == "0" ) 
                && ( d2 == "0" ) 
                &&   d1 == "1" )
                {
                    if (currentSection == 1)
                    {
                        firstList.Add("mil");
                        currentSection++;
                        break;
                    }
                    else if (currentSection == 2)
                        firstList.Add("milhão");
                    else if (currentSection == 3)
                        firstList.Add("bilhão");
                    else if (currentSection == 4)
                        firstList.Add("trilhão");
                    else if (currentSection == 5)
                        firstList.Add("quatrilhão");
                    else if (currentSection == 6)
                        firstList.Add("quintilhão");
                }
                else if ( ! isEmpty )
                {
                    Section section = sections[currentSection];
                    firstList.Add(section.Text);
                }

                //ext armazena três dígitos
                string ext = Ext(d3, d2, d1);
                firstList.Add(ext);
                bool lastTime = i == 0 || i == 1 || i == 2;

                if (!lastTime && !isEmpty && !wasAddedAnd)
                {
                    firstList.Add("e");
                    wasAddedAnd = true;
                }
                else if (!lastTime && !isEmpty)
                    firstList.Add(",");
                
                currentSection++;
            }

            StringBuilder result = new StringBuilder();
            List<string> secondList = new List<string>();

            foreach (string val in firstList)
                if (val != string.Empty)
                    secondList.Add(val);

            for (int i = secondList.Count - 1; i >= 0; i--)
            {
                string val = secondList[i];
                result.Append(val);

                if (i - 1 >= 0)
                {
                    string nextVal = secondList[i - 1];

                    /*Verificando se i != 0 para 
                    não colocar espaço no fim da string*/

                    if ( nextVal != "," && i != 0 )
                        result.Append(' ');
                }
            }

            return result.ToString();
        }

        private class Number
        {
            private int digit;

            public int Digit
            {
                get { return digit; }
            }

            private string text;

            public string Text
            {
                get { return text; }
            }

            public Number(int digit, string text)
            {
                if (digit < 0 || digit > 9)
                    throw new ArgumentException("digit is invalid " + digit);

                if (text == null)
                    throw new ArgumentException("text is null");

                this.digit = digit;
                this.text = text;
            }

            public override string ToString()
            {
                return text + "-" + digit;
            }
        }


        private static readonly Number[] decimal1 = new Number[] { new Number(1,"um"  ),
                                                                   new Number(2,"dois"),
                                                                   new Number(3,"três"),
                                                                   new Number(4,"quatro"),
                                                                   new Number(5,"cinco"),
                                                                   new Number(6,"seis"),
                                                                   new Number(7,"sete"),
                                                                   new Number(8,"oito"),
                                                                   new Number(9,"nove")
                                                                 };

        private static readonly Number[] afterTen = new Number[] { new Number(1,"onze"), 
                                                                   new Number(2,"doze"),
                                                                   new Number(3,"treze"),
                                                                   new Number(4,"quatorze"),
                                                                   new Number(5,"quinze"),
                                                                   new Number(6,"dezeseis"),
                                                                   new Number(7,"dezesete"),
                                                                   new Number(8,"dezoito"),
                                                                   new Number(9,"dezenove")
                                                                 };

        private static readonly Number[] decimal2 = new Number[] { new Number(1,"dez"),
                                                                   new Number(2,"vinte"), 
                                                                   new Number(3,"trinta"), 
                                                                   new Number(4,"quarenta"), 
                                                                   new Number(5,"cinquenta"), 
                                                                   new Number(6,"sessenta"), 
                                                                   new Number(7,"setenta"), 
                                                                   new Number(8,"oitenta"), 
                                                                   new Number(9,"noventa")
                                                                 };

        private static readonly Number[] decimal3 = new Number[] { new Number(1,"cento"),
                                                                   new Number(2,"duzentos"),
                                                                   new Number(3,"trezentos"),
                                                                   new Number(4,"quatrocentos"),
                                                                   new Number(5,"quinhentos"),
                                                                   new Number(6,"seiscentos"),
                                                                   new Number(7,"setecentos"),
                                                                   new Number(8,"oitocentos"),
                                                                   new Number(9,"novecentos")
                                                                 };

        private const int DECIMAL1 = 0;

        private const int AFTER_TEN = 1;

        private const int DECIMAL2 = 2;
        
        private const int DECIMAL3 = 3;

        private static readonly Number[][] decimals = new Number[][] { decimal1, 
                                                                       afterTen, 
                                                                       decimal2, 
                                                                       decimal3 };
    
        private static Number FindNumber(int dec, int digit)
        {
            if (dec < 0 || dec > 3)
                throw new ArgumentException("dec is out of range: " + dec );

            if (digit < 1 || digit > 9)
                throw new ArgumentException("digit is out of range: " + digit);

            Number[] array = decimals[dec];

            foreach (Number n in array)
            {
                if (digit == n.Digit)
                    return n;
            }

            throw new Exception("Internal error of FindNumber");
        }

        private class Section
        {
            private int sectionValue;

            public int SectionValue
            {
                get { return sectionValue; }
            }

            private string text;

            public string Text
            {
                get { return text; }
            }

            public static readonly Section empty       = new Section(0, "");

            public static readonly Section thousand    = new Section(1, "mil");

            public static readonly Section million     = new Section(2, "milhões");

            public static readonly Section billion     = new Section(3, "bilhões");

            public static readonly Section trillion    = new Section(4, "trilhões");

            public static readonly Section quadrillion = new Section(5, "quatrilhões");

            public static readonly Section quintillion = new Section(6, "quintilhões");

            private Section(int sectionValue, string text)
            {
                if (sectionValue < 0)
                    throw new ArgumentException("sectionValue is invalid:" + sectionValue);

                if (sectionValue > 6)
                    throw new ArgumentException("sectionValue has an unsupported value :" + sectionValue);

                this.sectionValue = sectionValue;
                this.text = text;
            }

            public override string ToString()
            {
                return text + "-" + sectionValue;
            }
        }

        private static readonly Section[] sections = new Section[] {Section.empty, 
                                                                    Section.thousand,
                                                                    Section.million,
                                                                    Section.billion,
                                                                    Section.trillion,
                                                                    Section.quadrillion,
                                                                    Section.quintillion                                                                   
                                                                   };

        private static string Ext(string d3, string d2, string d1)
        {
            Number number1  = ( d1 != "0" ? FindNumber(DECIMAL1,  Convert.ToInt32(d1)) : null);
            Number afterTen = ( d1 != "0" ? FindNumber(AFTER_TEN, Convert.ToInt32(d1)) : null);
            Number number2  = ( d2 != "0" ? FindNumber(DECIMAL2,  Convert.ToInt32(d2)) : null);
            Number number3  = ( d3 != "0" ? FindNumber(DECIMAL3,  Convert.ToInt32(d3)) : null);

            if (d2 == "1")
            {
                if (number3 == null)
                    return (afterTen != null ? afterTen.Text : number2.Text);
                else
                {
                    return number3.Text
                        + " e " + ( afterTen != null ? afterTen.Text :  number2.Text);
                }
            }
            else
            {
                if (d1 == "0"
                 && d2 == "0"
                 && d3 == "1")
                {
                    return "cem";
                }
                else
                {
                    if (d3 != "0")
                    {
                        if (number2 != null && number1 != null)
                        {
                            return number3.Text
                         + " e " + number2.Text
                         + " e " + number1.Text;
                        }
                        else if (number2 != null)
                        {
                            return number3.Text
                         + " e " + number2.Text;

                        }
                        else if (number1 != null)
                        {
                            return number3.Text
                         + " e " + number1.Text;
                        }
                        else
                            return number3.Text;
                    }
                    else if (d2 != "0")
                    {
                        if (number1 != null)
                        {
                            return number2.Text
                         + " e " + number1.Text;
                        }
                        else
                            return number2.Text;
                    }
                    else if ( number1 != null )
                        return number1.Text;
                }
            }

            return string.Empty;
        }
    }
}
