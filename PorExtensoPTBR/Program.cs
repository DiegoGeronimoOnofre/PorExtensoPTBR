
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
* @channel  https://www.youtube.com/user/cursostd
* @facebook https://www.facebook.com/diegogeronimoonofre
* @Github   https://github.com/DiegoGeronimoOnofre
*/


/**
 * @See PorExtensoPTBR
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * O principal objetivo da classe abaixo é exemplificar a utilização
 * da pequena biblioteca PorExtensoPTBR. Se seu objetivo é usar a biblioteca 
 * com o objetivo de converter um valor numérico por extenso, então eu 
 * recomendo que veja a documentação da biblioteca PorExtensoPTBR para 
 * compreender como esta fantástica biblioteca funciona. Também recomendo que 
 * leia a documentação do método InFull(ulong) da classe Extensive.
 * A documentação está no próprio arquivo.
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

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string newLine = Environment.NewLine;

            for (ulong i = 18120159287123456089; i < ulong.MaxValue; i++)
            {
                try {
                    //A linha abaixo é responsável por converter um valor por extenso.
                    string s = PorExtensoPTBR.Extensive.InFull(i);
                    Console.WriteLine(s);
                    Console.Write(newLine);
                    Console.Write(newLine);
                    System.Threading.Thread.Sleep(60000);
                }
                catch (Exception e){
                    string ee = e.Message;
                }
            }

            Console.ReadKey();
        }
    }
}
