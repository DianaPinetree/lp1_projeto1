## Relatório do trabalho
# 1º Projeto de Linguagens de Programação I - 18Ghosts

**Trabalho realizado por:**
- [Afonso Rosa, a21802169](https://github.com/AfonsoGR)
- [Pedro Inácio, a21802050](https://github.com/PmaiWoW)
- [Rodrigo Pinheiro, a21802488](https://github.com/RodrigoPrinheiro)

#### [Repositório Git Utilizado](https://github.com/RodrigoPrinheiro/lp1_projeto1)

### Realização do Projeto:

- Afonso Rosa:
    
    - Class Text Métodos e texto que compõe o corpo da class
- Pedro Inácio:

    - PLACEHOLDER
- Rodrigo Pinheiro:
    - Iniciou a solução do projeto e iteração da mesma. Tambem criou as classes iniciais usadas no projeto.
	- Desenvolveu as classes ao longo do projeto e modificou-as quando necessário.
	- Geriu a lógica do _Game Loop_ na classe _Game_.


### Arquitetura do Programa:
- O programa está baseado em 2 enumerações principais _CellType_ e _CellColor_ e uma classe de posição _Position_,
estas são depois usadas para constituir as unidades básicas do jogo, _Cell_, _Portal_. 
Achámos necessário separar entre Cell e Portal porque as saídas tinham a peculiaridade de rodarem a sua entrada.
- Para o jogo funcionar em lógica, foi repartido em elementos, _Board_ _Player_ e _WinChecker_.
- Assim o tabuleiro de jogo é uma array bidimensional de objetos _Cell_.
- Os jogadores, cada um, tem uma lista dos seus fantasmas em campo, masmorras e fora do castelo.
- A classe de verificação _WinChecker_ é a base de uma variavel _CellColor_ com todas as cores combinadas
para verificação.

- A classe _Player_ contem todas os métodos relacionados com _input_ e movimentos de fantasmas.
- A classe _Renderer_ serve para desenhar o estado do jogo, e células de cores específicas.

#### [Diagrama UML](https://drive.google.com/file/d/1iydRDRKKwkLcJhz3KOTjGKMDG71ldKUa/view?usp=sharing)
![DiagramaUML](diagramaUml.png)

#### [Fluxograma](https://drive.google.com/file/d/1LfA4-4dr6Sf2HyhDFZUAkrbw2Wnu33jO/view?usp=sharing)
![Fluxograma](fluxograma.png)

### Conclusões:


### Referências:
1. Classe _Portal_ foi usada a resposta a [este](https://stackoverflow.com/questions/30258832/select-next-child-in-array-using-c-sharp) _post_ do stackOverflow, o uso da _keyword_ throw foi importante para _debugging_ do código correspondente;
2. Solução do exercício 30 das bases de cs deste [repositório](https://github.com/VideojogosLusofona/lp1_exercicios) para os movimentos dos fantasmas;
3. Foi usado o [API](https://docs.microsoft.com/en-us/dotnet/api/) do .NET em geral para dúvidas em relação a consola, arrays, e outros elementos do cs.
4. Em específico esta foi a [página](https://docs.microsoft.com/en-us/dotnet/api/system.windows.documents.list?view=netframework-4.8) mais visitada da API
5. Houve uma troca de ideias com o colega Tomás Franco ao logo da realização do projeto de como cada um estava a implementar as soluções.
