## Relatório do Trabalho
# 1º Projeto de Linguagens de Programação I - 18Ghosts

**Trabalho realizado por:**
- [Afonso Rosa, a21802169](https://github.com/AfonsoGR)
- [Pedro Inácio, a21802050](https://github.com/PmaiWoW)
- [Rodrigo Pinheiro, a21802488](https://github.com/RodrigoPrinheiro)

#### [Repositório Git Utilizado](https://github.com/RodrigoPrinheiro/lp1_projeto1)

### Distribuição e Realização do Projeto:

- Afonso Rosa:
    
    - Construção da classe `Text` e estruturação da mesma, adição das restrições no método `PickColor` da classe `Player` que impedem o jogadores de ter mais de 3 fantasmas de uma cor e que os proíbem de colocar fantasmas de uma cor após já não haver mais para meter. 
    - Aprofundamento substancial do ficheiro `README.md`, sendo um dos responsáveis pelo [Markdown](https://guides.github.com/features/mastering-markdown/) e pela estruturação e organização do mesmo e realização do `Fluxograma`.
- Pedro Inácio:

    - Construção dos métodos `MoveGhost`, `MirrorInterectionCheck` e `MirrorChoice` da class `Player` que tratam do movimento dos fantasmas no tabuleiro de jogo e realização do `Diagrama UML`.
- Rodrigo Pinheiro:
    - Iniciou a solução do projeto e iteração da mesma. Tambem criou as classes iniciais usadas no projeto.
	- Desenvolveu as classes ao longo do projeto e modificou-as quando necessário.
    - Construção e estruturação das classes `BoardClass`, `Cell`, `CellColor`, `CellType`, `Game`, `Player`, `Portal`, `Position`, `Program`, `Renderer` e `WinCheck` e documentação adequada das mesmas. 
    - Realização das classes `BoardClass`, `Cell`, `CellColor`, `CellType`, `Game`, `Portal`, `Position`, `Program`, `Renderer` e `WinCheck` na sua **totalidade** e realização substancial da classe `Player`. 
    - Correção da ortografia na classe `Text`. 
    - Realização da versão inicial do `README.md` e várias alterações ao longo das suas atualizações, verificação do `Fluxograma`, realização do `Doxygen` e incorporação da imagem do `Fluxograma` em `git lfs`.
	- Geriu a lógica do `GameLoop` na classe `Game`.


### Arquitetura do Programa:
- O programa está baseado em 2 enumerações principais `CellType` e `CellColor` e uma classe de posição `Position`, estas são depois usadas para constituir as unidades básicas do jogo, `Cell`, `Portal`. Achámos necessário separar entre `Cell` e `Portal` porque as saídas tinham a peculiaridade de rodarem a sua entrada.
- Para o jogo funcionar em lógica, foi repartido em elementos, `Board`, `Player` e `WinChecker`.
- Assim o tabuleiro de jogo é uma array bidimensional de objetos `Cell`.
- Os jogadores, cada um, tem uma lista dos seus fantasmas em campo, masmorras e fora do castelo.
- A classe de verificação `WinChecker` é a base de uma variavel `CellColor` com todas as cores combinadas para verificação.

- A classe `Player` contem todas os métodos relacionados com _input_ e movimentos de fantasmas.
- A classe `Renderer` serve para desenhar o estado do jogo, e células de cores específicas.

#### [Diagrama UML](https://drive.google.com/file/d/1iydRDRKKwkLcJhz3KOTjGKMDG71ldKUa/view?usp=sharing)
![DiagramaUML](diagramaUml.png)

#### [Fluxograma](https://drive.google.com/file/d/1LfA4-4dr6Sf2HyhDFZUAkrbw2Wnu33jO/view?usp=sharing)
![Fluxograma](fluxograma.png)

### Conclusões e Matéria Aprendida:


### Referências:
1. Classe _Portal_ foi usada a resposta a [este](https://stackoverflow.com/questions/30258832/select-next-child-in-array-using-c-sharp) _post_ do stackOverflow, o uso da _keyword_ throw foi importante para _debugging_ do código correspondente;
2. Solução do exercício 30 das bases de cs deste [repositório](https://github.com/VideojogosLusofona/lp1_exercicios) para os movimentos dos fantasmas;
3. Foi usado o [API](https://docs.microsoft.com/en-us/dotnet/api/) do .NET em geral para dúvidas em relação a consola, arrays, e outros elementos do cs.
4. Em específico esta foi a [página](https://docs.microsoft.com/en-us/dotnet/api/system.windows.documents.list?view=netframework-4.8) mais visitada da API
5. Houve uma troca de ideias com o colega [Tomás Franco, a21803301](https://github.com/ThomasFranque) e com o colega [João Moreira, a21801608](https://github.com/Slatius) ao logo da realização do projeto de como cada um estava a implementar as soluções.
