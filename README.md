#PorExtensoPTBR
 
 A biblioteca PorExtensoPTBR foi criada para facilitar
a conversão de valores numéricos binários (ulong) por 
extenso em português (PT-BR). Na versão atual esta biblioteca
suporta converter valores de até - ulong.MaxValue, o que significa
dizer que é possível converter valores maiores que 18 quintilhões.

#Para usar a biblioteca PorExtensoPTBR siga os passos abaixo.
1 - Baixe os fontes no seu computador.

2 - Abra o projeto em sua IDE(Se for VS 2012 é possível abrir diretamente com o arquivo PorExtensoPTBR.sln).
Se ocorrer um problema ao abrir o projeto pelo arquivo PorExtensoPTBR.sln, então crie um novo projeto e passe os arquivos
PorExtensoPTBR.cs e Program.cs para este novo projeto.

3 - Leia a documentação existente nos arquivos Program.cs e PorExtensoPTBR.cs.

4 - Execute o método Main do Program.cs para ver o funcionamento.

5 - Use como considerar melhor a biblioteca. Se quiser usar em uma aplicação e vendê-la 
não há problema algum já que a licença da biblioteca está em MIT.

#Abaixo há um exemplo de como utilizar.

Código:

PorExtensoPTBR.Extensive.InFull(18120159287123456089)

Saída:
 
dezoito quintilhões, 
cento e vinte quatrilhões, 
cento e cinquenta e nove trilhões, 
duzentos e oitenta e sete bilhões, 
cento e vinte e três milhões, 
quatrocentos e cinquenta e seis mil e oitenta e nove
